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
        private Texture2D             matteTexture;

        public FirstXboxGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Save screen info
            var view = DisplayInformation.GetForCurrentView();

            this.resolution   = new Size(view.ScreenWidthInRawPixels, view.ScreenHeightInRawPixels);
            this.screenBounds = new Rectangle(0, 0, (int) this.resolution.Width, (int) this.resolution.Height);

            // Background Texture
            this.matteColor = Color.DarkOliveGreen;

            var textureData = new Color[1];
            textureData[0] = this.matteColor;

            this.matteTexture = new Texture2D(this.GraphicsDevice, 1, 1);
            this.matteTexture.SetData(textureData);

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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Get Viewport bounds
            this.viewportBounds        = this.GraphicsDevice.Viewport.Bounds;
            this.viewportTitleSafeArea = this.GraphicsDevice.Viewport.TitleSafeArea;

            // Clear the viewport with matte color
            this.GraphicsDevice.Clear(this.matteColor);

            // Draw screen
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.matteTexture, this.screenBounds, Color.White);
            this.spriteBatch.Draw(this.matteTexture, this.viewportTitleSafeArea, Color.White);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
