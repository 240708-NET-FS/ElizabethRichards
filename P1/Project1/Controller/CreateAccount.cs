using Project1.DAO;
using Project1.Entities;


namespace Project1.Controller;

// Make service
public class CreateAccount{
    private readonly UserDAO _userDAO;
    private readonly LoginDAO _loginDAO;
    public CreateAccount(UserDAO userDAO, LoginDAO loginDAO){
        _userDAO = userDAO;
        _loginDAO = loginDAO;

    }

    public void CreateNewAccount(){
        
        //User creds
        Console.WriteLine("----Create New Account----");
        Console.Write("Enter First Name: ");
        string fName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lName = Console.ReadLine();

        Console.WriteLine("Adding User...");
        _userDAO.Create(new User{FirstName=fName, LastName=lName});
        Console.WriteLine("Added User successfully!");

        //Login creds
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        bool validCreds = false;

        do{

            try{
                _loginDAO.Create(new Login{Username=username, Password=password, User=_userDAO.GetAll().Last(), UserID =_userDAO.GetAll().Last().UserID});
                validCreds = true;
            }catch(Exception e){
                throw new Exception("");
            }
        

        }while(!validCreds);
        


    }
}