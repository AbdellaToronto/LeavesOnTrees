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
    public static class Backgrounds
    {

        public static void Draw(GraphicsDevice GD, ContentManager Content, SpriteBatch spriteBatch, int mode)
        {
            Rectangle backGround1Loc = GD.Viewport.Bounds;
            Texture2D background1Tex = Content.Load<Texture2D>("Background1");

            Texture2D groundTex = Content.Load<Texture2D>("ground");
            Rectangle groundLoc = new Rectangle(GD.Viewport.X, GD.Viewport.Y + 300, GD.Viewport.Width, 400);
            
            Color groundColor = Color.White;
            Color skyColor = Color.White;

            

            if (mode == 1)
            {
                groundColor = Color.SandyBrown;
            }
            else if (mode == 2)
            {
                groundColor = Color.White;
                skyColor = Color.DeepSkyBlue;
            }

            spriteBatch.Draw(background1Tex, backGround1Loc, skyColor);

            spriteBatch.Draw(groundTex, backGround1Loc, groundColor);


        }

    }
}
