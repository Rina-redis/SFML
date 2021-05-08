using SFML.Window;
using SFML.Graphics;
using System;
using SFML;
using SFML.System;
using System.Collections.Generic;

namespace SFML
{
    public class Game
    { 
        static List<Shape> allShapesToDraw = new List<Shape>();      
        Vector2f direction = new Vector2f(-1,0);
        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            (Player leftPlayer, Player rightPlayer) = CreatePlayers();
            GameBall ball = new GameBall(30,500,420,Color.Red,allShapesToDraw);
           
            window.Closed += WindowClosed;
            window.SetFramerateLimit(600);

            while (window.IsOpen)
            { 
                window.Clear();

                TryToMoveLeftPlayer(leftPlayer);
                TryToMoveRightPlayer(rightPlayer);
               
                MoveBall(ball.shape, direction);
                CheckIntersectionWithFloorAndWalls(ball.shape);
              
                if (leftPlayer.CheckIntersection(ball.shape))                
                {
                    ball.shape.FillColor = Color.Yellow;
                    leftPlayer.AddSore();
                    SetRandomDirection();                 
                }
                if (rightPlayer.CheckIntersection(ball.shape))
                {
                    ball.shape.FillColor = Color.Red;
                    rightPlayer.AddSore();
                    SetRandomDirection();
                }
               
                DrawAllShapes(window);              
                window.DispatchEvents();
                window.Display();                              
            }
        }


        void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
         public void CheckIntersectionWithFloorAndWalls(CircleShape ball)
        {
            if(ball.Position.Y + ball.Radius*2 >= 900||ball.Position.Y < -10 )
            {
                direction = new Vector2f(direction.X, -direction.Y);
            }                
        }
        public (Player player1, Player player2) CreatePlayers()
        {
            Player player1 = new Player(50, 0, 320, Color.Blue, allShapesToDraw);
            Player player2 = new Player(50, 1540, 320, Color.Magenta, allShapesToDraw);
            return (player1, player2);
        }
        public void DrawAllShapes(RenderWindow window)
        {
            foreach (Shape shape in allShapesToDraw)
            {
                window.Draw(shape);
            }
        }
        public void TryToMoveLeftPlayer(Player LeftPlayer)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                LeftPlayer.MoveDown();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                LeftPlayer.MoveUp();
            }
        }
        public void TryToMoveRightPlayer(Player RightPlayer)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                RightPlayer.MoveDown();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                RightPlayer.MoveUp();
            }
        }
       
        public void MoveBall(Shape ball, Vector2f dir)
        {
            ball.Position += direction*Constants.speed;
        }

        public void ChangeDirection()
        {
            direction = -direction;
        }
        public void SetRandomDirection()
        {
            Random random = new Random();
           
            float X = (float)random.NextDouble();
            float Y = (float)random.NextDouble();

            if (X < 0.4)
                X = 2 * X;
            if (Y < 0.4)
                Y = 2 * Y;

            if (direction.X >= 0)
                direction.X =  X;
            if (direction.X <= 0)
                direction.X = - X;
            if (direction.X >= 0)
                direction.Y = + Y;
            if (direction.X <= 0)
                direction.Y = - Y;

            direction = new Vector2f(-direction.X*Constants.speed , -direction.Y * Constants.speed);
        }
    }
}
