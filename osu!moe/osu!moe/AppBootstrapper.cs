
namespace osu_moe
{
    using Autofac;

    using osu_moe.ViewModels;
    using osu_moe.Views;

    using TinyLittleMvvm;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class AppBootstrapper : BootstrapperBase<MainViewModel>
    {
        /// <inheritdoc />
        /// <summary>
        /// The container.
        /// </summary>
        /// <param name="builder">
        /// The container builder.
        /// </param>
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            builder.RegisterType<MainViewModel>();
            builder.RegisterType<MainView>();

            builder.RegisterType<OsuAccessKeyDialogViewModel>();
            builder.RegisterType<OsuAccessKeyDialogView>();

            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<HomeView>();

            builder.RegisterType<SecondViewModel>();
            builder.RegisterType<SecondView>();

            builder.RegisterType<Informer>();
        }
    }
}