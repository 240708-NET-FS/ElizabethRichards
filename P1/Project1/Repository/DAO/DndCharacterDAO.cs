using Project1.Entities;

namespace Project1.DAO;

public class DndCharacterDAO : IDAO<DndCharacter>{

    private ApplicationDbContext _context;

    public DndCharacterDAO(ApplicationDbContext context){
        _context = context;
    }

    public void Create(DndCharacter item){
        _context.DndCharacter.Add(item);
        _context.SaveChanges();

    }

    public void Update(DndCharacter item){
        //TODO

    }   

    public void Delete(DndCharacter item){


    }

    public ICollection<DndCharacter> GetAll(){
        List<DndCharacter> dndCharacters = _context.DndCharacter.ToList();
        return dndCharacters;

    }

    public DndCharacter GetById(int id){

        DndCharacter dndCharacter = _context.DndCharacter.FirstOrDefault(d => d.DndCharacterId == id);
        return dndCharacter;
    }

    public DndCharacter GetByName(string n){
        DndCharacter dndCharacter = _context.DndCharacter.FirstOrDefault(d => d.CharacterName == n);
        return dndCharacter;
    }

}