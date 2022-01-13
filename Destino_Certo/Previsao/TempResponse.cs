using Newtonsoft.Json;

namespace Destino_Certo.Models
{
    public class TempResponse
    {
        [JsonProperty("dados")]
        public List<Dado> Dados { get; set; }

        [JsonProperty("local")]
        public Local Local { get; set; }

        [JsonProperty("arquivo")]
        public long Arquivo { get; set; }

        public TempResponse()
        {
            Dados = new List<Dado>();
        }

    }

    public class Dado
    {
        [JsonProperty("dia")]
        public string Dia { get; set; }

        [JsonProperty("mes")]
        public string Mes { get; set; }

        [JsonProperty("ano")]
        public string Ano { get; set; }

        [JsonProperty("rodada")]
        public string Rodada { get; set; }

        [JsonProperty("minima")]
        public string Minima { get; set; }

        [JsonProperty("maxima")]
        public string Maxima { get; set; }

        [JsonProperty("vento")]
        public string Vento { get; set; }

        [JsonProperty("direcao")]
        public string Direcao { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("prec")]
        public string Prec { get; set; }
    }

    public class Local
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("neighbourhood")]
        public string Neighbourhood { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
}
