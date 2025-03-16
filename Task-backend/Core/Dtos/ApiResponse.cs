namespace Task_backend.Core.Dtos;

    public class ApiResponse<T>
    {
        public bool Result { get; set; } = true;
        public string Date { get; set; } = DateTime.Now.ToShortDateString();
        public string Time { get; set; } = DateTime.Now.ToShortTimeString();
        public string Message { get; set; } = "Successful";
        public T Data { get; set; }
        public ApiResponse(T data)
        {
            Data = data;
        }

        public ApiResponse()
        {
            
        }
    }

