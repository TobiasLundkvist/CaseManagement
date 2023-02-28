using CaseManagement.Models;

namespace CaseManagement.Services;

internal class AddMemberService
{
    public async Task CreateMemberAsync()
    {
        var member = new MemberModel();

        Console.WriteLine("Förnamn: ");
        member.FirstName = Console.ReadLine() ?? "";

        Console.WriteLine("Efternamn: ");
        member.LastName = Console.ReadLine() ?? "";

        Console.WriteLine("E-postadress: ");
        member.Email = Console.ReadLine() ?? "";

        Console.WriteLine("Mobilnummer: ");
        member.Phone = Console.ReadLine() ?? "";

        Console.WriteLine("Gatuadress: ");
        member.StreetName = Console.ReadLine() ?? "";

        Console.WriteLine("Gatunummer: ");
        member.StreetNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Postnummer: ");
        member.PostalCode = Console.ReadLine() ?? "";

        Console.WriteLine("Stad: ");
        member.City = Console.ReadLine() ?? "";

        await MemberServiceDB.SaveMemberAsync(member);
    }

    public async Task ListAllMembersAsync()
    {
        var members = await MemberServiceDB.GetAllMembersAsync();

        if (members.Any())
        {
            foreach (var member in members)
            {
                Console.WriteLine($"Kundnummer: {member.Id}");
                Console.WriteLine($"Namn: {member.FirstName} {member.LastName}");
                Console.WriteLine($"E-postadress: {member.Email}");
                Console.WriteLine($"Mobilnummer: {member.Phone}");
                Console.WriteLine($"Address: {member.StreetName} {member.StreetNumber}, {member.PostalCode} {member.City}");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Finns ingen hyresgäst...");

        }
    }

    public async Task GetOneMemberAsync()
    {
        Console.WriteLine("Ange E-postadressen på hyresgästen: ");
        var email = Console.ReadLine();

        if(email != null)
        {
            var member = await MemberServiceDB.GetMemberAsync(email);
            if (member != null)
            {
                Console.WriteLine($"Kundnummer: {member.Id}");
                Console.WriteLine($"Namn: {member.FirstName} {member.LastName}");
                Console.WriteLine($"E-postadress: {member.Email}");
                Console.WriteLine($"Mobilnummer: {member.Phone}");
                Console.WriteLine($"Address: {member.StreetName} {member.StreetNumber}, {member.PostalCode} {member.City}");
                Console.WriteLine("");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Finns ingen hyregäst med {email} som E-postadress");
                Console.WriteLine();
            }
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange en korrekt E-postadress");
            Console.WriteLine("");
        }
    }

    public async Task DeleteMemberAsync()
    {
        Console.WriteLine("Ange E-postadressen på hyresgästen: ");
        var email = Console.ReadLine();

        if (email != null)
        {
            await MemberServiceDB.DeleteMemberAsync(email);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ingen hyregäst med angiven E-postadress funnen");
            Console.WriteLine("");
        }
    }
}
