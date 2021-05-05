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
        static float offsetX = 20f;
        static float offsetY = 40f;
        static List<Shape> allShapesToDraw = new List<Shape>();
        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            (Player leftPlayer, Player rightPlayer) = CreatePlayers();
            CircleShape ball = new CircleShape();
            ball.Position = new Vector2f(800, 420);
            ball.Radius = 30;
            ball.FillColor = Color.Red;

            window.Closed += WindowClosed;
          
            bool moveRight;

            while (window.IsOpen)
            {
                //System.Threading.Thread.Sleep(50);
                window.Clear();

                TryToMoveLeftPlayer(leftPlayer);
                TryToMoveRightPlayer(rightPlayer);

               
                //moveRight = TryMoveRight(rightPlayer, leftPlayer, ball);
                //if (moveRight)
                //{
                //    MoveRight(offsetX, offsetY, ball);
                //}
                //else
                //{
                //    MoveLeft(offsetX, offsetY, ball);
                //}


                window.DispatchEvents();
                window.Display();
                DrawAllShapes(window);

            }

            

            bool TryMoveRight(Shape rightPlayer, Shape leftPlayer, Shape ball)
            {
                if (ball.Position.X > rightPlayer.Position.X)
                {
                    return false;
                }
                return true;
            }      
        }
        void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
        public (Player player1, Player player2) CreatePlayers()
        {
            Player player1 = new Player(50, 0, 400, Color.Blue, allShapesToDraw);
            Player player2 = new Player(50, 1500, 400, Color.Magenta, allShapesToDraw);
            return (player1, player2);
        }
        public void DrawAllShapes(RenderWindow window)
        {
            foreach(Shape shape in allShapesToDraw)
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
    }
}
