namespace LuizaEM.Infra.Transactions
{
    /// <summary>
    /// Unit of Work Transaction for commit in DB
    /// </summary>
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
