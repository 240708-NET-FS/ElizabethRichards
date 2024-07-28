using Project1.DAO;
using Project1.Entities;
using Project1.Utility;

namespace Project1.Service;

public class CreateAccountService{

    private readonly LoginDAO _loginDAO;
    private readonly UserDAO _userDAO;
    public CreateAccountService(LoginDAO loginDAO, UserDAO userDAO){
        _loginDAO = loginDAO;
        _userDAO = userDAO;
    }

    public void AddUser(string fName, string lName){
        if(ValidUserCreds(fName, lName)){
            _userDAO.Create(new User{FirstName=fName, LastName=lName});
        }else{
            throw new Exception("Invalid input! Please enter valid credentials!");
        }
    }

    public void AddLogin(string u, string p){
        if(ValidAccountCreds(u, p) && _loginDAO.GetLoginByUAndP(u, p) == null){
            _loginDAO.Create(new Login{Username=u, Password=p, User=_userDAO.GetAll().Last(), UserID=_userDAO.GetAll().Last().UserID});

        }else{
            throw new Exception("Invalid input! Please enter a valid username and password!");
        }
    }

    public static bool ValidUserCreds(string fName, string lName){
        if(fName.Length == 0 || lName.Length == 0 || fName == null || lName == null){
            return false;
        }else{
            return true;
        }
        
    }

    public static bool ValidAccountCreds(string u, string p){
        if(u.Length == 0 || p.Length == 0 || u == null || p == null){
            return false;
        }else{
          
            return true;
        }

    }




    
}