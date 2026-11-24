using System;

namespace PracticeLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        BrowserHistory browser = new BrowserHistory("home.com");

        browser.Visits("google.com");
        browser.Visits("github.com");
        browser.ShowHistory();

        Console.WriteLine(browser.Back(1));
        browser.ShowHistory();

        browser.Visits("stackoverflow.com");
        browser.ShowHistory();

        Console.WriteLine(browser.Back(2));
        browser.ShowHistory();

        Console.WriteLine(browser.Forward(1));
        browser.ShowHistory();

        Console.WriteLine($"Поточна сторінка: {browser.GetCurrentPage()}");
    }
}