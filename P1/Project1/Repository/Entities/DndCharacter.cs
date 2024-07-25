namespace Project1.Entities;


public class DndCharacter{

    public int DndCharacterId {get; set;}

    public string CharacterName {get; set;}

    public string CharacterRace {get; set;}

    public string CharacterClass {get; set;}

    public int HitPoints {get; set;}

    public int UserID {get; set;}
    public User User {get; set;}

    public override string ToString()
    {
        return $"{DndCharacterId} {CharacterName} {CharacterRace} {CharacterClass} {HitPoints} {UserID} {User}";
    }


}