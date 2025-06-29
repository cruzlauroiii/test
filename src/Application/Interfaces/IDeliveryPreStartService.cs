using Domain.BusinessObjects;

namespace Application.Interfaces;

public interface IDeliveryPreStartService
{
    Task<IEnumerable<DeliveryPreStart>> GetAllDeliveryPreStartsAsync();
    Task<DeliveryPreStart?> GetDeliveryPreStartByIdAsync(int id);
    Task<DeliveryPreStart?> GetDeliveryPreStartByPreStartIdAsync(int preStartId);
    Task<DeliveryPreStart> CreateDeliveryPreStartAsync(DeliveryPreStart deliveryPreStart);
    Task<DeliveryPreStart> UpdateDeliveryPreStartAsync(DeliveryPreStart deliveryPreStart);
    Task<bool> DeleteDeliveryPreStartAsync(int id);
}