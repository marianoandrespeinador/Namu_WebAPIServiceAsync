namespace Namu.DAL.DBCalls
{
    public class ProviderTourDO : ProviderBaseDO
    {
        private const string ProviderTourTable = "tprovider_tourtype";
        private const string ProviderTourToursTable = "tprovider_tourtype.ttours";

        public override string[] IncludeExpression
        {
            get { return new[] { ProviderTourTable, ProviderTourToursTable }; }
        }
    }
}
