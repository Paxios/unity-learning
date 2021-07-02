// INHERITANCE
public class Cat : Animal
{

    public Cat(string name)
    {
        base.name = name;
        NumberOfLegs = 4;
        sound = "Meow";
    }

    // POLYMORPHISM
    public override string GetPetDetails()
    {
        return ($"{name} is a Cat with {GetNumberOfLegs()} and it sound is: {sound} ");
    }

    // ABSTRACTION
    public void Purr()
    {
        print("Purrrrrrrrrrrrrrrrrr");
    }
}
