using Project1.DAO;
using Project1.Utility;
using Project1.Entities;

namespace Project1.Service;

public class UserService{

    private readonly UserDAO _userDAO;

    public UserService(UserDAO userDAO){
        _userDAO = userDAO;

    }

    public ICollection<DndCharacter> GetUsersDndCharacters(){
        int userId = State.currentLogin.UserID;
        ICollection<DndCharacter> dndCharacters = _userDAO.GetById(userId).DndCharacters;
        foreach(DndCharacter character in dndCharacters){
            Console.WriteLine(character);
        }

        return dndCharacters;
    }
}