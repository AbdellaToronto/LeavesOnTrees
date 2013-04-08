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
    static class Wind
    {
        public static int blowStrength = 0;

        public static void Blow(Leaf leaf)
        {
            Rectangle mousePos = new Rectangle(Mouse.GetState().X,Mouse.GetState().Y,0,0);
            
            if (blowStrength < 5)
            {
                blowStrength = Mouse.GetState().ScrollWheelValue / 120;
            }

           

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && // if mouse is 
                leaf.collisionBox.Contains(mousePos) &&
                leaf.isOnTree == false)
            {
                //if the mouse is below the leaves, blow up/left/right
                if (leaf.drawPos.Y < Mouse.GetState().Y) 
                {
                    leaf.drawPos.Y -= blowStrength;
                }
                if (leaf.drawPos.X < Mouse.GetState().X)
                {
                    leaf.drawPos.X -= blowStrength;
                }
                if (leaf.drawPos.X > Mouse.GetState().X)
                {
                    leaf.drawPos.X += blowStrength;
                }

                //prevents from going off screen
                if (leaf.drawPos.X < 5)
                {
                    leaf.drawPos.X += blowStrength;
                }
                if (leaf.drawPos.X > 785)
                {
                    leaf.drawPos.X -= blowStrength;
                }
                if (leaf.drawPos.Y < 5)
                {
                    leaf.drawPos.Y += blowStrength;
                }
                if (leaf.drawPos.Y > 395)
                {
                    leaf.drawPos.Y -= blowStrength;
                }


                //if(Mouse.GetState().Y < leaf.drawPos.Y && leaf.drawPos == )
            }
        }
    }
}
