using Domain.BusinessObjects;

namespace Domain.Interfaces;

public interface IStaffRepository
{
    Task<IEnumerable<Staff>> GetAllAsync();
    Task<Staff?> GetByIdAsync(int id);
    Task<Staff?> GetByUsernameAsync(string username);
    Task<Staff?> GetByStaffIdAsync(int staffId);
    Task<Staff> CreateAsync(Staff staff);
    Task<Staff> UpdateAsync(Staff staff);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(string username);
    Task<bool> ExistsByStaffIdAsync(int staffId);
}

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(int id);
    Task<Role?> GetByIdWithPropertiesAsync(int id);
    Task<Role> CreateAsync(Role role);
    Task<Role> UpdateAsync(Role role);
    Task<bool> DeleteAsync(int id);
}

public interface IRolePropertyRepository
{
    Task<IEnumerable<RoleProperty>> GetByRoleIdAsync(int roleId);
    Task<RoleProperty?> GetByIdAsync(int id);
    Task<RoleProperty?> GetByRoleIdAndKeyAsync(int roleId, string key);
    Task<RoleProperty> CreateAsync(RoleProperty roleProperty);
    Task<RoleProperty> UpdateAsync(RoleProperty roleProperty);
    Task<bool> DeleteAsync(int id);
    Task<bool> DeleteByRoleIdAndKeyAsync(int roleId, string key);
}

public interface IMembershipRepository
{
    Task<IEnumerable<Membership>> GetAllAsync();
    Task<Membership?> GetByIdAsync(int id);
    Task<IEnumerable<Membership>> GetByStaffIdAsync(int staffId);
    Task<Membership> CreateAsync(Membership membership);
    Task<Membership> UpdateAsync(Membership membership);
    Task<bool> DeleteAsync(int id);
}

public interface IMembershipTypeRepository
{
    Task<IEnumerable<MembershipType>> GetAllAsync();
    Task<MembershipType?> GetByIdAsync(int id);
    Task<IEnumerable<MembershipType>> GetByStaffIdAsync(int staffId);
    Task<MembershipType> CreateAsync(MembershipType membershipType);
    Task<MembershipType> UpdateAsync(MembershipType membershipType);
    Task<bool> DeleteAsync(int id);
}

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact> CreateAsync(Contact contact);
    Task<Contact> UpdateAsync(Contact contact);
    Task<bool> DeleteAsync(int id);
}

public interface IAssociatedCompanyRepository
{
    Task<IEnumerable<AssociatedCompany>> GetAllAsync();
    Task<AssociatedCompany?> GetByIdAsync(int id);
    Task<AssociatedCompany?> GetByCompanyCodeAsync(string companyCode);
    Task<AssociatedCompany> CreateAsync(AssociatedCompany associatedCompany);
    Task<AssociatedCompany> UpdateAsync(AssociatedCompany associatedCompany);
    Task<bool> DeleteAsync(int id);
}

public interface IIPadUserOptionRepository
{
    Task<IEnumerable<IPadUserOption>> GetAllAsync();
    Task<IPadUserOption?> GetByIdAsync(int id);
    Task<IPadUserOption?> GetByStaffIdAsync(int staffId);
    Task<IPadUserOption> CreateAsync(IPadUserOption iPadUserOption);
    Task<IPadUserOption> UpdateAsync(IPadUserOption iPadUserOption);
    Task<bool> DeleteAsync(int id);
}

public interface IDeliveryPreStartRepository
{
    Task<IEnumerable<DeliveryPreStart>> GetAllAsync();
    Task<DeliveryPreStart?> GetByIdAsync(int id);
    Task<DeliveryPreStart?> GetByPreStartIdAsync(int preStartId);
    Task<DeliveryPreStart> CreateAsync(DeliveryPreStart deliveryPreStart);
    Task<DeliveryPreStart> UpdateAsync(DeliveryPreStart deliveryPreStart);
    Task<bool> DeleteAsync(int id);
}

public interface ISessionService
{
    Task SetCurrentRoleOnlyAsync(string roleName);
    string? GetCurrentSessionRole();
    Task<bool> HasSessionRoleAsync(string roleName);
    void ClearSessionRoles();
    T? GetSessionData<T>(string key);
    void SetSessionData<T>(string key, T value);
}

public interface IRoleConfigurationService
{
    Dictionary<string, string> GetRoleProperties(string roleName);
    Dictionary<string, string> GetBrokerProperties(
        string membershipNo = "",
        string memberPassword = "",
        int memberId = 0,
        string membershipType = "",
        int staffId = 0,
        string fullName = "",
        string primaryCompany = "",
        string companyGroup = "",
        string companyLogo = "",
        string companyReportLogo = "");
    Dictionary<string, string> GetDriverProperties(
        bool showCompletedJobs = false,
        string workCompany = "",
        string truckId = "",
        string trailerId = "",
        string trailerId2 = "",
        string trailerId3 = "");
    Dictionary<string, string> GetFumigationProperties();
    Dictionary<string, string> GetForkliftProperties();
    Dictionary<string, string> GetITVProperties();
}

public interface IAuthService
{
    Task<bool> AuthenticateAsync(string username, string password);
    Task<string> HashPasswordAsync(string password);
    Task<bool> VerifyPasswordAsync(string password, string hash);
    Task<string> GenerateTokenAsync(Staff staff);
}