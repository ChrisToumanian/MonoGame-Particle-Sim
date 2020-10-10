using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParticleSim
{
    class Collider
    {
        public bool enabled = true;
        public bool borderCollisionEnabled = true;
        public Vector2 velocity = new Vector2(0, 0);
        public float maxVelocity = 10;
        public float bounce = 1;
        public float mass = 0;
        public float rotationalVelocity = 0;
        public Vector2 gravity = new Vector2(0, 0);
        public Rectangle bounds = new Rectangle(0, 0, 1, 1);
        protected Transform transform;
        protected Particle parent;

        public Collider()
        {
        }

        public virtual void Update()
        {
        }

        public void SetVelocity(float x, float y)
        {
            if (x > -maxVelocity && x < maxVelocity) velocity.X = x;
            else if (x < -maxVelocity) velocity.X = -maxVelocity;
            else if (x > maxVelocity) velocity.X = maxVelocity;

            if (y > -maxVelocity && y < maxVelocity) velocity.Y = y;
            else if (y < -maxVelocity) velocity.Y = -maxVelocity;
            else if (y > maxVelocity) velocity.Y = maxVelocity;
        }

        protected void Move()
        {
            transform.position.X += velocity.X;
            transform.position.Y += velocity.Y;
            transform.bounds.X = (int)transform.position.X - (int)transform.radius;
            transform.bounds.Y = (int)transform.position.Y - (int)transform.radius;
        }

        protected void Move(Vector2 move)
        {
            transform.position.X += move.X;
            transform.position.Y += move.Y;
            transform.bounds.X = (int)transform.position.X - (int)transform.radius;
            transform.bounds.Y = (int)transform.position.Y - (int)transform.radius;
        }

        protected void CheckBorderCollision()
        {
            if (transform.position.X < transform.radius)
            {
                velocity.X *= -1;
                velocity *= bounce;
                transform.position.X = transform.radius;
            }
            else if (transform.position.X > Simulator.width - transform.radius)
            {
                velocity.X *= -1;
                velocity *= bounce;
                transform.position.X = Simulator.width - transform.radius;
            }

            if (transform.position.Y < transform.radius)
            {
                velocity.Y *= -1;
                velocity *= bounce;
                transform.position.Y = transform.radius;
            }
            else if (transform.position.Y > Simulator.height - transform.radius)
            {
                velocity.Y *= -1;
                velocity *= bounce;
                transform.position.Y = Simulator.height - transform.radius;
            }
        }

        public void SetVelocityRandom(int max)
        {
            SetVelocity(Simulator.random.Next(-max, max), Simulator.random.Next(-max, max));
        }

        public List<Particle> GetParticlesWithin(int distance)
        {
            List<Particle> particles = new List<Particle>();
            for (int i = 0; i < Simulator.particles.Count; i++)
            {
                if (distance > Vector2.Distance(transform.position, Simulator.particles[i].transform.position))
                {
                    particles.Add(Simulator.particles[i]);
                }
            }
            return particles;
        }
    }
}
