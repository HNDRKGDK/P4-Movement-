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
    class SimpleBall : SpriteNode
    {
        // your private fields here
        private float speedY = 400;
        private float speedX = 400;


        // constructor + call base constructor
        public SimpleBall() : base("resources/bigball.png")
        {
            Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
            Color = Color.BLUE;
        }

        // Update is called every frame
        public override void Update(float deltaTime)
        {
            Move(deltaTime);
            BounceEdges();
        }

        // your own private methods
        private void Move(float deltaTime)
        {
            // TODO implement
            // Moves the ball on the Y
            Position.Y = Position.Y + speedY * deltaTime;

            // Moves teh ball on the X
            Position.X = Position.X + speedX * deltaTime;

        }

        private void BounceEdges()
        {
            float scr_width = Settings.ScreenSize.X;
            float scr_height = Settings.ScreenSize.Y;
            float spr_width = TextureSize.X;
            float spr_heigth = TextureSize.Y;

            // TODO implement...

            // checks if the the ball is is touching the edge the screen.
            // if so, change times the speed -1
            if (Position.X + spr_width / 2 > scr_width)
            {
                Position.X = scr_width - spr_width / 2;
                speedX = speedX * -1;
            }

            if (Position.X - spr_width / 2 < 0)
            {
                Position.X = 0 + spr_width / 2;
                speedX = speedX * -1;
            }

            if (Position.Y + spr_heigth / 2 > scr_height)
            {
                Position.Y = scr_height - spr_heigth / 2;
                speedY = speedY * -1;
            }

            if (Position.Y - spr_heigth / 2 < 0)
            {
                Position.Y = 0 + spr_heigth / 2;
                speedY = speedY * -1;
            }
        }
    }

}

