using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace FlappyBird
{
    static class SpriteSheet
    {
        static public void Draw(Texture2D getTexture2D, SpriteBatch sB, Rectangle getSource, Vector2 getPosition, float getRotation)
        {
            Rectangle Destination = new Rectangle((int)getPosition.X, (int)getPosition.Y, getSource.Width * 480 / 140, getSource.Height * 640 / 220);
            sB.Draw(getTexture2D, Destination, getSource, Color.White, getRotation, new Vector2(getSource.Width / 2, getSource.Height / 2), SpriteEffects.None, 0);
        }
    }
}
