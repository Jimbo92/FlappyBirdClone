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
    class Pipes
    {
        Texture2D CollisionBoxTexture;

        public Rectangle CollisionBoxTop;
        public Rectangle CollisionBoxBottom;
        public Vector2 Position = new Vector2(580, 0);
        public bool isAlive = true;
        int RandYPosValue;

        public void LoadContent(ContentManager Content)
        {
            CollisionBoxTexture = Content.Load<Texture2D>("collisionbox");
        }

        public void Draw(Texture2D getTexture, SpriteBatch sB, float getXposOffset)
        {
            if (isAlive)
            Position.X -= 3;   

            if (Position.X < -100 - getXposOffset)
            {
                Random RandYPos = new Random();
                RandYPosValue = RandYPos.Next(-50, 150);

                Position.X = 800 - getXposOffset;
            }

            CollisionBoxTop = new Rectangle((int)Position.X + (int)getXposOffset - 78 / 2, RandYPosValue - 370 / 2, 78, 370);
            CollisionBoxBottom = new Rectangle((int)Position.X + (int)getXposOffset - 78 / 2, RandYPosValue + 480 - 320 / 2, 78, 320);

            SpriteSheet.Draw(getTexture, sB, new Rectangle(302, 0, 26, 136), new Vector2(Position.X + getXposOffset, RandYPosValue), 0);
            SpriteSheet.Draw(getTexture, sB, new Rectangle(330, 0, 26, 119), new Vector2(Position.X + getXposOffset, RandYPosValue + 480), 0);

            //sB.Draw(CollisionBoxTexture, CollisionBoxBottom, Color.White);
            //sB.Draw(CollisionBoxTexture, CollisionBoxTop, Color.White);

        }
    }
}
