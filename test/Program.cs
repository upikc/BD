using System.Text.RegularExpressions;
using System.IO;


Regex regex = new Regex(@"(^\+7|^8)(\(\d{3}\)\d{7}$|\d{10}$)");

var List = new string[]
{
    "+7(937)3699112",
    "+79373699112",
    "+7(937)36991121",
    "+793736991121",
    "8(937)3699112",
    "89373699112"
};

foreach (string S in List)
{
    Console.WriteLine(regex.Match(S));
}



