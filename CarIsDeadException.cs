using System;

namespace CustomException
{
    public class CarIsDeadException : ApplicationException
    {
        private string _messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string causeOfError { get; set; }
        public CarIsDeadException() { }
        public CarIsDeadException(string cause, DateTime time ) : this(cause,time,String.Empty)
        {
        }
        public CarIsDeadException(string cause, DateTime time, string message) :
            this(cause,time,String.Empty,null)
        {

        }
        public CarIsDeadException(string cause, DateTime time, string message, System.Exception inner):
            base(message, inner)
        {
            ErrorTimeStamp = time;
            causeOfError = cause;
        }
    }
}
