﻿namespace CaseManagement.Services;


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
            Console.WriteLine("4. Uppdatera en hyresgäst ");
            Console.WriteLine("5. Ta bort en hyresgäst");
            Console.WriteLine("6. Återgå till huvudmenyn");

            string answer = Console.ReadLine() ?? "";

            switch(answer)
            {
                case "1":
                    Console.Clear();
                    await addMember.CreateMemberAsync();
                    break;

                case "2":
                    Console.Clear();
                    await addMember.ListAllMembersAsync();
                    break;

                case "3":
                    Console.Clear();
                    await addMember.GetOneMemberAsync();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Uppdatera en");
                    break;

                case "5":
                    Console.Clear();
                    await addMember.DeleteMemberAsync();
                    break;

                default:
                    Console.WriteLine("Välj mellan alternativ 1-6: ");
                    break;
            }
            if(answer == "6")
            {
                break;
            }
            Console.ReadKey();
        }
    }
}