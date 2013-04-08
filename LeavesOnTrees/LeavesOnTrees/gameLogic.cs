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
    static class gameLogic
    {

        public static void Update(GameTime gameTime, List<Leaf> leaves, List<TreePoint> tPs)
        {
            foreach (Leaf L in leaves)
            {
                foreach(TreePoint tp in tPs)
                {
                    if (L.collisionBox.Contains(tp.treePoint) && tp.isLeafOn == false)
                    {
                        tp.isLeafOn = true;
                        L.isOnTree = true;

                        
                    }
                }
            }
        }
    }
}
