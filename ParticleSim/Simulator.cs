using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParticleSim
{
    class Simulator : Microsoft.Xna.Framework.Game
    {
        public bool fullscreen = true;
        public bool useDefaultResolution = true;
        public static int width = 1920;
        public static int height = 1080;
        public int numberOfParticles = 750;
        public int numberOfLargeParticles = 6;
        public GraphicsDeviceManager graphics;
        private SpriteBatch batch;
        public Texture2D texture;
        public static List<Particle> particles = new List<Particle>();
        public static List<Particle> bigParticles = new List<Particle>();
        public static List<Particle> smallParticles = new List<Particle>();
        public static Random random = new Random();

        // Constructor
        public Simulator() : base()
        {
            // Set Display Properties
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = fullscreen;
            DisplayMode displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;

            if (useDefaultResolution)
            {
                width = displayMode.Width;
                height = displayMode.Height;
            }

            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.SynchronizeWithVerticalRetrace = true;
            graphics.PreferMultiSampling = true;
            graphics.HardwareModeSwitch = true;
            IsMouseVisible = true;
        }

        // Load Content
        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);

            // Set texture to solid white color
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });

            // Create particles
            for (int i = 0; i < numberOfParticles; i++)
            {
                Particle particle = new Particle();
                particle.transform.SetScaleRandom(32);
                particle.sprite.SetColorRandom();
                particle.collider.SetVelocityRandom(10);
                particle.collider.mass = 0.5f;
                //particle.collider.rotationalVelocity = random.Next(-1, 1);
                particle.collider.gravity.Y = 0.1f;
                particles.Add(particle);
                smallParticles.Add(particle);
            }

            for (int i = 0; i < numberOfLargeParticles; i++)
            {
                Particle bigParticle = new Particle();
                bigParticle.transform.SetScaleRandom(450);
                bigParticle.sprite.SetColorRandom();
                bigParticle.collider.SetVelocityRandom(10);
                //bigParticle.collider.rotationalVelocity = random.Next(-1, 1);
                bigParticle.collider.mass = 1;
                particles.Add(bigParticle);
                bigParticles.Add(bigParticle);
            }
        }

        // Update
        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Program.simulator.Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                for (int i = 0; i < particles.Count; i++)
                {
                    particles[i].collider.SetVelocityRandom(30);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                for (int i = 0; i < smallParticles.Count; i++)
                {
                    smallParticles[i].collider.velocity.Y -= 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                for (int i = 0; i < smallParticles.Count; i++)
                {
                    smallParticles[i].collider.velocity.Y += 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                for (int i = 0; i < smallParticles.Count; i++)
                {
                    smallParticles[i].collider.velocity.X -= 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                for (int i = 0; i < smallParticles.Count; i++)
                {
                    smallParticles[i].collider.velocity.X += 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                for (int i = 0; i < bigParticles.Count; i++)
                {
                    bigParticles[i].collider.velocity.Y -= 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                for (int i = 0; i < bigParticles.Count; i++)
                {
                    bigParticles[i].collider.velocity.Y += 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                for (int i = 0; i < bigParticles.Count; i++)
                {
                    bigParticles[i].collider.velocity.X -= 2.5f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                for (int i = 0; i < bigParticles.Count; i++)
                {
                    bigParticles[i].collider.velocity.X += 2.5f;
                }
            }
        }

        // Draw
        protected override void Draw(GameTime gameTime)
        {
            // Background Clear Color
            GraphicsDevice.Clear(Color.Black);

            // Sprite Batch
            batch.Begin();

            for (int i = 0; i < particles.Count; i++)
            {
                batch.Draw(particles[i].sprite.texture, particles[i].transform.position, particles[i].sprite.source, particles[i].sprite.color, 
                    particles[i].transform.rotation, particles[i].transform.origin, particles[i].transform.scale, SpriteEffects.None, 0);
            }
        
            batch.End();
        }
    }
}
