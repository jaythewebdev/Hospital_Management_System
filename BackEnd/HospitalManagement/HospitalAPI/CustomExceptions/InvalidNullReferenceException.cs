namespace HospitalAPI.CustomExceptions
{
    public class InvalidNullReferenceException:Exception
    {
        string message;

        public InvalidNullReferenceException()
        {
            message = "Null Reference Exception is thrown";
        }

        public InvalidNullReferenceException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
