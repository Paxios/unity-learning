// INHERITANCE
public class Dog : Animal
{

    public Dog(string name)
    {
        base.Name = name;
        NumberOfLegs = 4;
        sound = "Woof";
    }

    // POLYMORPHISM
    public override string GetPetDetails()
    {
        string s = $"{Name} is a good boy with {GetNumberOfLegs()} legs.";
        ShowText(s);
        return s;
    }

    // POLYMORPHISM
    public override void MakeSound()
    {
        ShowText($"{sound}!,{sound}!!");
    }

    // ABSTRACTION
    public void Growl()
    {
        ShowText("Grrrrrrrrrrrrrrrrrrr");
    }
    
}
