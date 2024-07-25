using Project1.Service;
using Project1.DAO;
using Project1.Entities;

namespace Project1.Tests;

public class UnitTest1
{

    [Fact]
    public void CorrectHitPoint()
    {
        // should return 8
        int hitPoints1 = CharacterCreatorService.HitPointCalculator("Bard");

        Assert.Equal(8, hitPoints1);
        // should return 6

        int hitPoints2 = CharacterCreatorService.HitPointCalculator("Wizard");

        Assert.Equal(6, hitPoints2);

        // should return 10
        int hitPoints3 = CharacterCreatorService.HitPointCalculator("Ranger");

        Assert.Equal(10, hitPoints3);

        // should return 12
        int hitPoints4 = CharacterCreatorService.HitPointCalculator("Barbarian");
        
        Assert.Equal(12, hitPoints4);

        // should throw exception due to invalid character class type
        Assert.Throws<Exception>(()=> CharacterCreatorService.HitPointCalculator("Mage"));

    
        
    }
    // Inline test & theory

    [Fact]
    public void ValidCharacterClassTest(){

    }

    [Fact]
    public void ValidCharacterRaceTest(){

    }

    [Fact]
    public void ValidAccountCreds(){
        
    }

}