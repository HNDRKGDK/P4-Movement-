using System;
using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
    class AcceleratingBall : SpriteNode
    {
        // your private fields here (add Velocity, Acceleration, and MaxSpeed)
        private Vector2 Velocity = new Vector2(0, 0);
        private Vector2 Acceleration = new Vector2(0, 0);
        private float MaxSpeed = 800;

        // constructor + call base constructor
        public AcceleratingBall() : base("resources/ball.png")
        {
            Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
            Color = Color.RED;
        }

        // Update is called every frame
        public override void Update(float deltaTime)
        {
            Acceleration = new Vector2(80, 60);

            Move(deltaTime);
            wrapEdges();
            Limit(Velocity, MaxSpeed);

            // Velocity = Limit(Velocity, MaxSpeed);
            Console.WriteLine(Velocity.Length());

            // if (Velocity.Length() > MaxSpeed)
            // {
            //     Velocity = Vector2.Normalize(Velocity);
            //     Velocity *= MaxSpeed;
            // }

        }

        private void Move(float deltaTime)
        {
            // TODO implement
            Velocity += Acceleration * deltaTime;
            Position += Velocity * deltaTime;



            // Velocity.add(Acceleration);
        }
        
        private Vector2 Limit(Vector2 vec, float max)
        {
            Vector2 limited = vec;

            if (vec.Length() > max)
            {
                limited = Vector2.Normalize(vec);
                limited = limited * max;
            }

            return limited;
        }

        private void wrapEdges()
        {
            float scr_width = Settings.ScreenSize.X;
            float scr_height = Settings.ScreenSize.Y;
            float spr_width = TextureSize.X;
            float spr_heigth = TextureSize.Y;

            // TODO implement...
            if (Position.X > scr_width)
            {
                Position.X = 0;
            }
            else if (Position.X < 0)
            {
                Position.X = scr_width;
            }

            if (Position.Y > scr_height)
            {
                Position.Y = 0;
            }
            else if (Position.Y < 0)
            {
                Position.Y = scr_width;
            }
        }
    }
}
