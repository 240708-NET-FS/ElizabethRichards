using Project1.DAO;
using Project1.Entities;
using Project1.Utility;

namespace Project1.Service;

public class LoginService{
    private readonly LoginDAO _loginDAO;

    public LoginService(LoginDAO loginDAO){
        _loginDAO = loginDAO;
    }

    public Login Login(string u, string p){

        if(u.Length == 0 || p.Length == 0){
            throw new Exception("Invalid Input!");
        }
        Login login = _loginDAO.GetLoginByUAndP(u, p);

        if(login != null){
            State.isActive = true;
            State.currentLogin = login;
            return login;
        }

        throw new Exception("Invalid login information!");
    }
}