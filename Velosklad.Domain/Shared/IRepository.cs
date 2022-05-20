namespace Velosklad.Domain.Shared
{
    public interface IRepository
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
