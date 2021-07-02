using UnityEngine;

// INHERITANCE
public abstract class Animal
{
    // ENCAPSULATION
    protected int NumberOfLegs { private get; set; }

    // ENCAPSULATION
    protected string Name
    {
        get
        {

            return Name;
        }
        set
        {
            if (value.Length < 5)
                Name = value;
        }
    }
    protected string sound;

    // POLYMORPHISM
    public void SetName(string name)
    {
        this.Name = name;
    }
    // POLYMORPHISM
    public void SetName(int number)
    {
        Name = "Object " + number;
    }

    // ENCAPSULATION
    public int GetNumberOfLegs()
    {
        return NumberOfLegs;
    }

    // ABSTRACTION
    public virtual void MakeSound()
    {
        ShowText(sound);
    }
    public abstract string GetPetDetails();

    public void ShowText(string text)
    {
        Debug.Log(text);
    }

}
