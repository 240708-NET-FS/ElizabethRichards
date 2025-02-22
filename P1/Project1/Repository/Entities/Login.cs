
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Entities;

public class Login
{
    public int LoginID {get;set;}
    public string Username {get;set;}
    public string Password {get;set;}

    public int UserID {get;set;}

    public User User {get;set;}

    public override string ToString()
    {
        return $"{LoginID} {Username} {Password} {UserID} {User}";
    }
}