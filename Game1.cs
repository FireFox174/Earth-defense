using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft;

namespace Earth_defense
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch Surface;
        public static GameTime GameTime;
        public SmallAsteroid asteroid;
        Cursor Cursor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            asteroid = new SmallAsteroid();
            Cursor = new();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Surface = new SpriteBatch(GraphicsDevice);
            Cursor.LoadContent(Content);
            asteroid.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Cursor.Update(gameTime);
            asteroid.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Surface.Begin();
            Surface.Draw(SmallAsteroid.Texture, asteroid.Rect, Color.White);
            Cursor.Draw(Surface);
            Surface.End();
            base.Draw(gameTime);
        }
    }
}
