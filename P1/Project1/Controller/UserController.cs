using Project1.Controller;
using Project1.Entities;
using Project1.Service;
using Project1.Utility;

namespace Project1.Controller;

public class UserController{
    //private UserService userService;
    private CharacterCreatorService characterCreatorService;

    public UserController(CharacterCreatorService charCreatorService){
        characterCreatorService = charCreatorService;

    }

    public void UserSession(Login login){
        Console.WriteLine($"\n----Welcome Back {login.Username} to Character Creator!----");
        UserSession();

    }
    public void UserSession(){
        Console.WriteLine("----Please choose from the options below:");
        
        if(State.isActive && State.currentLogin != null){
            Console.WriteLine("[1] Create a Character\n[2] View Characters\n[3] Update Characters\n[4] Exit");
        }else{
            Console.WriteLine("[1] Create a Character\n[2] Exit and return to Login");
        }

                


        CharacterCreatorController charController = new CharacterCreatorController(characterCreatorService);

        bool valid = false;

        do{
            try{
                int input = int.Parse(Console.ReadLine());
                if(State.isActive && State.currentLogin != null){
                    switch(input){
                        case 1:
                            charController.Session();
                            valid = true;
                            break;
                        case 2: 
                            Console.WriteLine("See characters!");
                            valid = true;
                            break;
                        case 3:
                            Console.WriteLine("Update characters");
                            valid = true;
                            break;
                        case 4:
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
                            valid = true;
                            Console.WriteLine("Welcome Back!"); //TODO: loop
                            break;
                        case 2:
                            Console.WriteLine("Exit");
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

}