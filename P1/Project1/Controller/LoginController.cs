using Project1.DAO;
using Project1.Entities;
using Project1.Service;


namespace Project1.Controller;


public class LoginController{
    private LoginService loginService;

    public LoginController(LoginService service){
        loginService = service;
    }

    public void LoginSession(){
        Console.WriteLine("---- Login Below ----");
        Console.WriteLine("Temporary Login Credentials: Username: 'temporary'\tPassword: 'password'");
        
        string u = "";
        string p = "";
       

        bool valid = false;
        do{
            Console.Write("\nPlease enter username: ");
            u = Console.ReadLine();

            Console.Write("Please enter your password: ");
            p = Console.ReadLine();
            try{
                Login login = loginService.Login(u, p);
                valid = true;
            }catch(Exception e){
                Console.Error.WriteLine(e.Message);
            }

        }while(!valid);
        
        

    }

   
}