using Riok.Mapperly.Abstractions;
using BlazorWebApp.Client.DTO.Staff;
using Domain.BusinessObjects;

namespace BlazorWebApp.Client.DTO;

[Mapper]
public partial class StaffMapper
{
    // Map from Domain Staff BusinessObject to Client Staff DTO
    public partial Staff MapToDto(Domain.BusinessObjects.Staff staff);
    
    // Map from Client CreateStaff DTO to Domain Staff BusinessObject  
    public partial Domain.BusinessObjects.Staff MapFromCreateDto(CreateStaff createStaff);
    
    // Map from Client UpdateStaff DTO to Domain Staff BusinessObject
    public partial Domain.BusinessObjects.Staff MapFromUpdateDto(UpdateStaff updateStaff);
    
    // Map from Client ChangePassword DTO to Domain Staff BusinessObject
    public partial Domain.BusinessObjects.Staff MapFromChangePasswordDto(ChangePassword changePassword);
    
    // Map from Client Login DTO for authentication
    public partial Domain.BusinessObjects.Staff MapFromLoginDto(Login login);
}