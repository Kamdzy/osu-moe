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
    public class MainViewModel : ViewModelBase 
    {
        private DelegateCommand _applyCommand;
        private BitmapImage _avatar;
        private BitmapImage _userflag;
        private string _username;
        private string _apivalidation;
        private string _apivalidationbrush;
        private string _isavatarborderenabled;

        public MainViewModel()
        {
            ApplyCommand = new DelegateCommand(() =>
            {
                Load(SettingsService.ApiKey);
            });

        }
        public DelegateCommand ApplyCommand
        {
            get => _applyCommand;
            set => SetProperty(ref _applyCommand, value);
        }

        public BitmapImage Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }
        public BitmapImage UserFlag
        {
            get => _userflag;
            set => SetProperty(ref _userflag, value);
        }

        public string ApiValidation
        {
            get => _apivalidation;
            set => SetProperty(ref _apivalidation, value);
        }
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string ApiValidationBrush
        {
            get => _apivalidationbrush;
            set => SetProperty(ref _apivalidationbrush, value);
        }

        public string IsAvatarBorderEnabled
        {
            get => _isavatarborderenabled;
            set => SetProperty(ref _isavatarborderenabled, value);
        }
        public void Load(string apiKey)
        {
            try
            {
                OsuClient osu = new OsuClient(apiKey);
                var userinfo = osu.GetUser("Kamdzy", 0, 1);
               

                ApiValidation = "Successful";
                ApiValidationBrush = "Green";

                Avatar = new BitmapImage(new Uri(userinfo[0].image));
                IsAvatarBorderEnabled = "5";
                UserFlag = new BitmapImage(new Uri(userinfo[0].flag));
                Username = userinfo[0].username;


            }
            catch (WebException)
            {
                ApiValidation = "Unsuccessful";
                ApiValidationBrush = "Red";
            }
            

        }
    }
}
