using System;
using Newtonsoft.Json;

namespace WeeklyGoals.Models.Activity
{
    public class Goal
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        [JsonProperty("target", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Target { get; set; }

        [JsonProperty("step", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Step { get; set; }

        [JsonProperty("unit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("multiplicator", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Multiplicator { get; set; }
    }
}