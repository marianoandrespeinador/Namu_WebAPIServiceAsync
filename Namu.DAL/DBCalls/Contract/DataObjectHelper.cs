using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Namu.Entity;

namespace Namu.DAL.DBCalls.Contract
{
    public static class DataObjectHelper
    {
        public static void LogError(DbEntityValidationException dbEx, string module)
        {
            var sb = new StringBuilder();
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                validationErrors.ValidationErrors.Select
                    (
                        e =>
                            sb.AppendLine(string.Format("Propiedad: {0}. Error: {1}", e.PropertyName,
                                e.ErrorMessage))
                    );
            }

            Logger.Error(sb.ToString(), module);
        }

        /// <summary>
        /// Corre el codigo de conexion de BD con control de excepciones
        /// </summary>
        public static async Task<bool> ExecuteWithExceptionHandler(Func<Task<int>> toRun, string moduleName)
        {
            var result = 0;

            try
            {
                result = await toRun();
            }
            catch (DbEntityValidationException dbEx)
            {
                LogError(dbEx, moduleName);
            }
            catch (Exception e)
            {
                Logger.Error(e, moduleName);
            }

            return result > 0;
        }

        /// <summary>
        /// Corre el codigo de conexion de BD con control de excepciones
        /// </summary>
        public static async Task<TSource> ExecuteSelectWithExceptionHandler<TSource>(
            Func<Task<TSource>> toRun, string moduleName)
        {
            var item = default(TSource);

            try
            {
                item = await toRun();
            }
            catch (DbEntityValidationException dbEx)
            {
                LogError(dbEx, moduleName);
            }
            catch (Exception e)
            {
                Logger.Error(e, moduleName);
            }

            return item;
        }

    }
}
