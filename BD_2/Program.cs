using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Unicode;

var domains = File.ReadAllLines("domain_lst.txt").ToHashSet();
string[] list = File.ReadAllLines("text.txt" , Encoding.UTF8);
List<user> users = new List<user>();
foreach (string l in list) users.Add(new user(l.Trim()));   


Regex regexNumber = new Regex(@"(^7|^\+7|^8)(\(\d{3}\)\d{7}$|\d{10}$)");
Regex regexMail = new Regex(@"^\w{5,14}@\w{3,11}\.(\w{2,})");

var NONnormal_number = from u in users
                    where !regexNumber.IsMatch(u.T_number)
                    select u;

var NONnormal_mail = from u in users
                   where !(regexMail.IsMatch(u.Mail) && domains.Contains(regexMail.Match(u.Mail).Groups[1].Value))
                   select u;
  
var SIGMA = from u in users
                    where (regexNumber.IsMatch(u.T_number) && (regexMail.IsMatch(u.Mail) && domains.Contains(regexMail.Match(u.Mail).Groups[1].Value)))
                    select u;

string Exit1 = "";
foreach (user u in NONnormal_number) Exit1 += ($"{u.full_name};{u.T_number};{u.Mail}\n");
File.WriteAllText("NoValidNumber.txt" , Exit1);


string Exit2 = "";
foreach (user u in NONnormal_mail) Exit2 += ($"{u.full_name};{u.T_number};{u.Mail}\n");
File.WriteAllText("NoValidMail.txt", Exit2);


string Exit3 = "";
foreach (user u in SIGMA) Exit3 += ($"{u.full_name};{u.T_number};{u.Mail}\n");
File.WriteAllText("Valid.txt", Exit3);


class user
{
    public user(string UserData)
    {
        full_name = UserData.Split(";")[0];
        Mail = UserData.Split(";")[1];
        T_number = UserData.Split(";")[2];

    }

    public string full_name;
    public string T_number;
    public string Mail;
}

