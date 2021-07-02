// INHERITANCE
public class Pig : Animal
{
    public Pig(string name)
    {
        base.name = name;
        NumberOfLegs = 4;
        sound = "Oink";
    }

    // POLYMORPHISM
    public override string GetPetDetails()
    {
        return "Oiiiiiiiiiink";
    }

    // ABSTRACTION
    public void Squeal()
    {
        print(GetPetDetails() + " " + GetPetDetails());
    }
}
