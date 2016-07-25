using EFCore.POC.ChildComplexType.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace EFCore.POC.ChildComplexType.DataAccess.Web
{
    public class RefundTypeDAO
    {
        public async Task<IEnumerable<RefundType>> GetAllRefundTypesAsync()
        {
            Uri dataUri = new Uri("ms-appx:///mockRefundType.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            var json = await FileIO.ReadTextAsync(file);

            var refundTypes = JsonConvert.DeserializeObject<List<RefundType>>(json);

            return refundTypes;
        }
    }
}
