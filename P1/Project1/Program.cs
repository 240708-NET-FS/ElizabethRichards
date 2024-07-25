using Microsoft.Extensions.Options;
using Project1.Entities;
using Project1.DAO;
using Project1.Controller;
using Project1.Service;
using Project1.Utility;
// using Project1.Migrations;


namespace Project1;
    public class Program{
        public static void Main(string[] args){

            using(var context = new ApplicationDbContext()){
                UserDAO userDAO = new UserDAO(context);
                LoginDAO loginDAO = new LoginDAO(context);
                DndCharacterDAO dndCharacterDAO = new DndCharacterDAO(context);

                LoginService loginService = new LoginService(loginDAO);
                CharacterCreatorService charService = new CharacterCreatorService(dndCharacterDAO);
                UserService userService = new UserService(userDAO);

                // userDAO.Create(new User{FirstName="temporary", LastName="user"});
                // loginDAO.Create(new Login{Username="temporary", Password="password", UserID=1});
              

                Console.WriteLine("Welcome to the Character Creator!(Not affiliated with DND Beyond)");
                Console.WriteLine("----Please choose option below----");

                int response;

                bool valid = false;

                LoginController loginController = new LoginController(loginService);
                UserController userController = new UserController(userService, charService);
                CreateAccount createAccount = new CreateAccount(userDAO, loginDAO);



                do{
                    Console.WriteLine("[1] Login with Username and Password\n[2] Create Account\n[3] Continue as Guest");
                    try{
                        response = int.Parse(Console.ReadLine());

                        switch(response){
                            case 1:
                                valid = true;
                                loginController.LoginSession();
                                Console.WriteLine("Successully logged in!\n");
                                userController.UserSession(State.currentLogin);  
                                break;
                            case 2:
                                createAccount.CreateNewAccount();
                                Console.WriteLine("Successfully created account!\nPlease login to access Character Creator!");
                                loginController.LoginSession();
                                userController.UserSession(State.currentLogin);
                                break;
                            case 3: 
                                userController.UserSession();
                                // valid = true
                                break;
                            default:
                                valid = false;
                                Console.Error.WriteLine("Invalid input! Please pick from the options above!");
                                break;

                        }


                    }catch (Exception e){
                        Console.Error.WriteLine("Invalid input! Please pick from the options above!");
                    }
                }while(!valid);

                }

           
            
        }

    }
