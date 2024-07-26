using Project1.DAO;
using Project1.Entities;
using Project1.Utility;

namespace Project1.Service;


// maybe make it unique for pass and username
public class CreateAccountService{

    private readonly LoginDAO _loginDAO;
    private readonly UserDAO _userDAO;
    public CreateAccountService(LoginDAO loginDAO, UserDAO userDAO){
        _loginDAO = loginDAO;
        _userDAO = userDAO;
    }

    public static void ValidAccountCreds(){

    }


    
}