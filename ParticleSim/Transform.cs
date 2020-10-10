using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParticleSim
{
    class Transform
    {
        private Particle particle;
        public Vector2 position = new Vector2(0, 0);
        public Vector2 origin = new Vector2(0.5f, 0.5f);
        public float rotation = 0;
        public float scale = 1;
        public float width = 1;
        public float height = 1;
        public float radius = 0.5f;
        public Rectangle bounds = new Rectangle(0, 0, 1, 1);

        public Transform(Particle parent)
        {
            particle = parent;
        }

        public void SetScale(float scale)
        {
            this.scale = scale;
            width = scale;
            height = scale;
            radius = scale / 2;
            particle.collider.bounds.Width = (int)width;
            particle.collider.bounds.Height = (int)height;
            bounds.Width = (int)width;
            bounds.Height = (int)height;
        }

        public void SetScaleRandom(int max)
        {
            SetScale(Simulator.random.Next(1, max));
        }
    }
}
