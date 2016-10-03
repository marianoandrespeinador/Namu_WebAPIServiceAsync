
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Namu.BLL.Contract;
using Namu.DAL.DBCalls;
using Namu.Entity.ServicePOCOs;

namespace Namu.BLL
{
    public class UserBO : IBusinessObject<User>
    {
        UserDO _accessDO = new UserDO();

        public async Task<bool> Insert(User toInsert)
        {
            return await _accessDO.Insert(toInsert);
        }

        public async Task<User> Login(string name, string passwordCypher)
        {
            return await _accessDO.Login(name, passwordCypher);
        }

        public async Task<bool> ValidateToken(string tokenId)
        {
            var result = await _accessDO.ValidateToken(tokenId);

            return result;
        }

        public Task<IEnumerable<User>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Select(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, User toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
