using System;


namespace ProcessMultipleException
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? " Jummer..." : "Quiet time");
        }
    }
}
