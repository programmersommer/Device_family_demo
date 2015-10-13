using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Device_family_demo
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            bool isHardwareButtonsAPIPresent =
                    Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");

            if (isHardwareButtonsAPIPresent)
            {
                Windows.Phone.UI.Input.HardwareButtons.CameraPressed += HardwareButtons_CameraPressed;
            }


            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Windows.UI.Colors.Chocolate;
                statusBar.BackgroundOpacity = 1;
            }

        }


        private void HardwareButtons_CameraPressed(object sender, Windows.Phone.UI.Input.CameraEventArgs e)
        {
            // обработка нажатия кнопки "Назад"
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.Equals(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily, "Windows.Desktop"))
            {
                txtInCenter.Text = "Это десктоп!! Та-да!!!";
            }
        }

    }
}
