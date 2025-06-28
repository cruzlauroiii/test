using Microsoft.Extensions.Configuration;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class RoleConfigurationService : IRoleConfigurationService
{
    private readonly IConfiguration _configuration;

    public RoleConfigurationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Dictionary<string, string> GetRoleProperties(string roleName)
    {
        var properties = new Dictionary<string, string>();
        var roleSection = _configuration.GetSection($"RoleSettings:{roleName}");

        if (roleSection.Exists())
        {
            foreach (var child in roleSection.GetChildren())
            {
                properties[child.Key] = child.Value ?? string.Empty;
            }
        }

        return properties;
    }

    public Dictionary<string, string> GetBrokerProperties(
        string membershipNo = "",
        string memberPassword = "",
        int memberId = 0,
        string membershipType = "",
        int staffId = 0,
        string fullName = "",
        string primaryCompany = "",
        string companyGroup = "",
        string companyLogo = "",
        string companyReportLogo = "")
    {
        var properties = new Dictionary<string, string>();

        // Get base settings from configuration
        var baseSettings = GetRoleProperties("Broker");
        foreach (var setting in baseSettings)
        {
            properties[setting.Key] = setting.Value;
        }

        // Add dynamic broker properties from membership data
        properties["Username"] = membershipNo;
        properties["Password"] = memberPassword;
        properties["MemberId"] = memberId.ToString();
        properties["MemberType"] = membershipType;
        properties["StaffId"] = staffId.ToString();
        properties["FullName"] = fullName;
        properties["PrimaryCompany"] = primaryCompany;
        properties["CompanyGroup"] = companyGroup;
        properties["CompanyLogo"] = companyLogo;
        properties["CompanyReportLogo"] = companyReportLogo;

        return properties;
    }

    public Dictionary<string, string> GetDriverProperties(
        bool showCompletedJobs = false,
        string workCompany = "",
        string truckId = "",
        string trailerId = "",
        string trailerId2 = "",
        string trailerId3 = "")
    {
        var properties = new Dictionary<string, string>();

        // Get base settings from configuration
        var baseSettings = GetRoleProperties("Driver");
        foreach (var setting in baseSettings)
        {
            properties[setting.Key] = setting.Value;
        }

        // Add dynamic driver properties from iPad user options and delivery pre-start
        properties["ShowCompletedJobs"] = showCompletedJobs.ToString();
        properties["WorkCompany"] = workCompany;
        properties["TruckID"] = truckId;
        properties["TrailerID"] = trailerId;
        properties["TrailerID2"] = trailerId2;
        properties["TrailerID3"] = trailerId3;

        return properties;
    }

    public Dictionary<string, string> GetFumigationProperties()
    {
        return GetRoleProperties("Fumigation");
    }

    public Dictionary<string, string> GetForkliftProperties()
    {
        return GetRoleProperties("Forklift");
    }

    public Dictionary<string, string> GetITVProperties()
    {
        return GetRoleProperties("ITV");
    }
}