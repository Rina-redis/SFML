using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML;
using SFML.System;

namespace SFML
{
   public struct GameBall
    {
        public CircleShape shape;
        public Vector2f direction;
        public GameBall(int Radius, int xPosition, int yPosition, Color Color, List<Shape> allShapes)
        {
            direction = new Vector2f(-1, 0);
            shape = new CircleShape();
            shape.Radius = Radius;
            shape.Position = new Vector2f(xPosition, yPosition);
            shape.FillColor = Color;

            allShapes.Add(shape);
        }
        public void SetRandomDirection()
        {
            Random random = new Random();

            float X = (float)random.NextDouble();
            float Y = (float)random.NextDouble();

            if (X < 0.5)
                X = 2 * X;
            if (Y < 0.5)
                Y = 2 * Y;

            if (direction.X >= 0)
                direction.X = X;
            if (direction.X <= 0)
                direction.X = -X;
            if (direction.X >= 0)
                direction.Y = +Y;
            if (direction.X <= 0)
                direction.Y = -Y;

            direction = new Vector2f(-direction.X * Constants.speed, -direction.Y * Constants.speed);
        }
        public void Move()
        {
            shape.Position += direction * Constants.speed;
        }
        public void CheckIntersectionWithFloorAndWalls()
        {
            if (shape.Position.Y + shape.Radius * 2 >= 900 || shape.Position.Y < -10)
            {
                direction = new Vector2f(direction.X, -direction.Y);
            }
        }
    }
}
