using System;
using System.Text.Json.Serialization;

namespace Covid19DataProject.Models.Covid19
{
    public class USCurrent
    {
        [JsonPropertyName("date")] public int DateInt { get; set; }
        
        [JsonIgnore] public DateTime Date { get; set; }
        
        [JsonPropertyName("positive")] public int Positive { get; set; }

        [JsonPropertyName("negative")] public int Negative { get; set; }
        
        [JsonPropertyName("negativeIncrease")] public int NegativeIncrease { get; set; }

        [JsonPropertyName("pending")] public int Pending { get; set; }

        [JsonPropertyName("hospitalizedCurrently")] public int CurrentlyHospitalized { get; set; }

        [JsonPropertyName("hospitalizedCumulative")] public int CumulativeHospitalized { get; set; }

        [JsonPropertyName("inIcuCurrently")] public int CurrentlyInIcu { get; set; }

        [JsonPropertyName("inIcuCumulative")] public int CumulativeInIcu { get; set; }

        [JsonPropertyName("onVentilatorCurrently")] public int CurrentlyOnVentilator { get; set; }

        [JsonPropertyName("onVentilatorCumulative")] public int CumulativeOnVentilator { get; set; }

        [JsonPropertyName("recovered")] public int Recovered { get; set; }

        [JsonPropertyName("death")] public int Death { get; set; }
        
        [JsonPropertyName("deathIncrease")] public int DeathIncrease { get; set; }
        
        [JsonPropertyName("totalTestResults")] public int TotalTestResults { get; set; }
        
        [JsonPropertyName("hospitalizedIncrease")] public int HospitalizedIncrease { get; set; }
        
        [JsonPropertyName("positiveIncrease")] public int PositiveIncrease { get; set; }
    }
}