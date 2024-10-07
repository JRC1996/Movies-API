namespace Movies_API.Models.Response
{
    public class Response
    {

        public Response() 
        {

            this.Success = 0;
        
        }




        public int Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

    }
}
