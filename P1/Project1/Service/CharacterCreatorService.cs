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
        if(n.Length == 0 || r.Length == 0 || c.Length == 0){
            throw new Exception("Invalid values for Character!");
        }

        _dndCharDAO.Create(new DndCharacter{CharacterName=n, CharacterRace=r, CharacterClass=c, User=State.currentLogin.User, UserID=State.currentLogin.UserID});
        return _dndCharDAO.GetByName(n);
    }


}