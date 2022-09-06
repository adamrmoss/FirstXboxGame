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
            this.InitializeComponent();

            // Create the game.
            var launchArguments = string.Empty;
            this.game = MonoGame.Framework.XamlGame<FirstXboxGame>.Create(launchArguments, Window.Current.CoreWindow, this.swapChainPanel);
        }
    }
}
