namespace CaseManagement.Services;


public class MemberMenuService
{
    public async Task MemberMenu()
    {
        var addMember = new AddMemberService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Skapa en hyregäst ");
            Console.WriteLine("2. Visa alla hyresgäster ");
            Console.WriteLine("3. Visa en hyresgäst ");
            Console.WriteLine("4. Ta bort en hyresgäst");
            Console.WriteLine("5. Återgå till huvudmenyn");

            string answer = Console.ReadLine() ?? "";

            switch(answer)
            {
                case "1":
                    Console.Clear();
                    await addMember.CreateMemberAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                case "2":
                    Console.Clear();
                    await addMember.ListAllMembersAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                case "3":
                    Console.Clear();
                    await addMember.GetOneMemberAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                case "4":
                    Console.Clear();
                    await addMember.DeleteMemberAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                default:
                    Console.WriteLine("Välj mellan alternativ 1-5: ");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;
            }
            if(answer == "5")
            {
                break;
            }
            Console.ReadKey();
        }
    }
}
