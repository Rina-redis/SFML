using System;
using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace SFML
{
    public class Player
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
            (float boxMinX, float boxMaxX) = MathHelper.GetMinAndMaxForRectangle(shape.Position.X, width);
            (float boxMinY, float boxMaxY) = MathHelper.GetMinAndMaxForRectangle(shape.Position.Y, height);

            float x = Math.Max(boxMinX, Math.Min(ball.Center().X, boxMaxX));
            float y = Math.Max(boxMinY, Math.Min(ball.Center().Y, boxMaxY));

            float distance = MathHelper.GetDistance(x, y, ball.Center().X, ball.Center().Y);

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
        public void TryToMove(Keyboard.Key keyDown, Keyboard.Key keyUp)
        {
            if (Keyboard.IsKeyPressed(keyDown))
            {
                MoveDown();
            }
            if (Keyboard.IsKeyPressed(keyUp))
            {
                MoveUp();
            }
        }
    }
}
