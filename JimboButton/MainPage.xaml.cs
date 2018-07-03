using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JimboButton
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 300));
            ApplicationView.PreferredLaunchViewSize = new Size(500, 300);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // extract the text quote from the data
            GetData instance = new GetData();
            string msg = instance.GetQuote("SELECT Quote FROM Quotes WHERE QuoteID = @QuoteID");

            // set the source file for the audio - as soon as this is set it will start playing
            Uri audio = new Uri("ms-appx:///Audio/audio.mp3");
            Audio.Source = audio;

            // show message box with text from one of the quotes in the data
            Msgbox.Show(msg, "AC Jimbo Quote Machine");
        }
    }
}
