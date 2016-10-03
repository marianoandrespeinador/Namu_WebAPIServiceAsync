using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Namu.DAL.DBCalls.Contract;
using Namu.DAL.Model;
using Namu.Entity;
using Namu.Entity.DB;
using Namu.Entity.ServicePOCOs;

namespace Namu.DAL.DBCalls
{
    /// <summary>
    /// Clase base para mantenimiento de Proveedores.
    /// </summary>
    public abstract class ProviderBaseDO : IDataObject<Provider>
    {
        /// <summary>
        /// Propiedad necesaria en cualquier hija para expandir el Select y SelectAll.
        /// Cada string del arreglo es es el nombre de una tabla, puede contener 'n' nombres de tablas...
        /// </summary>
        /// <returns>Tablas por incluir</returns>
        public abstract string[] IncludeExpression { get; }

        public virtual async Task<bool> Insert(Provider toInsert)
        {
            var success = await DataObjectHelper.ExecuteWithExceptionHandler(async () =>
            {
                var result = 0;
                using (var context = new dbnamutestEntities())
                {
                    var exists = context.tproviders.Any(p => p.name == toInsert.Name);

                    if (!exists)
                    {
                        context.tproviders.Add(toInsert.GetAsEntityFrameworkGenerated());

                        result = await context.SaveChangesAsync();
                    }
                }
                return result;
            }, GetType().Name);

            return success;
        }

        public virtual async Task<bool> Delete(int idtprovider)
        {
            var success = await DataObjectHelper.ExecuteWithExceptionHandler(async () =>
            {
                var result = 0;
                using (var context = new dbnamutestEntities())
                {
                    var exists = await context.tproviders.FirstOrDefaultAsync(p => p.idtprovider == idtprovider);

                    if (exists != null)
                    {
                        ((IObjectContextAdapter)context).ObjectContext.DeleteObject(exists);

                        result = await context.SaveChangesAsync();
                    }
                }
                return result;
            }, GetType().Name);

            return success;
        }

        public virtual async Task<bool> Update(int idtprovider, Provider toUpdate)
        {
            var success = await DataObjectHelper.ExecuteWithExceptionHandler(async () =>
            {
                var result = 0;
                using (var context = new dbnamutestEntities())
                {
                    var exists = context.tproviders.Attach(toUpdate.GetAsEntityFrameworkGenerated());

                    if (exists != null)
                    {
                        ////campos a actualizar...
                        //context.Entry(exists).Property(p => p.name).IsModified = true;
                        result = await context.SaveChangesAsync();
                    }
                }
                return result;
            }, GetType().Name);

            return success;
        }

        public async Task<List<Provider>> SelectAll()
        {
            var success = await DataObjectHelper.ExecuteSelectWithExceptionHandler(async () =>
            {
                var lst = new List<Provider>();

                using (var context = new dbnamutestEntities())
                {
                    var lstQuery = context.tproviders.AsQueryable();

                    //Utiliza lambda en lugar de foreach con extensión de la librería "Namu.Entity.NamuExtensions"
                    IncludeExpression.Each(s => lstQuery.Include(s));

                    var lstAux = await lstQuery.ToListAsync();
                    lst = lstAux.Select(p => p.GetAsPOCO()).ToList();
                }

                return lst;
            }, GetType().Name);

            return success;
        }

        public async Task<Provider> Select(int idtprovider)
        {
            var success = await DataObjectHelper.ExecuteSelectWithExceptionHandler(async () =>
            {
                var proveedor = new Provider();

                using (var context = new dbnamutestEntities())
                {
                    var lstQuery = context.tproviders
                        .Include(p => p.taddresses)
                        .Where(p => p.idtprovider == idtprovider)
                        .AsQueryable();

                    //Utiliza lambda en lugar de foreach con extensión de la librería "Namu.Entity.NamuExtensions"
                    IncludeExpression.Each(s => lstQuery.Include(s));

                    var aux = await lstQuery.FirstOrDefaultAsync();
                    proveedor = aux.GetAsPOCO();
                }

                return proveedor;
            }, GetType().Name);

            return success;
        }

    }
}
