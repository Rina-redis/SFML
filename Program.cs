using SFML.Window;
using SFML.Graphics;
using System;
using SFML;


namespace Game
{
    class Program
    {
        static float offsetX = 20f;
        static float offsetY = 40f;
        static void Main(string[] args)
        {
           
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            CircleShape leftPlayer = new CircleShape();
            leftPlayer.Position = new SFML.System.Vector2f(0, 400);
            leftPlayer.Radius = 50;
            leftPlayer.FillColor = Color.Blue;

            CircleShape rightPlayer = new CircleShape();
            rightPlayer.Position = new SFML.System.Vector2f(1500,400);
            rightPlayer.Radius = 50;
            rightPlayer.FillColor = Color.Magenta;

            CircleShape ball = new CircleShape();
            ball.Position = new SFML.System.Vector2f(800, 420);
            ball.Radius = 30;
            ball.FillColor = Color.Red;

            window.Closed += WindowClosed;
            SFML.System.Vector2f d ;
            bool moveRight;
            
            while (window.IsOpen) {

                System.Threading.Thread.Sleep(50);
                window.Clear();
         
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    MoveUp(offsetX, offsetY, leftPlayer);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    MoveDown(offsetX, offsetY, leftPlayer);
                }
           
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    MoveUp(offsetX, offsetY, rightPlayer);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    MoveDown(offsetX, offsetY, rightPlayer);
                }

               // MoveRight(offsetX, offsetY, ball);
                moveRight= TryMoveRight(rightPlayer, leftPlayer, ball);
                if (moveRight)
                {
                    MoveRight(offsetX, offsetY, ball);
                }
                else
                {
                    MoveLeft(offsetX, offsetY, ball);
                }
                             
                window.Draw(leftPlayer);
                window.Draw(rightPlayer);
                window.Draw(ball);

                window.DispatchEvents();              
                window.Display();
            }
            void WindowClosed(object sender, EventArgs e)
            {
                RenderWindow w = (RenderWindow)sender;
                w.Close();
            }
            bool TryMoveRight(Shape rightPlayer, Shape leftPlayer, Shape ball)
            {
                if (ball.Position.X > rightPlayer.Position.X)
                {
                    return false;
                }
                return true;
            }
            //static SFML.System.Vector2f TryToGetCollision(Shape rightPlayer, Shape leftPlayer, Shape ball)
            //{
            //    if(ball.Position.X > rightPlayer.Position.X)
            //    {
            //        return -ball.Position;
            //    }
            //    return ball.Position;
            //}
            void MoveRight(float deltaX, float deltaY, Shape shape)
            {
                SFML.System.Vector2f pos = shape.Position;
                SFML.System.Vector2f newPos = new SFML.System.Vector2f(pos.X + deltaX, pos.Y);
                shape.Position = newPos;
            }
            void MoveLeft(float deltaX, float deltaY, Shape shape)
            {
                SFML.System.Vector2f pos = shape.Position;
                SFML.System.Vector2f newPos = new SFML.System.Vector2f(pos.X - deltaX, pos.Y);
                shape.Position = newPos;
            }
            void MoveUp(float deltaX, float deltaY, Shape shape)
            {
                SFML.System.Vector2f pos = shape.Position;
                SFML.System.Vector2f newPos = new SFML.System.Vector2f(pos.X, pos.Y + deltaY);
                shape.Position = newPos;
            }
            void MoveDown(float deltaX, float deltaY, Shape shape)
            {
                SFML.System.Vector2f pos = shape.Position;
                SFML.System.Vector2f newPos = new SFML.System.Vector2f(pos.X, pos.Y - deltaY);
                shape.Position = newPos;
            }
        }
        
       
    }
}

