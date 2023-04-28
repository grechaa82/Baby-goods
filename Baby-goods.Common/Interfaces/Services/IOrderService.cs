namespace Baby_goods.Common.Interfaces.Services
{
    public interface IOrderService
    {
        Task Create(Guid userId, Guid addressId);
    }
}
