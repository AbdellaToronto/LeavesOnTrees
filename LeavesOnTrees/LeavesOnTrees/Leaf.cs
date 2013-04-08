using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LeavesOnTrees
{
    public class Leaf
    {
        
        int size;
        int weight; //specifies the fall speed of an object, and its susceptibility to wind
        public Rectangle drawPos;
        int zIndex;
        string[] leafImgs = new string[4];
        Color[] leafColours = new Color[]{Color.BlanchedAlmond,Color.BurlyWood,Color.RosyBrown, Color.Tan};//colour options
        Color myColour;
        public Texture2D leafTex;
        static Random random = new Random();
        double elapsedTime;
        int randomMove;
        public Rectangle collisionBox; //Location of the box for wind interaction

        int leafXPos = random.Next(20, 750);
        int leafYPos = random.Next(350, 400);

        public bool isOnTree = false;

        public Leaf()
        {
            size = random.Next(1,3);
            weight = random.Next(1, 3);
            zIndex = random.Next(1, 4);
            myColour = leafColours[random.Next(0, 3)];
            drawPos = new Rectangle(leafXPos, leafYPos, 30, 30);
            weight = random.Next(1, 3);

            
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            randomMove = random.Next(-6, 6);
            collisionBox = new Rectangle(drawPos.Left - 45, drawPos.Top - 25, 120, 100);

            if (elapsedTime >= 0.1 && drawPos.Y < 435 && isOnTree == false)
            {
                drawPos.Y += 1*weight;
               
                if (drawPos.X < 795 && drawPos.X > 5)
                {
                    drawPos.X += 1 * randomMove;
                }

                elapsedTime -= 0.1;
            }

          


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isOnTree == false)
            {
                spriteBatch.Draw(leafTex, drawPos, myColour);
            }
            else
            {
                spriteBatch.Draw(leafTex, drawPos, Color.Lerp(myColour,Color.LawnGreen,0.3f));
            }
        }

    }
}