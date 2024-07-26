using Project1.DAO;
using Project1.Entities;
using Project1.Utility;

namespace Project1.Service;

public class CharacterCreatorService{
    private readonly DndCharacterDAO _dndCharDAO;

    public CharacterCreatorService(DndCharacterDAO dndCharDAO){
        _dndCharDAO = dndCharDAO;
    }

    public DndCharacter AddCharacter(string n, string r, string c){
        if(!ValidCharacterClass(c) || !ValidCharacterRace(r) || r.Length == 0 || r == null){
            throw new Exception("Invalid values for Character!");
        }
        int hitPoints = HitPointCalculator(c);

        _dndCharDAO.Create(new DndCharacter{CharacterName=n, CharacterRace=r, CharacterClass=c, HitPoints=hitPoints, User=State.currentLogin.User, UserID=State.currentLogin.UserID});
        return _dndCharDAO.GetByName(n);
    }

    public static int HitPointCalculator(string charClass){

        if(!ValidCharacterClass(charClass)){
            throw new Exception("Invalid character class!");

        }else{
             if(charClass == "Sorcerer" || charClass == "Wizard"){
                return 6;
            }else if(charClass == "Fighter" || charClass == "Paladin" || charClass == "Ranger"){
                return 10;
            }else if(charClass == "Barbarian"){
                return 12;
            }else{
                return 8;
            }
        }

    }
    public static bool ValidCharacterClass(string input){
        if(input.Length > 0 && input != null){
                    string firstChar = input[0].ToString().ToUpper();
                    string cutInput = input.Substring(1);
                    input = firstChar + cutInput;
                    return Enum.IsDefined(typeof(CharacterClass), input);

        }else{
            return false;

        }

    }

    public static bool ValidCharacterRace(string input){

        if(input.Length > 0 && input != null){
            string firstChar = input[0].ToString().ToUpper();
            string cutInput = input.Substring(1);
            input = firstChar + cutInput;
            return Enum.IsDefined(typeof(CharacterRaces), input);

        }else{
            return false;
        }


    }

    public static bool ValidCharacterName(string input){
        return input != null && input.Length > 0;
    }



}