using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Namu.DAL.DBCalls.Contract;
using Namu.DAL.Model;
using Namu.Entity.DB;
using Namu.Entity.ServicePOCOs;

namespace Namu.DAL.DBCalls
{
    public class UserDO : IDataObject<User>
    {
        private const int SessionExpiresMinutes = 15;

        public async Task<bool> Insert(User toInsert)
        {
            var success = await DataObjectHelper.ExecuteWithExceptionHandler(async () =>
            {
                var result = 0;
                using (var context = new dbnamutestEntities())
                {
                    var exists = context.tusers.Any(u => u.name == toInsert.Name);

                    if (!exists)
                    {
                        context.tusers.Add(toInsert.GetAsEntityFrameworkGenerated());

                        result = await context.SaveChangesAsync();
                    }
                }
                return result;
            }, GetType().Name);

            return success;
        }

        public Task<List<User>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(string name, string passwordCypher)
        {
            var unmop = await DataObjectHelper.ExecuteSelectWithExceptionHandler(async () =>
            {
                var usuario = new User();

                using (var context = new dbnamutestEntities())
                {
                    var loginSuccess = false;

                    var aux = await context.tusers
                        .Where(u => u.name.Equals(name))
                        .FirstOrDefaultAsync();

                    if (aux != null)
                    {
                        var curToken = await context.ttokens
                            .FirstOrDefaultAsync(t => t.endDate > DateTime.Now
                                                      && t.fktuser == aux.idtuser);
                        if (curToken != null)
                        {
                            //ya existe una sesion abierta, se cierra para abrir otra si se logea:
                            curToken.endDate = DateTime.Now;
                        }

                        if (aux.passwordCypher.Equals(passwordCypher))
                        {
                            loginSuccess = true;

                            aux.ttokens.Add(new ttoken
                            {
                                startDate = DateTime.Now,
                                endDate = DateTime.Now.AddMinutes(SessionExpiresMinutes),
                                authToken = Guid.NewGuid().ToString()
                            });
                        }
                    }

                    await context.SaveChangesAsync();

                    usuario = loginSuccess ? aux.GetAsPOCO() : new User();
                }

                return usuario;
            }, GetType().Name);

            return unmop;
        }

        public async Task<bool> ValidateToken(string tokenId)
        {
            var untoken = await DataObjectHelper.ExecuteWithExceptionHandler(async () =>
            {
                var result = 0;

                using (var context = new dbnamutestEntities())
                {
                    var curToken = await context.ttokens
                        .FirstOrDefaultAsync(t => t.endDate > DateTime.Now
                                                  && t.authToken.Equals(tokenId));
                    if (curToken != null)
                    {//ya existe una sesion abierta, se actualiza para perdurar sesion:
                        curToken.endDate = DateTime.Now.AddMinutes(SessionExpiresMinutes);

                        result = await context.SaveChangesAsync();
                    }
                }

                return result;
            }, GetType().Name);

            return untoken;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, User toUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<User> Select(int id)
        {
            throw new NotImplementedException();
        }
    }
}
