using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleSim
{
    class Particle
    {
        public Transform transform;
        public Sprite sprite = new Sprite();
        public Collider collider;

        public Particle()
        {
            transform = new Transform(this);
            transform.position.X = Simulator.random.Next(Simulator.width);
            transform.position.Y = Simulator.random.Next(Simulator.height);
            collider = new BoxCollider(this);
            collider.bounce = 0.95f;
        }

        public void Update()
        {
            collider.Update();
        }
    }
}
