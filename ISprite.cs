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
    public interface ISprite
    {

        /// <summary>
        /// Loads Sprites Content
        /// </summary>
        /// <param name="content">Content Manager</param>
        public void LoadContent(ContentManager content);

        /// <summary>
        /// What happens each frame
        /// </summary>
        /// <param name="gameTime">Time in the Game</param>
        public void Update(GameTime gameTime);

        /// <summary>
        /// What Gets Drawn
        /// </summary>
        /// <param name="gameTime">GameTime</param>
        /// <param name="spriteBatch">Sprite Batch</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    }
        
}
