using System;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string action;
            string repead;
            Player player = new Player();

            do
            {
                Console.WriteLine("Current state: {0}\n", player.currentState);
                Console.WriteLine("Select action: \nP - play, Z - pause, R - record, S - stop");

                action = Console.ReadLine();
                if (ValidateCommand(action, player))
                {
                    switch (action)
                    {
                        case "P":
                            player.Play();
                            repead = "y";
                            break;
                        case "Z":
                            player.Pause();
                            repead = "y";
                            break;
                        case "R":
                            player.Record();
                            repead = "y";
                            break;
                        case "S":
                            player.Stop();
                            Console.WriteLine("Repead? (y/n)");
                            repead = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("What?");
                            Console.WriteLine("Choose another action? (y/n)");
                            repead = Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Already. Choose another action? (y/n)");                    
                    repead = Console.ReadLine();
                }
            } while (repead == "y");
        }

        static bool ValidateCommand(string action, Player player)
        {
            bool result = false;
            if ((action == "S" && player.currentState == CurrentState.STOP)
                || (action == "P" && player.currentState == CurrentState.PLAY)
                || (action == "Z" && player.currentState == CurrentState.PAUSE)
                || (action == "R" && player.currentState == CurrentState.RECORD))
            {
                return result;
            }
            else result = true;
            return result;
        }

    }
    public enum CurrentState
    {
        PLAY,
        RECORD,
        PAUSE,
        STOP
    }

    public interface IPlayable
    {
        public void Play();
        public void Pause();
        public void Stop();

    }

   public interface IRecodable
    {
        public void Record();
        public void Pause();
        public void Stop();
    }

    public class Player: IPlayable, IRecodable
    {
        private CurrentState state = CurrentState.STOP;
        public CurrentState currentState
        {
            get { return state; }

            set 
            {
                state = value;
            }
        }
       public void Play()
        {
            currentState = CurrentState.PLAY;
            Console.WriteLine("Recording is being played\n");
        }     

        public void Record()
        {
            currentState = CurrentState.RECORD;
            Console.WriteLine("Attention! Recording in progress\n");
        }

        public void Stop()
        {
            if (currentState == CurrentState.PLAY)
            {
                Console.WriteLine("Play stopped\n");
            }
            else if (currentState == CurrentState.RECORD)
            {
                Console.WriteLine("Recording stopped\n");
            }
            else
            {
                Console.WriteLine("Stopped\n");
            }
            currentState = CurrentState.STOP;
            
        }

        public void Pause()
        {
            currentState = CurrentState.PAUSE;
            Console.WriteLine("Paused\n");
        }
    }
}
