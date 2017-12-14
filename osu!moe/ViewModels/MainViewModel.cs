using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    class MainViewModel : ViewModelBase
    {
        private BitmapImage _avatar;
        public BitmapImage Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private DelegateCommand _applyCommand;

        public DelegateCommand ApplyCommand
        {
            get => _applyCommand;
            set => SetProperty(ref _applyCommand, value);
        }

        public MainViewModel()
        {
            ApplyCommand = new DelegateCommand(() =>
            {
                Load(SettingsService.ApiKey);
            });

        }

        public void Load(string apiKey)
        {
            try
            {
                OsuClient osu = new OsuClient(apiKey);
                var userinfo = osu.GetUser("Kamdzy", 0, 1);
                var imgurl = userinfo[0].image;
                var bimage = new BitmapImage(new Uri(imgurl));

                Avatar = bimage;
                Username = userinfo[0].username;
            }
            catch (WebException)
            {
                Username = "Invalid or no API Key Entered";

            }


        }
    }
}
