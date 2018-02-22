
namespace osu_moe
{
    using osu_moe.Properties;

    using TinyLittleMvvm;

    /// <inheritdoc />
    /// <summary>
    /// The informer.
    /// </summary>
    internal class Informer : PropertyChangedBase
    {
        /// <summary>
        ///     The access key.
        /// </summary>
        private string accessKey;

        /// <summary>
        ///     Gets or sets the access key.
        /// </summary>
        public string AccessKey
        {
            get => this.accessKey;
            set
            {
                this.accessKey = value;
                this.NotifyOfPropertyChange(() => this.AccessKey);
                Settings.Default.ApiKey = this.accessKey;
                Settings.Default.Save();
            }
        }
    }
}