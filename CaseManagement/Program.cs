﻿using CaseManagement.Services;

var memberMenu = new MemberMenuService();
var errorReportMenu = new ErrorReportMenuService();

while(true)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("Välkommen till BRF EC Utbildning Ärendehanteringssystem");
    Console.WriteLine("");
    Console.WriteLine("1. Skapa en felanmälan ");
    Console.WriteLine("2. Skapa en ny hyresgäst");
    Console.WriteLine("");
    Console.WriteLine("Välj ett av ovan allternativ (1-2): ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            errorReportMenu.ErrorReportMenu();
            break;

        case "2":
            Console.Clear();
            await memberMenu.MemberMenu();
            break;
    }
}
