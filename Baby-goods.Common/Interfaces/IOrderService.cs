namespace Baby_goods.Common.Interfaces
{
    public interface IOrderService
    {
        Task Create(Guid userId, Guid addressId);
    }
}
