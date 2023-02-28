using CaseManagement.Contexts;
using CaseManagement.Models;
using CaseManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagement.Services;

internal class MemberServiceDB
{
    private static DataContext _dataContext = new DataContext();
    public static async Task SaveMemberAsync(MemberModel memberModel)
    {
        var memberEntity = new MemberEntity
        {
            MemberId = memberModel.Id,
            FirstName = memberModel.FirstName,
            LastName = memberModel.LastName,
            Email = memberModel.Email,
            Phone = memberModel.Phone
        };

        var addressEntity = await _dataContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == memberModel.StreetName && x.StreetNumber == memberModel.StreetNumber && x.PostalCode == memberModel.PostalCode && x.City == memberModel.City);
        if (addressEntity != null)
        {
            memberEntity.AddressId = addressEntity.AddressId;
        }
        else
        {
            memberEntity.Address = new AddressEntity
            {
                StreetName = memberModel.StreetName,
                StreetNumber = memberModel.StreetNumber,
                PostalCode = memberModel.PostalCode,
                City = memberModel.City,
            };
        }

        _dataContext.Add(memberEntity);
        await _dataContext.SaveChangesAsync();
    }

    public static async Task<IEnumerable<MemberModel>> GetAllMembersAsync()
    {
        var members = new List<MemberModel>();

        foreach (var member in await _dataContext.Members.Include(x => x.Address).ToListAsync())
            members.Add(new MemberModel
            {
                Id = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone = member.Phone,
                StreetName = member.Address.StreetName,
                StreetNumber = member.Address.StreetNumber,
                PostalCode = member.Address.PostalCode,
                City = member.Address.City,
            });

        return members;
    }

    public static async Task<MemberModel> GetMemberAsync(string email)
    {
        var member = await _dataContext.Members.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (member != null)
        {
            return new MemberModel
            {
                Id = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone = member.Phone,
                StreetName = member.Address.StreetName,
                StreetNumber = member.Address.StreetNumber,
                PostalCode = member.Address.PostalCode,
                City = member.Address.City,
            };
        }
        else
            return null!;
    }

    public static async Task UpdateMemberAsync(MemberModel memberModel)
    {
        var member = await _dataContext.Members.Include(x => x.Address).FirstOrDefaultAsync(x => x.AddressId == memberModel.Id);
        if (member != null)
        {

        }

    }


    public static async Task DeleteMemberAsync(string email)
    {
        var member = await _dataContext.Members.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (member != null)
        {
            _dataContext.Remove(member);
            await _dataContext.SaveChangesAsync();
        }
    }
}
