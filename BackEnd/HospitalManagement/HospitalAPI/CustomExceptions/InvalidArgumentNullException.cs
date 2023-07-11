namespace HospitalAPI.CustomExceptions
{
    public class InvalidArgumentNullException:Exception
    {
        string message;

        public InvalidArgumentNullException()
        {
            message = "Argument Null Exception is thrown";
        }

        public InvalidArgumentNullException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
