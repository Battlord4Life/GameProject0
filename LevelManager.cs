using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject0
{
    public class LevelManager
    {

        public ISprite BackgroundSprite;

        public List<ISprite> BackmidgroundSprites;

        public List<ISprite> MidgroundSprites;

        public List<ISprite> ForemidgroundSprites;

        public List<ISprite> ForegroundSprites;

        public SpriteFont Ariel;

        public int Level = 0;

        public bool ChangeLevel = false;

        public void ChangeCurLevel(int level)
        {
            Level = level;

        }






    }
}
