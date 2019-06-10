using System;
using Newtonsoft.Json;

namespace WeeklyGoals.Models.NewModels
{
    public class Achievement
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        [JsonProperty("points", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Points { get; set; }

        [JsonProperty("timePeriod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TimePeriod TimePeriod { get; set; }
    }
}