using Microsoft.EntityFrameworkCore;
using Domain.BusinessObjects;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Data.Repositories.Internal;

public class MembershipRepository : IMembershipRepository
{
    private readonly ApplicationDbContext _context;

    public MembershipRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Membership>> GetAllAsync()
    {
        return await _context.Memberships
            .Include(m => m.Staff)
            .Include(m => m.Contact)
            .Include(m => m.MembershipTypeEntity)
            .ToListAsync();
    }

    public async Task<Membership?> GetByIdAsync(int id)
    {
        return await _context.Memberships
            .Include(m => m.Staff)
            .Include(m => m.Contact)
            .Include(m => m.MembershipTypeEntity)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Membership>> GetByStaffIdAsync(int staffId)
    {
        return await _context.Memberships
            .Include(m => m.Staff)
            .Include(m => m.Contact)
            .Include(m => m.MembershipTypeEntity)
            .Where(m => m.RemoteStaffId == staffId)
            .ToListAsync();
    }

    public async Task<Membership> CreateAsync(Membership membership)
    {
        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();
        return membership;
    }

    public async Task<Membership> UpdateAsync(Membership membership)
    {
        _context.Memberships.Update(membership);
        await _context.SaveChangesAsync();
        return membership;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var membership = await _context.Memberships.FindAsync(id);
        if (membership == null)
            return false;

        _context.Memberships.Remove(membership);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class MembershipTypeRepository : IMembershipTypeRepository
{
    private readonly ApplicationDbContext _context;

    public MembershipTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MembershipType>> GetAllAsync()
    {
        return await _context.MembershipTypes
            .Include(mt => mt.Staff)
            .ToListAsync();
    }

    public async Task<MembershipType?> GetByIdAsync(int id)
    {
        return await _context.MembershipTypes
            .Include(mt => mt.Staff)
            .FirstOrDefaultAsync(mt => mt.Id == id);
    }

    public async Task<IEnumerable<MembershipType>> GetByStaffIdAsync(int staffId)
    {
        return await _context.MembershipTypes
            .Include(mt => mt.Staff)
            .Where(mt => mt.RemoteStaffId == staffId)
            .ToListAsync();
    }

    public async Task<MembershipType> CreateAsync(MembershipType membershipType)
    {
        _context.MembershipTypes.Add(membershipType);
        await _context.SaveChangesAsync();
        return membershipType;
    }

    public async Task<MembershipType> UpdateAsync(MembershipType membershipType)
    {
        _context.MembershipTypes.Update(membershipType);
        await _context.SaveChangesAsync();
        return membershipType;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var membershipType = await _context.MembershipTypes.FindAsync(id);
        if (membershipType == null)
            return false;

        _context.MembershipTypes.Remove(membershipType);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await _context.Contacts
            .Include(c => c.AssociatedCompany)
            .ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _context.Contacts
            .Include(c => c.AssociatedCompany)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Contact> CreateAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
            return false;

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class AssociatedCompanyRepository : IAssociatedCompanyRepository
{
    private readonly ApplicationDbContext _context;

    public AssociatedCompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AssociatedCompany>> GetAllAsync()
    {
        return await _context.AssociatedCompanies.ToListAsync();
    }

    public async Task<AssociatedCompany?> GetByIdAsync(int id)
    {
        return await _context.AssociatedCompanies.FindAsync(id);
    }

    public async Task<AssociatedCompany?> GetByCompanyCodeAsync(string companyCode)
    {
        return await _context.AssociatedCompanies
            .FirstOrDefaultAsync(ac => ac.CompanyCode == companyCode);
    }

    public async Task<AssociatedCompany> CreateAsync(AssociatedCompany associatedCompany)
    {
        _context.AssociatedCompanies.Add(associatedCompany);
        await _context.SaveChangesAsync();
        return associatedCompany;
    }

    public async Task<AssociatedCompany> UpdateAsync(AssociatedCompany associatedCompany)
    {
        _context.AssociatedCompanies.Update(associatedCompany);
        await _context.SaveChangesAsync();
        return associatedCompany;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var associatedCompany = await _context.AssociatedCompanies.FindAsync(id);
        if (associatedCompany == null)
            return false;

        _context.AssociatedCompanies.Remove(associatedCompany);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class IPadUserOptionRepository : IIPadUserOptionRepository
{
    private readonly ApplicationDbContext _context;

    public IPadUserOptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IPadUserOption>> GetAllAsync()
    {
        return await _context.IPadUserOptions
            .Include(ipo => ipo.Staff)
            .Include(ipo => ipo.DeliveryPreStart)
            .ToListAsync();
    }

    public async Task<IPadUserOption?> GetByIdAsync(int id)
    {
        return await _context.IPadUserOptions
            .Include(ipo => ipo.Staff)
            .Include(ipo => ipo.DeliveryPreStart)
            .FirstOrDefaultAsync(ipo => ipo.Id == id);
    }

    public async Task<IPadUserOption?> GetByStaffIdAsync(int staffId)
    {
        return await _context.IPadUserOptions
            .Include(ipo => ipo.Staff)
            .Include(ipo => ipo.DeliveryPreStart)
            .FirstOrDefaultAsync(ipo => ipo.StaffId == staffId);
    }

    public async Task<IPadUserOption> CreateAsync(IPadUserOption iPadUserOption)
    {
        _context.IPadUserOptions.Add(iPadUserOption);
        await _context.SaveChangesAsync();
        return iPadUserOption;
    }

    public async Task<IPadUserOption> UpdateAsync(IPadUserOption iPadUserOption)
    {
        _context.IPadUserOptions.Update(iPadUserOption);
        await _context.SaveChangesAsync();
        return iPadUserOption;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var iPadUserOption = await _context.IPadUserOptions.FindAsync(id);
        if (iPadUserOption == null)
            return false;

        _context.IPadUserOptions.Remove(iPadUserOption);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class DeliveryPreStartRepository : IDeliveryPreStartRepository
{
    private readonly ApplicationDbContext _context;

    public DeliveryPreStartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DeliveryPreStart>> GetAllAsync()
    {
        return await _context.DeliveryPreStarts.ToListAsync();
    }

    public async Task<DeliveryPreStart?> GetByIdAsync(int id)
    {
        return await _context.DeliveryPreStarts.FindAsync(id);
    }

    public async Task<DeliveryPreStart?> GetByPreStartIdAsync(int preStartId)
    {
        return await _context.DeliveryPreStarts
            .FirstOrDefaultAsync(dps => dps.PreStartId == preStartId);
    }

    public async Task<DeliveryPreStart> CreateAsync(DeliveryPreStart deliveryPreStart)
    {
        _context.DeliveryPreStarts.Add(deliveryPreStart);
        await _context.SaveChangesAsync();
        return deliveryPreStart;
    }

    public async Task<DeliveryPreStart> UpdateAsync(DeliveryPreStart deliveryPreStart)
    {
        _context.DeliveryPreStarts.Update(deliveryPreStart);
        await _context.SaveChangesAsync();
        return deliveryPreStart;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deliveryPreStart = await _context.DeliveryPreStarts.FindAsync(id);
        if (deliveryPreStart == null)
            return false;

        _context.DeliveryPreStarts.Remove(deliveryPreStart);
        await _context.SaveChangesAsync();
        return true;
    }
}