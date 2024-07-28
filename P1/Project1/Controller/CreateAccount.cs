using Project1.DAO;
using Project1.Entities;
using Project1.Service;


namespace Project1.Controller;

// Make service
public class CreateAccount{

    private CreateAccountService createAccountService;

    
    public CreateAccount(CreateAccountService cas){
        createAccountService = cas;

    }

    public void CreateNewAccount(){

        string fName;
        string lName;
        
        //User creds
        Console.WriteLine("----Create New Account----");
        

        bool validUserCreds = false;

        

        do{
            Console.Write("Enter First Name: ");
            fName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            lName = Console.ReadLine();

            try{
                Console.WriteLine("Adding User...");
                createAccountService.AddUser(fName, lName);
                validUserCreds = true;
            }catch(Exception e){
                Console.Error.WriteLine(e.Message);
            }

        }while(!validUserCreds);

        Console.WriteLine("Added User successfully!");

        //Login creds
      

        bool validCreds = false;

        do{
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            try{
                createAccountService.AddLogin(username, password);
                validCreds = true;
            }catch(Exception e){
                Console.Error.WriteLine(e.Message);
            }
        

        }while(!validCreds);
        


    }
}