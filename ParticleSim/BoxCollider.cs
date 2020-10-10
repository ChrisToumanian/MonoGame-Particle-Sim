using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParticleSim
{
    class BoxCollider : Collider
    {
        public BoxCollider(Particle parent)
        {
            this.parent = parent;
            this.transform = parent.transform;
        }

        public override void Update()
        {
            transform.rotation += rotationalVelocity;
            Move();
            velocity.Y += gravity.Y;
            velocity.X += gravity.X;
            if (borderCollisionEnabled) CheckBorderCollision();
            if (enabled) CheckParticleCollision();
        }

        public void CheckParticleCollision()
        {
            for (int i = 0; i < Simulator.particles.Count; i++)
            {
                if (parent.transform.bounds.Intersects(Simulator.particles[i].transform.bounds))
                {
                    Vector2 move = MoveOff(parent.transform.bounds, Simulator.particles[i].transform.bounds);
                    Move(move);

                    if (move.X > 0) velocity.X *= -bounce + mass;
                    if (move.X < 0) velocity.X *= -bounce + mass;
                    if (move.Y > 0) velocity.Y *= -bounce + mass;
                    if (move.Y < 0) velocity.Y *= -bounce + mass;

                    if (move.X > 0) Simulator.particles[i].collider.velocity.X *= bounce + mass;
                    if (move.X < 0) Simulator.particles[i].collider.velocity.X *= bounce + mass;
                    if (move.Y > 0) Simulator.particles[i].collider.velocity.Y *= bounce + mass;
                    if (move.Y < 0) Simulator.particles[i].collider.velocity.Y *= bounce + mass;
                }
            }
        }

        public static Vector2 MoveOff(Rectangle c, Rectangle b)
        {
            Vector2 move = new Vector2(0, 0);
            Rectangle a = new Rectangle(c.X, c.Y, c.Width, c.Height);
            int deltaLeft = 0;
            int deltaRight = 0;
            int deltaUp = 0;
            int deltaDown = 0;

            deltaLeft = Math.Abs(b.Left - a.Right);
            deltaRight = Math.Abs(b.Right - a.Left);
            deltaUp = Math.Abs(b.Top - a.Bottom);
            deltaDown = Math.Abs(b.Bottom - a.Top);

            if (deltaLeft < deltaRight && deltaLeft < deltaUp && deltaLeft < deltaDown)
            {
                move.X = -deltaLeft;
            }
            else if (deltaRight < deltaLeft && deltaRight < deltaUp && deltaRight < deltaDown)
            {
                move.X = deltaRight;
            }
            else if (deltaDown < deltaUp && deltaDown < deltaRight && deltaDown < deltaLeft)
            {
                move.Y = deltaDown;
            }
            else if (deltaUp < deltaDown && deltaUp < deltaRight && deltaUp < deltaLeft)
            {
                move.Y = -deltaUp;
            }

            return move;
        }
    }
}
