using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LeavesOnTrees
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int numbers;
        int numberOfLeaves = 65;
        SpriteFont testFont;
        public List<Leaf> leaves = new List<Leaf>();
        public List<TreePoint> treePoints = new List<TreePoint>();
        Tree myTree;
        int mode = 1;
        int tpcount;
        float timer;

        int finalscore;
 

        Texture2D endScreen;

        List<TreePoint> countList = new List<TreePoint>();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

             for (int i = 0; i < numberOfLeaves; i++)
            {
                Leaf myLeaf = new Leaf();
                leaves.Add(myLeaf);
             }

             for (int i = 0; i < numberOfLeaves; i++)
             {
                 TreePoint tp = new TreePoint();
                 treePoints.Add(tp);
             }         
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            this.IsMouseVisible = true;
            //ScreenManager.Instance.Initialize();

            //ScreenManager.Instance.dimensions = new Vector2(800, 600);
            //graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.dimensions.X;
            //graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.dimensions.Y;
            //graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            testFont = Content.Load<SpriteFont>("TestFont");
            endScreen = Content.Load<Texture2D>("end");

            foreach (Leaf l in leaves)
            {
                l.leafTex = Content.Load<Texture2D>("leaf1");
            }

            myTree = new Tree(Content,treePoints);

            //ScreenManager.Instance.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            foreach (Leaf l in leaves)
            {
                Wind.Blow(l);
            }

            foreach (Leaf l in leaves)
            {
                l.Update(gameTime);
            }


            numbers = Wind.blowStrength;
            
           
            gameLogic.Update(gameTime, leaves, treePoints);
            // TODO: Add your update logic here

            //countList.AddRange(from tp in myTree.numberOfCaughtPoints
            //                              where tp.isLeafOn == true
            //                              select tp);

            tpcount = myTree.numberOfCaughtPoints.Count(n => n.isLeafOn == true);

           
            //scoring mechanism, very messy
            if (tpcount > 35)
            {
                mode = 2;
            }

            timer = gameTime.TotalGameTime.Seconds;


            if (timer == 10)
            {
                finalscore += tpcount * 20;
                if (mode == 2)
                {
                    finalscore *= 3;
                }
            }

            if (timer == 20)
            {
                finalscore += tpcount * 10;
                if (mode == 2)
                {
                    finalscore *= 2;
                }
            }

            if (timer == 30)
            {
                finalscore += tpcount * 3;
                if (mode == 2)
                {
                    finalscore += 400;
                }
            }

          

            base.Update(gameTime);
        }

        //game score method
        



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

                // TODO: Add your drawing code here
                spriteBatch.Begin();

                Backgrounds.Draw(GraphicsDevice, Content, spriteBatch, mode);

                spriteBatch.DrawString(testFont, "Timer", new Vector2(50, 30), Color.Black);
                spriteBatch.DrawString(testFont, (30 - timer).ToString() , new Vector2(50, 50), Color.Black);

                

                myTree.Draw(spriteBatch, mode);

                foreach (Leaf leaf in leaves)
                {
                    leaf.Draw(spriteBatch);
                }


                if (timer > 30)
                {
                    spriteBatch.Draw(endScreen, endScreen.Bounds, Color.White);
                    spriteBatch.DrawString(testFont, "Final Score:", new Vector2(340, 210), Color.Black);
                    spriteBatch.DrawString(testFont, finalscore.ToString(), new Vector2(610, 210), Color.Black);
                }

           // ScreenManager.Instance.Draw(spriteBatch);

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
