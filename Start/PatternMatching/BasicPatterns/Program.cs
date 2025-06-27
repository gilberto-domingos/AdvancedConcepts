// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// C# Pattern Matching for type testing
#pragma warning disable CS8321

string? str = "no null";

if(str is null)
 ArgumentNullException.ThrowIfNull(str);
Console.WriteLine($"{str}");



void DashedLine(object o) {
    
    // int l = 0;
    // if (o.GetType() == typeof(int)) {
    //     l = (int)o;
    // }
    // string s;
    // if (o.GetType() == typeof(string)) {
    //     s = (string)o;
    //     if (!int.TryParse(s, out l)) {
    //         l = 0;
    //     }
    // }
    // if (l > 0) {
    //     string str = new string('-', l);
    //     Console.WriteLine(str);
    // }
    
    if (o is int l || (o is string s && int.TryParse(s, out l)))
    {
        string str = new string('-', l);
        Console.WriteLine(str);
    }
}

// DashedLine(25);
// DashedLine("50");
// DashedLine(20.5);


bool IsTheIdesOfMarch(DateTime date)
{
    return (date is { Month: 3, Day: 14 or 15 });
}

Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 1, 13)));
Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 3, 14)));
Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 3, 15)));
Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 3, 16)));
