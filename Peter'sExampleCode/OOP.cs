using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //part 1: creating a character class called hero

        Character hero = new Character();
        Debug.LogFormat("Hero: {0} - {1} EXP", hero.name, hero.exp);


        //part 2: creating 2 characters using differnt constructor and use a class method
        /*
        Character hero = new Character();
        hero.PrintStatsInfo();
        Character heroine = new Character("Agatha");
        heroine.PrintStatsInfo();
        */

        //part 3: reference type passing with classes
        /*
         Character hero = new Character();
         Character hero2 = new Character();
         hero2.name = "Sir Krane the Brave";

         hero.PrintStatsInfo();
         hero2.PrintStatsInfo();
        */

        //part 4: some struct fun

        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        Weapon warBow = huntingBow;

        warBow.name = "War Bow";
        warBow.damage = 155;

        huntingBow.PrintWeaponStats();
        warBow.PrintWeaponStats();


        //part 5 private methods

        //hero.Reset();


        //part 6: inheratance (uncommment part 4)
        /*
        Paladin knight = new Paladin("Sir Arthur");
        knight.PrintStatsInfo();
        */

        //part 7: composition

        Paladin knight2 = new Paladin("Sir That Guy", huntingBow);
        knight2.PrintStatsInfo();


        //part 8: same as part 7 put uncomment part 8s in other files.


    }

    // Update is called once per frame
    void Update()
    {

    }
}
