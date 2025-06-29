using Riok.Mapperly.Abstractions;
using Domain.BusinessObjects;
using BlazorWebApp.Client.DTO.Membership;

namespace BlazorWebApp.Client.DTO.Membership;

[Mapper]
public partial class MembershipMapper
{
    public partial MembershipDto ToDto(Domain.BusinessObjects.Membership membership);
    public partial Domain.BusinessObjects.Membership ToEntity(CreateMembershipDto createMembershipDto);
    public partial Domain.BusinessObjects.Membership ToEntity(UpdateMembershipDto updateMembershipDto);
    public partial List<MembershipDto> ToDtoList(List<Domain.BusinessObjects.Membership> membershipList);
}