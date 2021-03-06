using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace SFML
{
   public class GameBall
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

            float X = random.NextFloat(0.7f, 1.4f);
            float Y = random.NextFloat(0.7f, 1.4f);

            if (direction.X >= 0) //hah/ shit
                direction.X = X;
            if (direction.X <= 0)
                direction.X = -X;
            if (direction.Y >= 0)
                direction.Y = Y;
            if (direction.Y <= 0)
                direction.Y = -Y;

            direction = new Vector2f(-direction.X * Constants.speed, -direction.Y * Constants.speed);
        }
        public void Move()
        {
            shape.Position += direction * Constants.speed;
        }
        public Vector2f Center()
        {
            return new Vector2f(shape.Position.X + shape.Radius, shape.Position.Y + shape.Radius);
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
