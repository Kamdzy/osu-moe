using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CSharpOsu;
using CSharpOsu.Module;
using osu_moe.Mvvm;
using osu_moe.Services;

namespace osu_moe.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {


        private string _apiKey;

        public string ApiKey
        {
            get
            {
                return _apiKey;
            }
            set { SetProperty(ref _apiKey, value); }
        }


        private DelegateCommand _applyCommand;

        public DelegateCommand ApplyCommand
        {
            get { return _applyCommand; }
            set { SetProperty(ref _applyCommand, value); }
        }

        public SettingsViewModel()
        {
            ApplyCommand = new DelegateCommand(() =>
            {
                SettingsService.ApiKey = ApiKey;
            });
        }
    }
}
