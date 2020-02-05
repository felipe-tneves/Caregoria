using Newtonsoft.Json;

namespace ApiCatalogo.Models
{
    //detalhes de erros 
    //modelo de dominio relacionado aos erros 
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Trace { get; set; }

        //sobre escreve o metodo tostring para converter em um objeto serializado 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
