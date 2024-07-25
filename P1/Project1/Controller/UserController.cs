using Project1.Controller;
using Project1.Entities;
using Project1.Service;
using Project1.Utility;

namespace Project1.Controller;

public class UserController{
    //private UserService userService;
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

    static void UserPrompt(){
        Console.WriteLine("----Please choose from the options below:");

         if(State.isActive && State.currentLogin != null){
            Console.WriteLine("\n[1] Create a Character\n[2] View Characters\n[3] Exit");
        }else{
            Console.WriteLine("\n[1] Create a Character\n[2] Exit and return to Landing");
        }


    }
    public void UserSession(){

    
        CharacterCreatorController charController = new CharacterCreatorController(characterCreatorService);

        bool valid = false;

        do{
            UserPrompt();

            try{
                int input = int.Parse(Console.ReadLine());
                if(State.isActive && State.currentLogin != null){
                    switch(input){
                        case 1:
                            charController.Session();
                            // valid = true;
                            break;
                        case 2: 
                            ShowUserCharacters();
                        
                            break;
                    
                        case 3:
                            Console.WriteLine("Exit");
                            valid = true;
                            break;
                        default:
                            Console.Error.WriteLine("Invalid Input! Please enter a valid option!");
                            break;
                        }

                }else{
                    switch(input){
                        case 1: 
                            charController.Session();
                            break;
                        case 2:
                            Console.WriteLine("Exit and Return to Landing");
                            valid = true;
                            break;
                        default:
                            Console.Error.WriteLine("Invalid Input! Please enter a valid option!");
                            break;
                    }

                }
           
            }
            catch(Exception e){
                Console.Error.WriteLine("Invalid Input! Please pick from the options above!");
            }

        }while(!valid);    
       
    }

    void ShowUserCharacters(){
        ICollection<DndCharacter> characters = userService.GetUsersDndCharacters();
        if(characters != null){
            Console.WriteLine($"{State.currentLogin.Username}'s Characters: ");
            int index = 0;
            foreach(DndCharacter character in characters){
                Console.WriteLine($"{++index} {character.CharacterName}\t{character.CharacterRace}\tLevel 1 {character.CharacterClass}\t{character.HitPoints}");
            }
        }else{
            Console.WriteLine("No characters yet! Make one today!");
        }

    }

       
}