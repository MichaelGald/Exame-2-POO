using Newtonsoft.Json;

namespace Examen_2_de_POO.Dtos.common
{
    public class ResponseDto <T>
    {
        // T significa cualquier tipo de Dato
        public T Data { get; set; }

        public string Message { get; set; }
        //para saber el estado de codigo di
        //gamos 200 OK

        [JsonIgnore]
        public int StatusCode { get; set; }

        public bool Status { get; set; }
    }
}
