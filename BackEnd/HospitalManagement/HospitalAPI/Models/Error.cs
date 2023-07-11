namespace HospitalAPI.Models
{
    public class Error
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public Error(int ErrorCode, string Message)
        {
            this.ErrorCode = ErrorCode;
            this.Message = Message;
        }
    }
}
