// INHERITANCE
public class Cat : Animal
{

    public Cat(string name)
    {
        base.Name = name;
        NumberOfLegs = 4;
        sound = "Meow";
    }

    // POLYMORPHISM
    public override string GetPetDetails()
    {
        return ($"{Name} is a Cat with {GetNumberOfLegs()} and it sound is: {sound} ");
    }

    // ABSTRACTION
    public void Purr()
    {

        ShowText("Purrrrrrrrrrrrrrrrrr");
    }
}
