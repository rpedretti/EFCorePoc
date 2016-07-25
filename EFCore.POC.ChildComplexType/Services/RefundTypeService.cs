using EFCore.POC.ChildComplexType.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Utils;

namespace EFCore.POC.ChildComplexType.Services
{
    public class RefundTypeService
    {
        private DataAccess.Local.RefundTypeDAO _localRefundTypeDAO;
        private DataAccess.Local.RefundUnitDAO _localRefundUnitDAO;
        private DataAccess.Web.RefundTypeDAO _webRefundTypeDAO;

        public RefundTypeService()
        {
            _localRefundTypeDAO = new DataAccess.Local.RefundTypeDAO();
            _localRefundUnitDAO = new DataAccess.Local.RefundUnitDAO();
            _webRefundTypeDAO = new DataAccess.Web.RefundTypeDAO();
        }

        public async Task UpdateRefundTypes()
        {
            try
            {
                var webRefudTypes = await _webRefundTypeDAO.GetAllRefundTypesAsync();
                var refundUnits = webRefudTypes.Select(rt => rt.RefundUnit).Distinct().ToList();

                webRefudTypes.ForEach(rt => {
                    rt.RefundUnitId = rt.RefundUnit.RefundUnitId;
                    rt.RefundUnit = null;
                });

                await _localRefundUnitDAO.InsertOrUpdateAsync(refundUnits);
                await _localRefundTypeDAO.InsertOrUpdateAsync(webRefudTypes);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<RefundType> GetRefundTypes()
        {
            return _localRefundTypeDAO.GetAllAsync();
        }
    }
}
