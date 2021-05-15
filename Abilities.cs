using System;
using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace SFML
{
    public abstract class Abilitie
    {
        public int? timeToWork;
        public int currentNumberOfUses = 0;
        public int numberOfUses; 
        public  Abilitie(int? TimeToWork, int NumberOfUses)
        {
            timeToWork = TimeToWork;
            numberOfUses = NumberOfUses;
        }

        public virtual void Active(Player player) { }
       
    }
    public class Magnification : Abilitie
    {
        float prozentOfMafnification = 1.6f;
        public Magnification(): base(5,1)
        {
            
        }

        public override void Active(Player player)
        {           
            
            player.currentAbilitie.currentNumberOfUses++;
            player.width = player.width * prozentOfMafnification;
            player.height = player.height * prozentOfMafnification;
            player.shape.Size =new Vector2f(player.shape.Size.X * prozentOfMafnification, player.shape.Size.Y * prozentOfMafnification);

        }

      
    }
}
