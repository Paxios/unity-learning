using UnityEngine;

// INHERITANCE
public abstract class Animal : MonoBehaviour
{
    // ENCAPSULATION
    protected int NumberOfLegs { private get; set; }

    // ENCAPSULATION
    protected string Name
    {
        get
        {

            return name;
        }
        set
        {
            if (value.Length < 5)
                name = value;
        }
    }
    protected string sound;

    // POLYMORPHISM
    public void SetName(string name)
    {
        this.name = name;
    }
    // POLYMORPHISM
    public void SetName(int number)
    {
        name = "Object " + number;
    }

    // ENCAPSULATION
    public int GetNumberOfLegs()
    {
        return NumberOfLegs;
    }

    // ABSTRACTION
    public virtual void MakeSound()
    {
        print(sound);
    }
    public abstract string GetPetDetails();

}
