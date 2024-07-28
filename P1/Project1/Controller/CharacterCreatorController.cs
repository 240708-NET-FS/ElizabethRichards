using Project1.Controller;
using Project1.DAO;
using Project1.Entities;
using Project1.Service;
using Project1.Utility;

namespace Project1.Controller;
public class CharacterCreatorController{

    private CharacterCreatorService charCreateService;
    public CharacterCreatorController(CharacterCreatorService cCService){
        charCreateService = cCService;

    }

    public void Session(){
        Console.WriteLine("\n----Here's where you'll make your character----");
        Console.WriteLine("In this session, you will be creating a playable character for a variety of TTRPG games (Mostly DND 5e).");


    
        string race = PickCharacterRace();
        string charClass = PickCharacterClass();
        string charName = PickCharacterName();
        

        if(State.isActive && State.currentLogin != null){
            DndCharacter newCharacter = charCreateService.AddCharacter(charName, race, charClass);
            Console.WriteLine("Congrats! Here's your character: ");
            Console.WriteLine("{0, -5} {1, -15} {2, -15} {3, -15}", "Name", "Race", "Class", "Hit Points");
            Console.WriteLine("{0, -5} {1, -15} {2, -15} {3, -15}", newCharacter.CharacterName, newCharacter.CharacterRace, "Level 1", newCharacter.CharacterClass, newCharacter.HitPoints);

            Console.WriteLine("Returning to menu...");

        }else{
            Console.WriteLine("Congrats! Here's your character: ");
            Console.WriteLine($"{charName}\t{race}\t{charClass}");
            Console.WriteLine("To save character, you must be logged in!");
            Console.WriteLine("Returning to menu...");

        }

    }

    static string PickCharacterRace(){
        bool valid = false;
        string race = "";

        Console.WriteLine("To start, please type in your character's race from the options below: ");

        do{
            Console.WriteLine("[1] Tiefling\n[2] Human\n[3] Elf\n[4] HalfElf\n[5] HalfOrc\n[6] Gnome\n[7] Dwarf\n[8] Halfling\n[9] Genasi");
        
            Console.Write("Enter Character Race: ");
            var racePick = Console.ReadLine();
            
            if(CharacterCreatorService.ValidCharacterRace(racePick)){
                race = racePick;
                valid = true;
            }else{
                Console.Error.WriteLine("Invalid input!\n");
            }

        }while(!valid);

        Console.WriteLine($"Your character is a {race}!");

        return race;

    }

    static string PickCharacterClass(){
        bool classValid = false;
        string charClass = "";
        
        do{
            Console.WriteLine("[1] Paladin\n[2] Fighter\n[3] Barbarian\n[4] Monk\n[5] Rogue\n[6] Ranger\n[7] Cleric\n[8] Druid\n[9] Warlock\n[10] Sorcerer\n[11] Wizard\n[12] Bard");

            try{
                Console.Write("Enter Character Class: ");
                var charClassPick = Console.ReadLine();
                if(CharacterCreatorService.ValidCharacterClass(charClassPick)){
                    charClass = charClassPick;
                    classValid = true;
                }else{
                    Console.Error.WriteLine("Invalid input!");
                }

            }catch(Exception e){
                throw new Exception("Invalid input! Please pick from the options above!");

            }

        }while(!classValid);

        Console.WriteLine($"Your character is a {charClass}!");

        return charClass;
    }

    static string PickCharacterName(){
        bool nameValid = false;
        string charName = "";
        Console.WriteLine("\nWith a race and class, you can now pick your character's name!");
        do{
            Console.Write("Character Name: ");
            charName = Console.ReadLine();
            
            if(CharacterCreatorService.ValidCharacterName(charName)){
                nameValid = true;
            }else{
                Console.Error.WriteLine("Invalid input! Please enter a valid name!");
            }

        }while(!nameValid);

        return charName;


    }
    
}








