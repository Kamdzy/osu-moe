using System;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace osu_moe.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Circle }, Text = "Main", NavigationDestination = new Uri("Views/MainPage.xaml", UriKind.RelativeOrAbsolute) });

            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Cogs }, Text = "Settings", NavigationDestination = new Uri("Views/SettingsPage.xaml", UriKind.RelativeOrAbsolute) });
        }
    }
}