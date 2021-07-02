// INHERITANCE
public class Pig : Animal
{
    public Pig(string name)
    {
        base.Name = name;
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
        ShowText(GetPetDetails() + " " + GetPetDetails());
    }
}
