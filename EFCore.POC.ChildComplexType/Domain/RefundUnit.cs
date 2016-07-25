using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.POC.ChildComplexType.Domain
{
    public class RefundUnit
    {
        [JsonProperty("code")]
        public int RefundUnitId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("activeIndicator")]
        public string ActiveIndicator { get; set; }

        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("km")]
        public bool Km { get; set; }

        [JsonProperty("person")]
        public bool Person { get; set; }

        [JsonProperty("item")]
        public bool Item { get; set; }

        public override bool Equals(object obj)
        {
            var areEquals = false;

            if (obj != null && obj is RefundUnit && RefundUnitId == ((RefundUnit)obj).RefundUnitId)
            {
                areEquals = true;
            }

            return areEquals;
        }

        public override int GetHashCode()
        {
            return RefundUnitId.GetHashCode();
        }
    }
}
