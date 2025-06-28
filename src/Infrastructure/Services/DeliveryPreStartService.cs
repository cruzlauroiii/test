using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class DeliveryPreStartService
{
    private readonly IDeliveryPreStartRepository _deliveryPreStartRepository;

    public DeliveryPreStartService(IDeliveryPreStartRepository deliveryPreStartRepository)
    {
        _deliveryPreStartRepository = deliveryPreStartRepository;
    }

    public async Task<IEnumerable<DeliveryPreStart>> GetAllDeliveryPreStartsAsync()
    {
        return await _deliveryPreStartRepository.GetAllAsync();
    }

    public async Task<DeliveryPreStart?> GetDeliveryPreStartByIdAsync(int id)
    {
        return await _deliveryPreStartRepository.GetByIdAsync(id);
    }

    public async Task<DeliveryPreStart?> GetDeliveryPreStartByPreStartIdAsync(int preStartId)
    {
        return await _deliveryPreStartRepository.GetByPreStartIdAsync(preStartId);
    }

    public async Task<DeliveryPreStart> CreateDeliveryPreStartAsync(DeliveryPreStart deliveryPreStart)
    {
        return await _deliveryPreStartRepository.CreateAsync(deliveryPreStart);
    }

    public async Task<DeliveryPreStart> UpdateDeliveryPreStartAsync(DeliveryPreStart deliveryPreStart)
    {
        return await _deliveryPreStartRepository.UpdateAsync(deliveryPreStart);
    }

    public async Task<bool> DeleteDeliveryPreStartAsync(int id)
    {
        return await _deliveryPreStartRepository.DeleteAsync(id);
    }
}