﻿using CollisionExample.Collisons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject0
{
    public class Torch : ISprite
    {
        //The Torch texture 
        private Texture2D _texture;

        ///<summary>
        /// The Torches position in the world
        ///</summary>
        public Vector2 Position { get; private set; }
        
        public BoundingRectangle Bounds => new(0, 0, 0, 0);

        public string Name => "Torch";

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("TorchSprite");
        }

        public void Update(GameTime gameTime)
        {

        }

        public bool Collides(ISprite other)
        {
            return false;
        }

        public Torch(Vector2 Pos)
        {
            Position = Pos;
        }
    }
}
