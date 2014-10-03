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
    class Background
    {
        public float Scroll_X;

        public Rectangle CollsionBox;

        public bool isAlive = true;

        public Pipes[] pipes = new Pipes[3];

        public void LoadContent(ContentManager getContent)
        {
            for (int i = 0; i < 3; i++)
            {
                pipes[i] = new Pipes();
                pipes[i].LoadContent(getContent);
            }

        }

        public void Draw(Texture2D getTexture, SpriteBatch sB, Vector2 getScreenSize, Player getPlayer)
        {
            CollsionBox = new Rectangle((int)(getScreenSize.X / 2) - (480 / 2), (int)getScreenSize.Y - (240 / 2), 480, 240);

            if (isAlive)
            {
                Scroll_X -= 3f;
                if (Scroll_X < -480)
                    Scroll_X = 0;
            }

            foreach (Pipes pipe in pipes)
                if (getPlayer.CollisionBox.Intersects(pipe.CollisionBoxBottom) || getPlayer.CollisionBox.Intersects(pipe.CollisionBoxTop) || !getPlayer.isAlive)
                {
                    getPlayer.isAlive = false;
                    pipes[0].isAlive = false;
                    pipes[1].isAlive = false;
                    pipes[2].isAlive = false;
                }

            //Background
            SpriteSheet.Draw(getTexture, sB, new Rectangle(0, 0, 144, 256), new Vector2(240 + Scroll_X, getScreenSize.Y / 2), 0);
            SpriteSheet.Draw(getTexture, sB, new Rectangle(0, 0, 144, 256), new Vector2((240 + Scroll_X) + 480, getScreenSize.Y / 2), 0);

            //Pipes
            if (getPlayer.ControlsEnabled)
            {
                pipes[0].Draw(getTexture, sB, 0);
                pipes[1].Draw(getTexture, sB, 300);
                pipes[2].Draw(getTexture, sB, 600);
            }

            //Foreground
            SpriteSheet.Draw(getTexture, sB, new Rectangle(147, 0, 144, 56), new Vector2(240 + Scroll_X, getScreenSize.Y), 0);
            SpriteSheet.Draw(getTexture, sB, new Rectangle(147, 0, 144, 56), new Vector2((240 + Scroll_X) + 480, getScreenSize.Y), 0);

            //Menu
            if (!getPlayer.ControlsEnabled)
                SpriteSheet.Draw(getTexture, sB, new Rectangle(145, 172, 98, 23), new Vector2(getScreenSize.X / 2, getScreenSize.Y / 6), 0);

            if (!getPlayer.isAlive)
                SpriteSheet.Draw(getTexture, sB, new Rectangle(145, 198, 95, 20), new Vector2(getScreenSize.X / 2, getScreenSize.Y / 6), 0);

        }
    }
}
