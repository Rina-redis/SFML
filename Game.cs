using SFML.Window;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFML
{
    public class Game
    { 
        static List<Shape> allShapesToDraw = new List<Shape>();  
        RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");   
        Abilitie[] allAbilities;
       
        public void Start()
        {
            CreateAllAbilities();
            (Player leftPlayer, Player rightPlayer) = CreatePlayers();
            GameBall ball = new GameBall(40,500,420,Color.Red,allShapesToDraw);          
            window.Closed += WindowClosed;
           // window.KeyPressed += OnKeyPressed(leftPlayer, rightPlayer);
            window.SetFramerateLimit(600);
            
            while (window.IsOpen)
            {
                Event pressed = new Event();
                window.Clear();

                leftPlayer.TryToMove(Keyboard.Key.S, Keyboard.Key.W);
                rightPlayer.TryToMove(Keyboard.Key.Down, Keyboard.Key.Up);

                ball.Move();
                ball.CheckIntersectionWithFloorAndWalls();

                //if (leftPlayer.abilityDictionary.ContainsKey(pressed.Key.Code))
                //{
                //    leftPlayer.currentAbilitie = leftPlayer.abilityDictionary[pressed.Key.Code];
                //    leftPlayer.currentAbilitie.SetAbilityActive(leftPlayer);
                //}
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                {
                    leftPlayer.currentAbilitie = allAbilities[0];
                    leftPlayer.SetAbilityActive();
                }

                leftPlayer.CheckIntersectionAndChangeDirection(ball);
                rightPlayer.CheckIntersectionAndChangeDirection(ball);

           
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
        public void OnKeyPressed(object sender, KeyEventArgs e)
        {
           
        }

        public (Player player1, Player player2) CreatePlayers()
        {
            var abilitiesForRightPlayer = new Dictionary<Keyboard.Key, Abilitie>();
            abilitiesForRightPlayer.Add(Keyboard.Key.Numpad1, allAbilities[0]);
            Player player1 = new Player(0, 320, Color.Blue, allShapesToDraw, abilitiesForRightPlayer);

            var abilitiesForLeftPlayer = new Dictionary<Keyboard.Key, Abilitie>();
            Player player2 = new Player(1540, 320, Color.Magenta, allShapesToDraw, abilitiesForLeftPlayer);
            abilitiesForLeftPlayer.Add(Keyboard.Key.Q, allAbilities[0]);
            return (player1, player2);
        }
        public void DrawAllShapes(RenderWindow window)
        {
            foreach (Shape shape in allShapesToDraw)
            {
                window.Draw(shape);
            }
        }
        public void CreateAllAbilities()
        {
            allAbilities = new Abilitie[2];
            allAbilities[0] = new Magnification();
        }
    }
}
