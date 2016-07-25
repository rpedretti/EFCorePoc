using EFCore.POC.ChildComplexType.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.POC.ChildComplexType.DataAccess.Local
{
    public class RefundUnitDAO
    {
        public async Task InsertOrUpdateAsync(IEnumerable<RefundUnit> refundUnits)
        {
            using (var context = new POCContext())
            {
                var refundUnitsToUpdate = context.RefundUnit.Where(ru => refundUnits.Select(rui => rui.RefundUnitId).Contains(ru.RefundUnitId));
                var refundUnitsToInsert = refundUnits.Where(ru => !refundUnitsToUpdate.Select(rui => rui.RefundUnitId).Contains(ru.RefundUnitId));
                context.RefundUnit.UpdateRange(refundUnitsToUpdate);
                context.RefundUnit.AddRange(refundUnitsToInsert);
                await context.SaveChangesAsync();
            }
        }
    }
}