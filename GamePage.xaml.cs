using System;

using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FirstXboxGame
{
    public sealed partial class GamePage : Page
    {
        readonly FirstXboxGame game;

        public GamePage()
        {
            MaximizeWindowOnLoad();
            this.InitializeComponent();

            // Create the game.
            var launchArguments = string.Empty;
            this.game = MonoGame.Framework.XamlGame<FirstXboxGame>.Create(launchArguments, Window.Current.CoreWindow, this.swapChainPanel);
        }

        private static void MaximizeWindowOnLoad()
        {
            var view = DisplayInformation.GetForCurrentView();

            var resolution = new Size(view.ScreenWidthInRawPixels, view.ScreenHeightInRawPixels);

            var scale = view.ResolutionScale == ResolutionScale.Invalid ? 1 : view.RawPixelsPerViewPixel;
            var bounds = new Size(resolution.Width / scale, resolution.Height / scale);

            ApplicationView.PreferredLaunchViewSize = new Size(bounds.Width, bounds.Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
    }
}
