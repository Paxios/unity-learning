using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    private Dog dog;
    private Cat cat;
    private Pig pig;
    private void Start()
    {
        dog = new Dog("Sparky");
        cat = new Cat("Misty");
        pig = new Pig("Akoshy");
    }

    public void OnAnimalSelect(Dropdown change)
    {
        switch (change.value)
        {
            case 0: {
                    dog.MakeSound();
                    break; }
            case 1: {
                    cat.MakeSound();
                    break; }
            case 2:
                {
                    pig.MakeSound();
                    break;
                }
            default: { print("This does not exist"); break; }
        }
    }
}
