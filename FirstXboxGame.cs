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
        private SpriteBatch           spriteBatch;
        private Size                  resolution;
        private Rectangle             screenBounds;
        private Rectangle             viewportBounds;
        private Rectangle             viewportTitleSafeArea;
        private Color                 matteColor;
        private Color                 backgroundColor;
        private Texture2D             matteTexture;
        private Texture2D             backgroundTexture;

        public FirstXboxGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            // Save screen info
            var view = DisplayInformation.GetForCurrentView();

            this.resolution   = new Size(view.ScreenWidthInRawPixels, view.ScreenHeightInRawPixels);
            this.screenBounds = new Rectangle(0, 0, (int) this.resolution.Width, (int) this.resolution.Height);

            // Screen Colors
            this.matteColor      = Color.Red;
            this.backgroundColor = Color.Gray;

            // Matte Texture
            this.matteTexture = new Texture2D(this.GraphicsDevice, 1, 1);
            this.matteTexture.SetData(new [] { this.matteColor });

            // Background Texture
            this.backgroundTexture = new Texture2D(this.GraphicsDevice, 1, 1);
            this.backgroundTexture.SetData(new [] { this.backgroundColor });

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create the Sprite Batch
            this.spriteBatch  = new SpriteBatch(this.GraphicsDevice);

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

            if (!this.graphics.IsFullScreen)
            {
                this.graphics.ToggleFullScreen();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var isFullScreen           = this.graphics.IsFullScreen;
            var presentationParameters = this.graphics.GraphicsDevice.PresentationParameters;
            

            this.GraphicsDevice.DisplayMode.

            // Get Viewport bounds
            this.viewportBounds        = this.GraphicsDevice.Viewport.Bounds;
            this.viewportTitleSafeArea = this.GraphicsDevice.Viewport.TitleSafeArea;

            var matteOffsetX  = -(this.screenBounds.Width  - this.viewportTitleSafeArea.Width)  / 2;
            var matteOffsetY  = -(this.screenBounds.Height - this.viewportTitleSafeArea.Height) / 2;
            var relativeMatte = new Rectangle(matteOffsetX, matteOffsetY, this.screenBounds.Width, this.screenBounds.Height);

            // Clear the viewport with matte color
            this.GraphicsDevice.Clear(this.matteColor);

            // Draw screen
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.matteTexture,      relativeMatte,              Color.White);
            this.spriteBatch.Draw(this.backgroundTexture, this.viewportTitleSafeArea, Color.White);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
