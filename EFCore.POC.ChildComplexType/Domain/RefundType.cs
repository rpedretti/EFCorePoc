using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.POC.ChildComplexType.Domain
{
    public class RefundType
    {
        [JsonProperty("code")]
        public int RefundTypeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("refundUnit")]
        public RefundUnit RefundUnit { get; set; }

        public int RefundUnitId { get; set; }

        [JsonProperty("lightIcon")]
        public string LightIcon { get; set; }

        [JsonProperty("darkIcon")]
        public string DarkIcon { get; set; }

        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("isCommentRequired")]
        public bool IsCommentRequired { get; set; }

        [JsonProperty("isAttachmentRequired")]
        public bool IsAttachmentRequired { get; set; }

        [JsonProperty("isPeopleRequired")]
        public bool IsPeopleRequired { get; set; }

        [JsonProperty("helpText")]
        public string HelpText { get; set; }

        public override bool Equals(object obj)
        {
            var areEquals = false;

            if (obj != null && obj is RefundType && RefundTypeId == ((RefundType)obj).RefundTypeId)
            {
                areEquals = true;
            }

            return areEquals;
        }

        public override int GetHashCode()
        {
            return RefundTypeId.GetHashCode();
        }
    }
}
