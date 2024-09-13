using InputExample;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;

namespace GameProject0
{
    public class DarknessDwellers : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private InputManager _inputManager;

        private ISprite _backgroundSprite;

        private List<ISprite> _backmidgroundSprites;

        private List<ISprite> _midgroundSprites;

        private List<ISprite> _foremidgroundSprites;

        private List<ISprite> _foregroundSprites;

        private SpriteFont Ariel;

        private bool _custBackground = true;

        private int _level = 0;

        private int HeroHealth = 3;

        private float _DamageTimer = 0;




        public DarknessDwellers()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _backmidgroundSprites = new();
            _midgroundSprites = new();
            _foremidgroundSprites = new();
            _foregroundSprites = new();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            _inputManager = new();

            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 750;
            _graphics.ApplyChanges();

            _backgroundSprite = new Background(new Vector2(0, 0));

            _midgroundSprites.Add(new Torch(new Vector2(62, _graphics.GraphicsDevice.Viewport.Height - 250)));
            _midgroundSprites.Add(new Torch(new Vector2(_graphics.GraphicsDevice.Viewport.Width - 138, _graphics.GraphicsDevice.Viewport.Height - 250)));
            _foremidgroundSprites.Add(new Flame(new Vector2(50, 100), 50, false));
            _foremidgroundSprites.Add(new Flame(new Vector2(_graphics.GraphicsDevice.Viewport.Width - 150, 100), 50, true));
            _foregroundSprites.Add(new Title(new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2) - 192, 50)));




            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if (_custBackground) _backgroundSprite.LoadContent(Content);
            foreach (ISprite s in _backmidgroundSprites) s.LoadContent(Content);
            foreach (ISprite s in _midgroundSprites) s.LoadContent(Content);
            foreach (ISprite s in _foremidgroundSprites) s.LoadContent(Content);
            foreach (ISprite s in _foregroundSprites) s.LoadContent(Content);
            Ariel = Content.Load<SpriteFont>("File");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
            if (_inputManager.Exit) Exit();

            if (_inputManager.Jump && _level == 0)
            {

                _level = 1;
                _backmidgroundSprites = new();
                _midgroundSprites = new();
                _foregroundSprites = new();
                _foremidgroundSprites = new();

                _foremidgroundSprites.Add(new Hero(new Vector2(_graphics.GraphicsDevice.Viewport.Width/2, _graphics.GraphicsDevice.Viewport.Height / 2), _inputManager));
                _foremidgroundSprites.Add(new Flame(new Vector2(50, _graphics.GraphicsDevice.Viewport.Height / 2), _graphics.GraphicsDevice.Viewport.Height / 2, false));
                _foremidgroundSprites.Add(new Flame(new Vector2(_graphics.GraphicsDevice.Viewport.Width - 150, _graphics.GraphicsDevice.Viewport.Height / 2), _graphics.GraphicsDevice.Viewport.Height / 2, true));


                LoadContent();

            }


            if (_custBackground) _backgroundSprite.Update(gameTime);
            foreach (ISprite s in _backmidgroundSprites) s.Update(gameTime);
            foreach (ISprite s in _midgroundSprites) s.Update(gameTime);
            foreach (ISprite s in _foremidgroundSprites) s.Update(gameTime);
            foreach (ISprite s in _foregroundSprites) s.Update(gameTime);
            // TODO: Add your update logic here

            CollisionChecker(_foremidgroundSprites, gameTime);

            if (HeroHealth <= 0) _inputManager.Active = false; 

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (_custBackground) _backgroundSprite.Draw(gameTime, _spriteBatch);
            foreach (ISprite s in _backmidgroundSprites) s.Draw(gameTime, _spriteBatch);
            foreach (ISprite s in _midgroundSprites) s.Draw(gameTime, _spriteBatch);
            foreach (ISprite s in _foremidgroundSprites) s.Draw(gameTime, _spriteBatch);
            foreach (ISprite s in _foregroundSprites) s.Draw(gameTime, _spriteBatch);
            if (_level == 0)
            {
                _spriteBatch.DrawString(Ariel, "Procede To SPACE", new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2), _graphics.GraphicsDevice.Viewport.Height - 200), Color.White, 0, new Vector2(63, 10), 3.5f, SpriteEffects.None, 0);
                _spriteBatch.DrawString(Ariel, "ESC while you can", new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2), _graphics.GraphicsDevice.Viewport.Height - 100), Color.White, 0, new Vector2(63, 10), 3.5f, SpriteEffects.None, 0);
                
            }
            if(_level == 1)
            {
                _spriteBatch.DrawString(Ariel, "Test Damage", new Vector2(0,0), Color.White, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
                _spriteBatch.DrawString(Ariel, HeroHealth.ToString() + "/3", new Vector2(0, 20), Color.White, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
                _spriteBatch.DrawString(Ariel, ((float)(Math.Max(0, _DamageTimer - gameTime.TotalGameTime.TotalSeconds))).ToString(), new Vector2(0, 40), Color.White, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);

                if(HeroHealth <= 0)
                {
                    _spriteBatch.DrawString(Ariel, "You Are Dead!", new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2), _graphics.GraphicsDevice.Viewport.Height - 200), Color.White, 0, new Vector2(63, 10), 3.5f, SpriteEffects.None, 0);
                    _spriteBatch.DrawString(Ariel, "ESC while you can!", new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2), _graphics.GraphicsDevice.Viewport.Height - 100), Color.White, 0, new Vector2(63, 10), 3.5f, SpriteEffects.None, 0);
                }
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void CollisionChecker (List<ISprite> Collection, GameTime gameTime)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                for (int j = i + 1; j < Collection.Count; j++)
                {
                    if (Collection[i].Collides(Collection[j]))
                    {

                        if (_level == 1 && ((Collection[i].Name == "Hero" || Collection[j].Name == "Hero") && (Collection[i].Name == "Flame" || Collection[j].Name == "Flame"))){

                            if(_DamageTimer <= gameTime.TotalGameTime.TotalSeconds)
                            {
                                HeroHealth--;
                                _DamageTimer = (float)gameTime.TotalGameTime.TotalSeconds + 5f;
                            }

                        }

                    }
                }
            }
        }
    }
}
