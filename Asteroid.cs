using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Earth_defense
{
    public class SmallAsteroid : Sprite
    {
        Random r;
        public static Texture2D Texture;
        public SmallAsteroid()
        {
            r = new();
            this.Vector2 = new Vector2(r.Next(50, 850), 0);
            Console.WriteLine(Rotation);
        }

        public override void LoadContent(ContentManager Content)
        {
            SmallAsteroid.Texture = Content.Load<Texture2D>("asteroid1");
            Textures = new List<Texture2D>
            {
                Texture
            };
            Rect = new((int)Vector2.X, (int)Vector2.Y, 40, 40);
            base.LoadContent(Content);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites = null)
        {
            int restart;
            restart = r.Next(600, 1000);
            Vector2.Y += 5;
            if (Rect.Intersects(Cursor.Rect) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Vector2 = new Vector2(r.Next(50, 850), 0);
            }
            if (Vector2.Y > restart)
            {
                Vector2 = new Vector2(r.Next(50, 850), 0);
            }
            base.Update(gameTime, sprites);
        }
    }
}
