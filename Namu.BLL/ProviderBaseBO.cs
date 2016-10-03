using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Namu.BLL.Contract;
using Namu.DAL.DBCalls;
using Namu.Entity.ServicePOCOs;

namespace Namu.BLL
{
    public abstract class ProviderBaseBO : IBusinessObject<Provider>
    {
        protected abstract ProviderBaseDO _accessDO { get; }
        
        public async Task<bool> Insert(Provider toInsert)
        {
            return await _accessDO.Insert(toInsert);
        }

        public async Task<IEnumerable<Provider>> SelectAll()
        {
            return await _accessDO.SelectAll();
        }

        public async Task<Provider> Select(int id)
        {
            return await _accessDO.Select(id);
        }

        public async Task<int> GetIdForName(string name)
        {
            return await _accessDO.GetIdForName(name);
        }

        public async Task<bool> Delete(int id)
        {
            return await _accessDO.Delete(id);
        }

        public async Task<bool> Update(int id, Provider toUpdate)
        {
            return await _accessDO.Update(id, toUpdate);
        }

    }
}
