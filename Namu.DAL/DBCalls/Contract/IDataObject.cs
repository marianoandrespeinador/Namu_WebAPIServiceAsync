using System.Collections.Generic;
using System.Threading.Tasks;

namespace Namu.DAL.DBCalls.Contract
{
    /// <summary>
    /// Interface para todos los objetos que hacen llamadas a la Base de Datos
    /// </summary>
    internal interface IDataObject<T>
    {
        //todos son tasks para llamadas asincronas si el cliente lo permite.

        Task<bool> Insert(T toInsert);
        Task<List<T>> SelectAll();
        Task<T> Select(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, T toUpdate);
    }
}
