using System;
using System.Collections;
using CustomException;
using ProcessMultipleException;
namespace Try_catcch_3
{
  
    class Car
    {
        public const int maxSpeed = 100;
        public int currentSpeed { get; set; } = 0;
        public string carName { get; set; } = "";
        private bool carIsDead;
        private Radio theMusicBox = new Radio();
        public Car() { }
        public Car(string name, int speed)
        {
            carName = name;
            currentSpeed = speed;
        }
        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }
        public void Accelerate(int delta)
        {
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(delta), "Speeds must be greater than zero");
            }
            if (carIsDead)
            {
                Console.WriteLine($"{carName} is dead (stop with dead engine)");
            }
            else
            {
                currentSpeed += delta;
                if (currentSpeed > maxSpeed)
                {
                    currentSpeed = 0;
                    carIsDead = true;
                    throw new CarIsDeadException ("You have a lead foot", DateTime.Now, $"{carName} is overheated")
                    {
                        HelpLink = "http://www.CarsRUs.com",
                    };
                }
                else
                {
                    Console.WriteLine($"=> Current Speed {carName} is {currentSpeed}");

                }
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Car MyCar = new Car("Kia ceed", 90);
            try
            {

                MyCar.Accelerate(-50);
                //for (int i = 0; i < 10; i++)
                //{
                //    MyCar.Accelerate(10);
                //}
            }
           
            catch (Exception e)
            {
                Console.WriteLine(  e.Message);
            }

            catch (ArgumentOutOfRangeException ag)
            {
                Console.WriteLine(ag.Message);
            }

            catch (CarIsDeadException ex)
            {
                Console.WriteLine("\n*****Error***");
                Console.WriteLine($"The message is {ex.Message}");
                Console.WriteLine($"Cause is: {ex.causeOfError}");
                Console.WriteLine($"Data: {ex.ErrorTimeStamp}");
                Console.WriteLine("Mamber name: {0}", ex.TargetSite);
                Console.WriteLine("Class definging method: {0}", ex.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", ex.TargetSite.MemberType);
                Console.WriteLine("Stack: {0}", ex.StackTrace);
                Console.WriteLine("HelpLink {0}", ex.HelpLink);
                
            }
        }
    }
}
