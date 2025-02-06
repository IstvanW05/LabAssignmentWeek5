using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{

    //class variables
    public string name;
    public int exp = 0;


    //constructor
    public Character()
    {
        name = "Not assigned";
    }

    //constructor 
    public Character(string name)
    {
        this.name = name;
    }

    //class method
    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - {1} EXP", name, exp);
    }

    // part 8: polymorphism 
    /*
    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - {1} EXP", name, exp);
    }
    */

    // part 5: what happens with a private method?
    public void Reset()
    {
        this.name = "Not assigned";
        this.exp = 0;
    }
}
