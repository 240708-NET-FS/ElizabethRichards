using Project1.Controller;
using Project1.Entities;
using Project1.Service;
using Project1.Utility;

namespace Project1.Controller;

public class UserController{
    private CharacterCreatorService characterCreatorService;
    private UserService userService;

    public UserController(UserService uService, CharacterCreatorService charCreatorService){
        characterCreatorService = charCreatorService;
        userService = uService;
    }

    public void UserSession(Login login){
        Console.WriteLine($"\n----Welcome Back {login.Username} to Character Creator!----");
        UserSession();

    }

    public void UserSession(){
        CharacterCreatorController charController = new CharacterCreatorController(characterCreatorService);

        bool valid = false;
        int input;



        do{
            Console.WriteLine();
            if(State.isActive && State.currentLogin != null){
                ShowUserCharacters();
                Console.WriteLine("\n----Please choose from the options below:");
                Console.WriteLine("\n[1] Create a Character\n[2] Remove a Character\n[3] Exit");
            }else{
                Console.WriteLine($"\n----Welcome to Character Creator!----");
                Console.WriteLine("\n----Please choose from the options below:");
                Console.WriteLine("\n[1] Create a Character\n[2] Exit and return to Landing");
            }

            input = int.Parse(Console.ReadLine());

            if(State.isActive && State.currentLogin != null){
                switch(input){
                    case 1:
                        charController.Session();
                        break;
                    case 2:
                        if(userService.GetUsersDndCharacters().Count() != 0){
                            DeleteUserCharacter();
                        }
                        else{
                            Console.WriteLine("No characters to remove! Make one today!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using the Character Creator!");
                        Console.WriteLine("Exiting Program...");
                        valid = true;
                        break;
                    default: 
                        Console.Error.WriteLine("Invalid input! Please pick from the options above!");
                        break;
                    
                        
                }
            }else{
                switch(input){
                case 1:
                    charController.Session();
                    break;
                case 2:
                    Console.WriteLine("Thank you for using the Character Creator!");
                    Console.WriteLine("Exiting Program...");
                    valid = true;
                    break;
                default:
                    Console.Error.WriteLine("Invalid input! Please pick from the options above!");
                    break;

                }
               
            }

        }while(!valid);

    }

    
    void DeleteUserCharacter(){

        Console.WriteLine("Seems the adventure is over for one of your characters");
        Console.WriteLine("Enter the name of the character you wish to remove below");
        Console.Write("Enter Name: ");
        //VALIDATE
        string? name = Console.ReadLine();
        Console.WriteLine($"\nAre you sure you want to delete {name}? Y/N");

        bool valid = false;
        do{
            string? input = Console.ReadLine();
            
                switch(input?.ToLower()){
                    case "y":
                        userService.DeleteUserCharacter(name);
                        Console.WriteLine($"Hope you had many fun adventures with {name}!");
                        valid = true;
                        break;
                    case "n":
                        Console.WriteLine("Returning to menu...");
                        valid = true;
                        break;
                    default:
                        Console.Error.WriteLine("Invalid input! Please enter 'Y' or 'N'"!);
                        break;
                    
                }

            

        }while(!valid);


    }

    public void ShowUserCharacters(){
        ICollection<DndCharacter> characters = userService.GetUsersDndCharacters();
        if(characters.Count() > 0){
            Console.WriteLine($"{State.currentLogin.Username}'s Characters: ");
            int index = 0;
            Console.WriteLine("{0, -5} {1, -15} {2, -15} {3, -20} {4, -5}", "#", "Name", "Race", "Class", "Hit Points");

            foreach(DndCharacter character in characters){

                Console.WriteLine("{0, -5} {1, -15} {2, -15} {3, -20} {4, -5}", ++index, character.CharacterName, character.CharacterRace, "Level 1 " + character.CharacterClass, "\t" + character.HitPoints);
            }
        }else{
            Console.WriteLine("No characters yet! Make one today!");
        }

    }


    
       
}