// INHERITANCE
public class Dog : Animal
{

    public Dog(string name)
    {
        base.name = name;
        NumberOfLegs = 4;
        sound = "Woof";
    }

    // POLYMORPHISM
    public override string GetPetDetails()
    {
        string s = $"{name} is a good boy with {GetNumberOfLegs()} legs.";
        print(s);
        return s;
    }

    // POLYMORPHISM
    public override void MakeSound()
    {
        print($"{sound}!,{sound}!!");
    }

    // ABSTRACTION
    public void Growl()
    {
        print("Grrrrrrrrrrrrrrrrrrr");
    }
    
}
