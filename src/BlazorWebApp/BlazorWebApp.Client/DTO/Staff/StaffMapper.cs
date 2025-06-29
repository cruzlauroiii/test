using Riok.Mapperly.Abstractions;
using Domain.BusinessObjects;
using BlazorWebApp.Client.DTO.Staff;

namespace BlazorWebApp.Client.DTO.Staff;

[Mapper]
public partial class StaffMapper
{
    public partial StaffDto ToDto(Staff staff);
    public partial Staff ToEntity(CreateStaffDto createStaffDto);
    public partial Staff ToEntity(UpdateStaffDto updateStaffDto);
    public partial List<StaffDto> ToDtoList(List<Staff> staffList);
}