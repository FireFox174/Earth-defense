using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Earth_defense
{
    public class Delay
    {
        public double Timer = 0.0;
        public double DelayTime = 0.0;

        public Delay(double DelayTime)
        {
            this.DelayTime = DelayTime;
        }

        public bool Wait()
        {
            if (this.Timer <= Game1.GameTime.TotalGameTime.TotalMilliseconds)
            {
                Timer = Game1.GameTime.TotalGameTime.TotalMilliseconds + DelayTime;
                return false;
            }
            return true;
        }
    }

    public interface IAnimator
    {
        public Texture2D[] Textures { get { return new Texture2D[999]; } set { } }
        public Vector2 FrameSize { get { return new Vector2(); } set { } }
        public float Delay { get { return 1; } set { } }
        public Texture2D SpriteSheet {  get { return Textures[0]; } set {  } }
        public Rectangle Frame 
        {
            get { return new Rectangle(); }
            set { }
        }

        public void AnimatedSpriteSheet()
        {
            var frame = Frame;
            if (SpriteSheet != null)
            {
                if (new Delay(this.Delay).Wait())
                {
                    if (FrameSize.X < SpriteSheet.Width) frame.X += (int)FrameSize.X;
                    if (FrameSize.Y < SpriteSheet.Height) frame.Y += (int)FrameSize.Y;
                }
                Frame = frame;
            }
        }
    }
}
