
namespace osu_moe.ViewModels
{
    using System.Windows.Input;

    using TinyLittleMvvm;

    /// <inheritdoc />
    /// <summary>
    ///     The access key request dialog view model.
    /// </summary>
    public class OsuAccessKeyDialogViewModel : DialogViewModel<string>
    {
        /// <summary>
        ///     The text.
        /// </summary>
        private string text;

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:osu_moe.ViewModels.OsuAccessKeyDialogViewModel" /> class.
        /// </summary>
        public OsuAccessKeyDialogViewModel()
        {
            this.OkCommand = new RelayCommand(this.OnOk, this.CanOk);
            this.text = string.Empty;
        }

        /// <summary>
        ///     Gets the ok command.
        /// </summary>
        public ICommand OkCommand { get; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text
        {
            get => this.text;
            set
            {
                if (this.text == value)
                {
                    return;
                }

                this.text = value;
                this.NotifyOfPropertyChange(() => this.Text);
            }
        }

        /// <summary>
        ///     The can ok.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        private bool CanOk()
        {
            return !this.HasErrors;
        }

        /// <summary>
        ///     The on ok.
        /// </summary>
        private void OnOk()
        {
            this.Close(this.Text);
        }
    }
}