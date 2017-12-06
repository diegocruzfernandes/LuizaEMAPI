namespace LuizaEM.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
