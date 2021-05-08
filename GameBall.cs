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
  
        public GameBall(int Radius, int xPosition, int yPosition, Color Color, List<Shape> allShapes)
        {
            shape = new CircleShape();
            shape.Radius = Radius;
            shape.Position = new Vector2f(xPosition, yPosition);
            shape.FillColor = Color;

            allShapes.Add(shape);
        }
       

    }
}
