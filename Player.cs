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
        public CircleShape shape;

        public Player( int Radius, int xPosition, int yPosition, Color Color, List<Shape> allShapes)
        {
            shape = new CircleShape();     
            shape.Radius = Radius;
            shape.Position = new Vector2f(xPosition, yPosition);
            shape.FillColor = Color;

            allShapes.Add(shape);
        }

        public void MoveUp()
        {
            Vector2f pos = shape.Position;
            Vector2f newPos = new Vector2f(pos.X, pos.Y + Constants.deltaY);
            shape.Position = newPos;
        }
        public void MoveRight( )
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
            Vector2f newPos = new Vector2f(pos.X, pos.Y - Constants.deltaY);
            shape.Position = newPos;
        }
    }
}
