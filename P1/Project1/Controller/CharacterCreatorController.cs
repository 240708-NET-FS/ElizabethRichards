using Project1.Controller;
using Project1.DAO;
using Project1.Entities;
using Project1.Service;
using Project1.Utility;

namespace Project1.Controller{
    public class CharacterCreatorController{

        private CharacterCreatorService charCreateService;
        public CharacterCreatorController(CharacterCreatorService cCService){
            charCreateService = cCService;

        }
        public void Session(){
            Console.WriteLine("\n----Here's where you'll make your character----");
            Console.WriteLine("In this session, you will be creating a playable character for a variety of TTRPG games (Mostly DND 5e).");


            bool valid = false;
            string race = "";



            Console.WriteLine("To start, please type in your character's race from the options below: ");

            do{
                Console.WriteLine("[1] Tiefling\n[2] Human\n[3] Elf\n[4] HalfElf\n[5] HalfOrc\n[6] Gnome\n[7] Dwarf\n[8] Halfling\n[9] Genasi");

            
                   
                var racePick = Console.ReadLine();
                if(CharacterCreatorService.ValidCharacterRace(racePick)){
                    race = racePick;
                    valid = true;

                }else{
                    throw new Exception("Invalid input! Please choose from the options above!");
                }
                
                
            }while(!valid);


            
            Console.WriteLine("\nNext, please type in your character's class from the options below: ");

            bool classValid = false;
            string charClass = "";


            do{
                Console.WriteLine("[1] Paladin\n[2] Fighter\n[3] Barbarian\n[4] Monk\n[5] Rogue\n[6] Ranger\n[7] Cleric\n[8] Druid\n[9] Warlock\n[10] Sorcerer\n[11] Wizard\n[12] Bard");

                try{
                    var charClassPick = Console.ReadLine();
                    if(CharacterCreatorService.ValidCharacterClass(charClassPick)){
                        charClass = charClassPick;
                        classValid = true;
                    }

                    // switch(charClassPick){
                    //     case 1:
                    //         Console.WriteLine("Your character is a Paladin!");
                    //         charClass = "Paladin";
                    //         classValid = true;
                    //         break;
                    //     case 2:
                    //         Console.WriteLine("Your character is a Fighter!");
                    //         charClass = "Fighter";
                    //         classValid = true;
                    //         break;
                    //     case 3:
                    //         Console.WriteLine("Your character is a Barbarian!");
                    //         charClass = "Barbarian";
                    //         classValid = true;
                    //         break;
                    //     case 4:
                    //         Console.WriteLine("Your character is a Monk!");
                    //         charClass = "Monk";
                    //         classValid = true;
                
                    //         break;
                    //     case 5:
                    //         Console.WriteLine("Your character is a Rogue!");
                    //         charClass = "Rogue";
                    //         classValid = true;
                    //         break;
                    //     case 6:
                    //         Console.WriteLine("Your character is a Ranger!");
                    //         charClass = "Ranger";
                    //         classValid = true;
                    //         break;
                    //     case 7:
                    //         Console.WriteLine("Your character is a Cleric!");
                    //         charClass = "Cleric";
                    //         classValid = true;
                    //         break;
                    //     case 8:
                    //         Console.WriteLine("Your character is a Druid!");
                    //         charClass = "Druid";
                    //         classValid = true;
                    //         break;
                    //     case 9:
                    //         Console.WriteLine("Your character is a Warlock!");
                    //         charClass = "Warlock";
                    //         classValid = true;
                    //         break;
                    //     case 10:
                    //         Console.WriteLine("Your character is a Sorcerer!");
                    //         charClass = "Sorcerer";
                    //         classValid = true;
                    //         break;
                    //     case 11:
                    //         Console.WriteLine("Your character is a Wizard!");
                    //         charClass = "Wizard";
                    //         classValid = true;
                    //         break;
                    //     case 12:
                    //         Console.WriteLine("Your character is a Bard!");
                    //         charClass = "Bard";
                    //         classValid = true;
                    //         break;
                        
                    //     default:
                    //         Console.Error.WriteLine("Invalid input! Please pick from the options above!");
                    //         break;
                        
                    // }

                }catch(Exception e){
                    // Console.Error.WriteLine("Invalid input! Please pick from the options above!");
                    throw new Exception("Invalid input! Please pick from the options above!");

                }

            }while(!classValid);


            bool nameValid = false;
            string charName = "";
            Console.WriteLine("\nWith a race and class, you can now pick your character's name!");
            do{
                Console.Write("Character Name: ");
                try{
                    charName = Console.ReadLine();
                    nameValid = true;

                }catch(Exception e){
                    Console.Error.WriteLine("Invalid Input! Please enter a valid name!");
                }
            }while(!nameValid);

            // Console.WriteLine($"\nHere is your character so far:\nName: {charName}\nRace: {race}\nClass: {charClass}");

            
            // Console.WriteLine("\nAre you satisfied with your character?\n[1] Yes\n[2] No");
            // int res = int.Parse(Console.ReadLine());

            if(State.isActive && State.currentLogin != null){
                DndCharacter newCharacter = charCreateService.AddCharacter(charName, race, charClass);
                Console.WriteLine("Congrats! Here's your character: ");
                Console.WriteLine("Name\t\tRace\t\tClass\t\tHit Points");
                Console.WriteLine($"{newCharacter.CharacterName}\t{newCharacter.CharacterRace}\tLevel 1 {newCharacter.CharacterClass}\t{newCharacter.HitPoints}");
                Console.WriteLine("Returning to menu...");

            }else{
                Console.WriteLine("Congrats! Here's your character: ");
                Console.WriteLine($"{charName}\t{race}\t{charClass}");
                Console.WriteLine("To save character, you must be logged in!");
                Console.WriteLine("Returning to menu...");

            }

            
        }

        
    }

    



    
}