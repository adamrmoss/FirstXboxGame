using Windows.Foundation;
using Windows.Graphics.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstXboxGame
{
    public class FirstXboxGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public FirstXboxGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            var view = DisplayInformation.GetForCurrentView();

            var resolution = new Size(view.ScreenWidthInRawPixels, view.ScreenHeightInRawPixels);

            var bounds = new Size(resolution.Width, resolution.Height);


            var viewportBounds        = this.GraphicsDevice.Viewport.Bounds;
            var viewportTitleSafeArea = this.GraphicsDevice.Viewport.TitleSafeArea;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var pressingBackButton = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
            var pressingBButton = GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed;
            var pressingEscapeKey  = Keyboard.GetState().IsKeyDown(Keys.Escape);

            if (pressingBackButton || pressingBButton || pressingEscapeKey)
            {
                this.Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Yellow);

            //var viewportBounds        = this.GraphicsDevice.Viewport.Bounds;
            //var viewportTitleSafeArea = this.GraphicsDevice.Viewport.TitleSafeArea;

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
