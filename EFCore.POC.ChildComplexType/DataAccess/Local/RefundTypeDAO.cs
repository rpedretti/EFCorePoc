using EFCore.POC.ChildComplexType.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.POC.ChildComplexType.DataAccess.Local
{
    public class RefundTypeDAO
    {
        public async Task InsertOrUpdateAsync(IEnumerable<RefundType> refundTypes)
        {
            using (var context = new POCContext())
            {
                try
                {
                    var codes = refundTypes.Select(rti => rti.RefundTypeId).ToList();

                    var refundTypesToUpdate = context.RefundType.Where(rt => codes.Contains(rt.RefundTypeId)).ToList();
                    var refundTypesToInsert = refundTypes.Except(refundTypesToUpdate).ToList();

                    //refundTypesToUpdate.ForEach(rt => rt.RefundUnit = context.RefundUnit.Single(ru => ru.RefundUnitId == rt.RefundUnit.RefundUnitId));
                    //refundTypesToInsert.ForEach(rt => rt.RefundUnit = context.RefundUnit.Single(ru => ru.RefundUnitId == rt.RefundUnit.RefundUnitId));

                    context.RefundType.UpdateRange(refundTypesToUpdate);
                    context.RefundType.AddRange(refundTypesToInsert);

                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public IEnumerable<RefundType> GetAllAsync()
        {
            using (var context = new POCContext())
            {
                return context.RefundType.Include(rt => rt.RefundUnit).AsNoTracking().ToList();
            }
        }
    }
}
