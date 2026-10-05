using System;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Web.WebView2.Core;

namespace BiliBiliSur
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await WebView.EnsureCoreWebView2Async();

            WebView.CoreWebView2.NavigationCompleted += (s, args) =>
            {
                var fade = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromMilliseconds(600)));
                fade.Completed += (o, ev) => Splash.Visibility = Visibility.Collapsed;
                Splash.BeginAnimation(OpacityProperty, fade);
            };

            WebView.CoreWebView2.Navigate("https://www.bilibili.com");
        }
    }
}