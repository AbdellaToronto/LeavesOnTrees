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
    class Tree
    {
        Rectangle treeLocation;
        //int numberOfPoints = 65; //represents the amount locations on a tree where a point of connection exists
        Texture2D treeTex;
        float treeSizeMod = 0.7f;
        public List<TreePoint> numberOfCaughtPoints;

        static Random random = new Random();



        void randomPointGen(int numberofpoints, List<TreePoint> treePoints)//generates points for the tree
        {
            for(int i = 0; i < numberofpoints; i++)
            {
                TreePoint tP = new TreePoint();

                tP.treePoint = new Point(random.Next(treeLocation.Left + 5, treeLocation.Right - 5), 
                    random.Next(treeLocation.Top - 15,treeLocation.Bottom - 150));

                treePoints.Add(tP);
            }
        }


        public Tree(ContentManager Content, List<TreePoint> treePoints)
        {
            treeTex = Content.Load<Texture2D>("Tree");
            treeLocation = new Rectangle(180, 20, Convert.ToInt32(treeTex.Width* treeSizeMod), Convert.ToInt32(treeTex.Height* treeSizeMod));

            randomPointGen(65, treePoints);

            numberOfCaughtPoints = treePoints;
                
        }

        

        public void Draw(SpriteBatch spriteBatch, int mode)
        {
            if (mode == 1)
            {
                spriteBatch.Draw(treeTex, treeLocation, Color.Gray);
            }
            else if (mode == 2)
            {
                spriteBatch.Draw(treeTex, treeLocation, Color.SaddleBrown);
            }
        }

    }
}
