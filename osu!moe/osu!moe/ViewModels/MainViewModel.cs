
namespace osu_moe.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using osu_moe.Properties;

    using TinyLittleMvvm;

    /// <inheritdoc />
    /// <summary>
    ///     The main view model.
    /// </summary>
    internal class MainViewModel : PropertyChangedBase
    {
        /// <summary>
        ///     The dialog manager.
        /// </summary>
        private readonly IDialogManager dialogManager;

        /// <summary>
        ///     The home view model.
        /// </summary>
        private HomeViewModel homeViewModel;

        /// <summary>
        ///     The informer.
        /// </summary>
        private Informer informer;

        /// <summary>
        ///     The second view model.
        /// </summary>
        private SecondViewModel secondViewModel;

        /// <summary>
        ///     The view model.
        /// </summary>
        private PropertyChangedBase viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="diaManager">
        /// The dialog Manager.
        /// </param>
        public MainViewModel(IDialogManager diaManager)
        {
            this.dialogManager = diaManager;
            this.ViewModel = this.Home;

            this.LoadedViewCommand = new AsyncRelayCommand(this.OnShowOsuAccessKeyDialogAsync);
            this.HomeViewCommand = new RelayCommand(this.DisplayHomeView);
            this.SecondViewCommand = new RelayCommand(this.DisplaySecondView);
        }

        /// <summary>
        ///     Gets the home.
        /// </summary>
        public HomeViewModel Home => this.homeViewModel ?? (this.homeViewModel = new HomeViewModel());

        /// <summary>
        ///     Gets the home view command.
        /// </summary>
        public ICommand HomeViewCommand { get; }

        /// <summary>
        ///     Gets the informer.
        /// </summary>
        public Informer Informer => this.informer ?? (this.informer = new Informer());

        /// <summary>
        ///     Gets the loaded view command.
        /// </summary>
        public ICommand LoadedViewCommand { get; }

        /// <summary>
        ///     Gets the second.
        /// </summary>
        public SecondViewModel Second => this.secondViewModel ?? (this.secondViewModel = new SecondViewModel());

        /// <summary>
        ///     Gets the second view command.
        /// </summary>
        public ICommand SecondViewCommand { get; }

        /// <summary>
        ///     Gets or sets the view model.
        /// </summary>
        public PropertyChangedBase ViewModel
        {
            get => this.viewModel;
            set
            {
                this.viewModel = value;
                this.NotifyOfPropertyChange(() => this.ViewModel);
            }
        }

        /// <summary>
        ///     The display home view.
        /// </summary>
        public void DisplayHomeView()
        {
            this.ViewModel = this.Home;
        }

        /// <summary>
        ///     The display second view.
        /// </summary>
        public void DisplaySecondView()
        {
            this.ViewModel = this.Second;
        }

        /// <summary>
        ///     The show sample dialog async.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        private async Task OnShowOsuAccessKeyDialogAsync()
        {
            if (this.Informer.AccessKey == null)
            {
                var input = await this.dialogManager.ShowDialogAsync<OsuAccessKeyDialogViewModel, string>();
                if (input != null)
                {
                    await this.dialogManager.ShowMessageBox(Settings.Default.ApiKey, "You entered: " + input);
                }

                this.Informer.AccessKey = input;
            }
        }
    }
}