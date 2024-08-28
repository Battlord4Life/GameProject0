using InputExample;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

            _midgroundSprites.Add(new Torch( new Vector2(62, _graphics.GraphicsDevice.Viewport.Height - 250)));
            _midgroundSprites.Add(new Torch(new Vector2(_graphics.GraphicsDevice.Viewport.Width - 138, _graphics.GraphicsDevice.Viewport.Height - 250)));
            _foremidgroundSprites.Add(new Flame(new Vector2(50, 100), 50, false));
            _foremidgroundSprites.Add(new Flame(new Vector2(_graphics.GraphicsDevice.Viewport.Width - 150, 100), 50, true));
            _foregroundSprites.Add(new Title(new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2)-192, 50)));

            


            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if(_custBackground) _backgroundSprite.LoadContent(Content);
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


            if (_custBackground) _backgroundSprite.Update(gameTime);
            foreach (ISprite s in _backmidgroundSprites) s.Update(gameTime);
            foreach (ISprite s in _midgroundSprites) s.Update(gameTime);
            foreach (ISprite s in _foremidgroundSprites) s.Update(gameTime);
            foreach (ISprite s in _foregroundSprites) s.Update(gameTime);
            // TODO: Add your update logic here

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
            _spriteBatch.DrawString(Ariel, "ESC while you can", new Vector2((_graphics.GraphicsDevice.Viewport.Width / 2), _graphics.GraphicsDevice.Viewport.Height - 100), Color.White, 0, new Vector2(63,10), 3.5f, SpriteEffects.None, 0);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
