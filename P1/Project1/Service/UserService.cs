using Project1.DAO;
using Project1.Utility;
using Project1.Entities;

namespace Project1.Service;

public class UserService{

    private readonly UserDAO _userDAO;
    private readonly DndCharacterDAO _dndCharacterDAO;

    public UserService(UserDAO userDAO, DndCharacterDAO dndCharacterDAO){
        _userDAO = userDAO;
        _dndCharacterDAO = dndCharacterDAO;

    }

    public ICollection<DndCharacter> GetUsersDndCharacters(){
        int userId = State.currentLogin.UserID;

        List<DndCharacter> dnds = _dndCharacterDAO.GetAll().ToList();
        List<DndCharacter> dndCharacters = _userDAO.GetById(userId).DndCharacters.ToList();
        return dndCharacters;
    }
    

    public void DeleteUserCharacter(string n){
        int userId = State.currentLogin.UserID;
        List<DndCharacter> dndCharacters = _dndCharacterDAO.GetAll().ToList();
        foreach(DndCharacter dnd in dndCharacters){
            if(dnd.CharacterName == n && dnd.UserID == userId){
                _dndCharacterDAO.Delete(dnd);
            }
        }
    }

    




}