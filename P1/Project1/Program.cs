using Microsoft.Extensions.Options;
using Project1.Entities;
using Project1.DAO;
// using Project1.Migrations;

namespace Project1{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("Hello, World!");

            using(var context = new ApplicationDbContext()){
                UserDAO userDAO = new UserDAO(context);
                DndCharacterDAO dndCharacterDAO = new DndCharacterDAO(context);

                // userDAO.Create(new User{FirstName = "Elizabeth", LastName = "Richards"});
                // ICollection<User> users = userDAO.GetAll();

                // foreach(User u in users){
                //     Console.WriteLine(u);
                // }

                User u = userDAO.GetById(1);

                dndCharacterDAO.Create(new DndCharacter{CharacterName="Spindle Bells", CharacterClass="Bard", CharacterRace="Tiefling", UserID = 1, User = u});
                dndCharacterDAO.Create(new DndCharacter{CharacterName="Zephyr Dreylta", CharacterClass="Ranger", CharacterRace="Tiefling", UserID = 1, User = u});

                ICollection<DndCharacter> dndChars = dndCharacterDAO.GetAll();

                foreach(DndCharacter d in dndChars){
                    Console.WriteLine(d);
                }


            }
            // Console.WriteLine("Welcome to the Character Creator!(Not affiliated with DND Beyond)");
            // Console.WriteLine("----Please choose option below---- ");

            // int response;

            // bool valid = false;

            // do{
            //     Console.WriteLine("[1] Login with Username and Password\n[2] Continue as Guest");
            //     try{
            //         response = int.Parse(Console.ReadLine());

            //         switch(response){
            //             case 1:
            //                 valid = true;
            //                 Console.WriteLine("Login");
            //                 break;
            //             case 2: 
            //                 valid = true;
            //                 Console.WriteLine("Guest");
            //                 break;
            //             default:
            //                 valid = false;
            //                 Console.Error.WriteLine("Invalid input! Please pick option 1 or 2!");
            //                 continue;

            //         }

            //         valid = true;

            //     }catch (Exception e){
            //         Console.Error.WriteLine("Invalid input! Please pick option 1 or 2!");
            //     }
            // }while(!valid);
        }

    }
}