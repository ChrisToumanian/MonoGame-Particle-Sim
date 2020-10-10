using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleSim
{
    class Sprite
    {
        public Texture2D texture = Program.simulator.texture;
        public Color color = Color.White;
        public Rectangle source = new Rectangle(0, 0, 1, 1);

        public Sprite()
        {
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetColor(int r, int g, int b)
        {
            color.R = (byte) r;
            color.G = (byte) g;
            color.B = (byte) b;
        }

        public void SetColorRandom()
        {
            SetColor(Simulator.random.Next(255), Simulator.random.Next(255), Simulator.random.Next(255));
        }
    }
}
