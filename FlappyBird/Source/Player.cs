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
    class Player
    {
        Vector2 Position = new Vector2(200, 240);

        float Gravity;

        float rotation;

        public Rectangle CollisionBox;

        public bool isAlive = true;
        public bool ControlsEnabled = false;

        private int Anim;
        private int AnimDelay;

        KeyboardState prevKeyboard = Keyboard.GetState();


        public void Update(Background getBackground)
        {
            if (isAlive)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && prevKeyboard.IsKeyUp(Keys.Up))
                {
                    Gravity = -7;
                    if (!ControlsEnabled)
                        ControlsEnabled = true;
                }
                prevKeyboard = Keyboard.GetState();

                if (ControlsEnabled)
                {
                    if (Gravity < 15)
                        Gravity += 0.28f;
                    else
                        Gravity = 15;

                    if (Gravity > 0)
                        rotation += 6;
                    else
                        rotation -= 10;

                    if (rotation >= 60)
                        rotation = 60;
                    else if (rotation <= -25)
                        rotation = -25;
                }

                //Collisions
                if (CollisionBox.Intersects(getBackground.CollsionBox))
                    isAlive = false;
            }
            else
            {
                if (CollisionBox.Intersects(getBackground.CollsionBox))
                    Gravity = 0;
                else
                {
                    Gravity += 0.6f;

                    if (Gravity > 0)
                        rotation += 6;
                    else
                        rotation -= 10;

                    if (rotation >= 75)
                        rotation = 75;
                    else if (rotation <= -25)
                        rotation = -25;
                }
                getBackground.isAlive = false;
            }

            if (ControlsEnabled)
                Position.Y += Gravity;

        }

        public void Draw(Texture2D getTexture, SpriteBatch sB)
        {
            CollisionBox = new Rectangle((int)Position.X - 10 / 2, (int)Position.Y - 10 / 2, 10, 10);

            if (isAlive)
            {
                AnimDelay++;
                if (AnimDelay >= 5)
                {
                    Anim++;
                    AnimDelay = 0;
                }
                if (Anim >= 4)
                    Anim = 0;
                switch (Anim)
                {
                    case 0: SpriteSheet.Draw(getTexture, sB, new Rectangle(264, 64, 17, 12), Position, MathHelper.ToRadians(rotation)); break;
                    case 1: SpriteSheet.Draw(getTexture, sB, new Rectangle(264, 90, 17, 12), Position, MathHelper.ToRadians(rotation)); break;
                    case 2: SpriteSheet.Draw(getTexture, sB, new Rectangle(223, 124, 17, 12), Position, MathHelper.ToRadians(rotation)); break;
                    case 3: SpriteSheet.Draw(getTexture, sB, new Rectangle(264, 90, 17, 12), Position, MathHelper.ToRadians(rotation)); break;
                }
            }
            else
                SpriteSheet.Draw(getTexture, sB, new Rectangle(223, 124, 17, 12), Position, MathHelper.ToRadians(rotation));

        }
    }
}
