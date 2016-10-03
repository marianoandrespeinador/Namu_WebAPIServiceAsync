using System.Collections.Generic;
using System.Threading.Tasks;

namespace Namu.BLL.Contract
{
    /// <summary>
    /// Las clases de acceso a datos deben aceptar POCOs de Namu.Entity.ServicePOCOs
    /// </summary>
    public interface IBusinessObject<TPOCO>
    {
        Task<bool> Insert(TPOCO toInsert);
        Task<IEnumerable<TPOCO>> SelectAll();
        Task<TPOCO> Select(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, TPOCO toUpdate);
    }
}
