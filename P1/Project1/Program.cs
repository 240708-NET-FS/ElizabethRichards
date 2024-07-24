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


           // check in table creation for constraints
            using(var context = new ApplicationDbContext()){
                UserDAO userDAO = new UserDAO(context);
                LoginDAO loginDAO = new LoginDAO(context);
                DndCharacterDAO dndCharacterDAO = new DndCharacterDAO(context);

                LoginService loginService = new LoginService(loginDAO);
                CharacterCreatorService charService = new CharacterCreatorService(dndCharacterDAO);

                Console.WriteLine("Welcome to the Character Creator!(Not affiliated with DND Beyond)");
                Console.WriteLine("----Please choose option below----");

                int response;

                bool valid = false;

                LoginController loginController = new LoginController(loginService);
                UserController userController = new UserController(charService);

                do{
                    Console.WriteLine("[1] Login with Username and Password\n[2] Continue as Guest");
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
                                valid = true;
                                userController.UserSession();
                                break;
                            default:
                                valid = false;
                                Console.Error.WriteLine("Invalid input! Please pick option 1 or 2!");
                                break;

                        }

                        valid = true;

                    }catch (Exception e){
                        Console.Error.WriteLine("Invalid input! Please pick option 1 or 2!");
                    }
                }while(!valid);

                    // userDAO.Create(new User{FirstName = "temporary", LastName = "user"});
                    // ICollection<User> users = userDAO.GetAll();

                    // foreach(User u in users){
                    //     Console.WriteLine(u);
                    // }

                    // loginDAO.Create(new Login{Username = "username", Password = "password", UserID = 1});
                    
                    // ICollection<Login> logins = loginDAO.GetAll();
                    // foreach(Login l in logins){
                    //     Console.WriteLine(l);
                    // }

                    // User u = userDAO.GetById(1);

                    // dndCharacterDAO.Create(new DndCharacter{CharacterName="Spindle Bells", CharacterClass="Bard", CharacterRace="Tiefling", UserID = 1, User = u});
                    // dndCharacterDAO.Create(new DndCharacter{CharacterName="Zephyr Dreylta", CharacterClass="Ranger", CharacterRace="Tiefling", UserID = 1, User = u});

                    // ICollection<DndCharacter> dndChars = dndCharacterDAO.GetAll();

                    // foreach(DndCharacter d in dndChars){
                    //     Console.WriteLine(d);
                    // }
                }

            // dotnet new webapi --use-controllers -o {YourAppName}

            // }
            
        }

    }
