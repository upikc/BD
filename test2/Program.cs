using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;

user UUUUU = new("upik", "90", "gmail");
Console.WriteLine($"{UUUUU.full_name} {UUUUU.T_number} {UUUUU.Mail}");


class user
{
    public user(string FF, string T, string M) =>
    (full_name, T_number, Mail) = (FF, T, M);

    public string full_name;
    public string T_number;
    public string Mail;
}
