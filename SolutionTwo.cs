using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    // Variables for inspector
    public string charName;
    public string charClass;
    public int charLevel;
    public int charCON;
    public bool hillDwarf;
    public bool tough;
    public bool isAverage;

    // Start is called before the first frame update
    void Start()
    {
        Character hero = new Character(charName, charClass, charLevel, charCON, hillDwarf, tough, isAverage);
        hero.printInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Character
{
    // Variables for character
    private string name;
    private string classType;
    private int level;
    private int CON;
    private int HP = 0;
    private bool hillDwarf;
    private bool tough;
    private bool isAverage;

    // Classes and hit die
    private Dictionary<string, int> hitDie = new Dictionary<string, int>()
    {
        {"artificer", 8},
        {"barbarian", 12},
        {"bard", 8},
        {"cleric", 8},
        {"druid", 8},
        {"fighter", 10},
        {"monk", 8},
        {"ranger", 10},
        {"rogue", 8},
        {"paladin", 10},
        {"sorcerer", 6},
        {"wizard", 6},
        {"warlock", 8}
    };

    private List<int> modifiers = new List<int>()
    {-5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10};

    public Character(string name, string classType, int level, int CON, bool hillDwarf, bool tough, bool isAverage)
    {
        this.name = name;
        this.classType = classType;
        this.level = level;
        if (CON > 30) this.CON = 30;
        else if (CON < 1) this.CON = 1;
        else this.CON = CON;
        this.hillDwarf = hillDwarf;
        this.tough = tough;
        this.isAverage = isAverage;
        CalculateHP();
    }

   // Calculate HP 
    private void CalculateHP()
    {
        // Check if valid class
        classType = classType.ToLower();
        if(!hitDie.ContainsKey(classType))
        {
            Debug.LogError("Please use a proper character class.");
            return;
        }

        // Get hit die range for class and add modifier
        int lastNum = hitDie[classType] + modifiers[CON - 1];
        int firstNum = 1 + modifiers[CON - 1];

        // If average, calculate average times level
        // If not, randomize range level times
        if (isAverage)
        {
            HP = (firstNum + lastNum) / 2 * level;
        } else
        {
            for (int i = 0; i < level; i ++)
            {
                HP += Random.Range(firstNum, lastNum);
            }
        }
        
        // If hill dwarf or tough, add HP
        if (hillDwarf) HP += level;
        if (tough) HP += level * 2;
    }

    public void printInfo()
    {
        Debug.Log($"My character {name} is a level {level} {classType} with a CON score of {CON} and {(hillDwarf ? "is" : "is not")} a Hill Dwarf {(tough ? "with" : "without")} the Tough Feat.");
        Debug.Log($"The HP is {(isAverage ? "average" : "randomized")}.");
        Debug.Log($"My character has {HP} HP.");
    }
}