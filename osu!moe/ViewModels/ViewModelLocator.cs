using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_moe.ViewModels
{
    public class ViewModelLocator
    {
        private MainViewModel mainViewModel;
        private SettingsViewModel settingsViewModel;

        public MainViewModel Main
        {
            get
            {
                if (mainViewModel == null)
                {
                    mainViewModel = new MainViewModel();
                }

                return mainViewModel;
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                if (settingsViewModel == null)
                {
                    settingsViewModel = new SettingsViewModel();
                }

                return settingsViewModel;
            }
        }
    }
}
