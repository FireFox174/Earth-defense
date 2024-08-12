using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
// Comment

namespace Earth_defense
{
    public class Sprite
    {
        public List<Texture2D> Textures;
        
        private int currentImage = 0;

        private Rectangle frame;

        public float Rotation = 0;

        public Vector2 Vector2;

        public bool Dead = false;

        public Rectangle Rect;

        public virtual void Update(GameTime gameTime, List<Sprite> sprites = null)
        {
            if (!Rect.IsEmpty)
            {
                Rect.X = (int)Vector2.X;
                Rect.Y = (int)Vector2.Y;
            }
            if (sprites != null && sprites.Contains(this) && Dead)
            {
                sprites.Remove(this);
            }
        }

        public virtual void LoadContent(ContentManager Content)
        {
            
        }

        public virtual void Draw(SpriteBatch Surface)
        {
            if (Textures != null)Surface.Draw(Textures[currentImage], Rect, frame, Color.White, Rotation, Vector2, 0, 1);
        }
    }

    public class Cursor
    {
        Texture2D MouseTexture;

        public static Rectangle Rect;

        public Cursor()
        {
            Rect = new(Mouse.GetState().X - 6, Mouse.GetState().Y - 6, 12, 12);
        }

        public void Update(GameTime gameTime)
        {
            Rect.X = Mouse.GetState().X - 6;
            Rect.Y = Mouse.GetState().Y - 6;
        }

        public void LoadContent(ContentManager Content)
        {
            MouseTexture = Content.Load<Texture2D>("cursor");
        }

        public void Draw(SpriteBatch Surface)
        {
            Surface.Draw(MouseTexture,
            destinationRectangle: new Rectangle(Mouse.GetState().X - 8, Mouse.GetState().Y - 8, 32, 32),
            sourceRectangle: new Rectangle(0, 0, 16, 16),
            Color.White);
        }
    }

    public class Explosion : Sprite
    {
        public Explosion(Vector2 vector, Texture2D texture)
        {
            Vector2 = vector;
            Textures[0] = texture;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites = null)
        {
            
            if (sprites != null && sprites.Contains(this))
            {
                foreach (Sprite sprite in sprites.ToList())
                {
                    if (Rect.Intersects(sprite.Rect)) sprite.Dead = true;
                    new Delay(2).Wait();
                    Dead = true;
                }
            }
            base.Update(gameTime, sprites);
        }
    }
}
