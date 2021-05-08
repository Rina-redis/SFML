using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML;
using SFML.System;


namespace SFML
{
    public struct Player
    {
        public RectangleShape shape;
        public float width;
        public float height;
        public int score;

        public Player( int xPosition, int yPosition, Color Color, List<Shape> allShapes)
        {
            shape = new RectangleShape();
            width = 60f;
            height = 250f;
            score = 0;
            shape.Size = new Vector2f(60, 250);
            shape.Position = new Vector2f(xPosition, yPosition);
            shape.FillColor = Color;
            
            allShapes.Add(shape);
        }

        public void MoveUp()
        {
            Vector2f pos = shape.Position;
            Vector2f newPos = new Vector2f(pos.X, pos.Y - Constants.deltaY);
            shape.Position = newPos;
        }
        public void MoveRight()
        {
            Vector2f pos = shape.Position;
            Vector2f newPos = new Vector2f(pos.X + Constants.deltaX, pos.Y);
            shape.Position = newPos;
        }
        public void MoveLeft()
        {
            Vector2f pos = shape.Position;
            Vector2f newPos = new Vector2f(pos.X - Constants.deltaX, pos.Y);
            shape.Position = newPos;
        }

        public void MoveDown()
        {
            Vector2f pos = shape.Position;
            Vector2f newPos = new Vector2f(pos.X, pos.Y + Constants.deltaY);
            shape.Position = newPos;
        }
        public void AddSore()
        {
            score++;
        }
        public bool IsIntersection(GameBall ball)
        {
            float boxMinX = shape.Position.X;
            float boxMaxX = shape.Position.X + width ;
            float boxMinY = shape.Position.Y;
            float boxMaxY = shape.Position.Y + height;

            float x = Math.Max(boxMinX, Math.Min(ball.Center().X, boxMaxX));
            float y = Math.Max(boxMinY, Math.Min(ball.Center().Y, boxMaxY));

            var distance = Math.Sqrt((x - ball.Center().X) * (x - ball.Center().X) +
                                     (y - ball.Center().Y) * (y - ball.Center().Y));


            if (distance <= ball.shape.Radius)
                return true;
            else 
                return false;
        }

        public void CheckIntersectionAndChandeDirection(GameBall ball)
        {
            if (IsIntersection(ball))
            {
                ball.shape.FillColor = Color.Yellow;
                AddSore();
                ball.SetRandomDirection();               
            }
        }
      
    }
}
