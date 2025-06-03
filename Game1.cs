using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace summitive
{
    enum Screen
    {
        intro,scroll,End
    }
    public class Game1 : Game
    {

       


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont punkfont;
        
        List<Texture2D> frames;
        Rectangle window, backOne, backTwo,Eggrect,bananaRect,sonicRect;
        Texture2D streetTexture,End;
        int frame, backSpeed,Eggmanspeed,bananaspeed, fallspeed;
        float seconds;
        Screen screen;
        int streetscroll;
        MouseState mouseState;
        Texture2D sonicTexture,bananaTexture;
        Song Music,introMusic,endmusic;
        bool played;
        
        Texture2D EggmanTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        // frames are in order that they should be placed in 





        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            sonicRect = new Rectangle(50, 325, 150, 150);
            backSpeed = -10;
            backOne = window;
            backTwo = window;
            backTwo.X = window.Width; 
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            streetscroll = 0;
            frame = 0;
            seconds = 0;
            _graphics.ApplyChanges();
            screen = Screen.intro;
            Eggmanspeed = -5;
            bananaspeed = -5;
            fallspeed = 0;
            base.Initialize();

        }

        protected override void LoadContent()
        {
            streetTexture = Content.Load<Texture2D>("frame_000_delay-0.03s");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            frames = new List<Texture2D>();
            _spriteBatch = new SpriteBatch(GraphicsDevice);

          
            for (int i = 0; i < 30; i++)
            {
                if (i < 10)
                    frames.Add(Content.Load<Texture2D>("frame_0" + i + "_delay-0.08s"));
                else
                    frames.Add(Content.Load<Texture2D>("frame_" + i + "_delay-0.08s"));
                    
            }


            sonicTexture = Content.Load<Texture2D>("Sonic");
            Music = Content.Load<Song>("sonic music");
            EggmanTexture = Content.Load<Texture2D>("Eggman");
            Eggrect = new Rectangle(1250, 100, 200, 200);
            bananaTexture = Content.Load<Texture2D>("bananatexture");
            bananaRect = new Rectangle(1250,200, 175, 175);
            sonicRect = new Rectangle(50, 325, 150, 150);
            punkfont = Content.Load<SpriteFont>("punk text");
            mouseState = Mouse.GetState();
            End = Content.Load<Texture2D>("endscreen");
            endmusic = Content.Load<Song>("endmusic");

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (screen == Screen.intro)
            {
               
                if (seconds > 0.035)
                {
                    frame++;
                    if (frame > 29)
                        frame = 0;
                    seconds = 0;

                }
                mouseState = Mouse.GetState();
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.scroll;
                    MediaPlayer.Play(Music);
          

                }
            }
            
            else if (screen == Screen.scroll)
            {
                backOne.X += backSpeed;
                backTwo.X += backSpeed;
                Eggrect.X += Eggmanspeed;
                bananaRect.X += bananaspeed;
                bananaRect.Y -= fallspeed;

                if (backTwo.X == 0)
                {

                    backTwo.X = window.Width;
                    if (backTwo.X == window.Width)
                    {
                        backOne = window;
                        
                    }
                }

                if (Eggrect.X < window.Width - EggmanTexture.Width)
                {
                    
                    Eggmanspeed = 0;
                    fallspeed = -2;
                    if (bananaRect.Bottom > sonicRect.Bottom)
                    {
                        fallspeed = 0;                       
                    }                  
                }
                if (bananaRect.X <= sonicRect.X)
                {
                    screen = Screen.End;
                    MediaPlayer.Play(endmusic);
                }
            }       

            
            
            // TODO: Add your update logic here
            

            if (seconds > 0.035)
            {
                streetscroll++;
                if (streetscroll > 119)
                    streetscroll = 0;
                seconds = 0;

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.intro)
            {
                _spriteBatch.Draw(frames[frame], window, Color.White);
                _spriteBatch.DrawString(punkfont, (10 - seconds).ToString("press left click to continue"), new Vector2(140, 500), Color.Black);
            }
            else if (screen == Screen.scroll)
            {
                _spriteBatch.Draw(streetTexture, backOne, Color.White);
                _spriteBatch.Draw(streetTexture, backTwo, Color.White);
                _spriteBatch.Draw(sonicTexture,sonicRect , Color.White);
                _spriteBatch.Draw(EggmanTexture,Eggrect,Color.White);
                _spriteBatch.Draw(bananaTexture,bananaRect, Color.White);
            }
            if (screen == Screen.End)
            {
                _spriteBatch.Draw(End, window, Color.White);
                _spriteBatch.DrawString(punkfont, (10 - seconds).ToString("Sonic is dead"), new Vector2(300, 100), Color.Black);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }       
}
