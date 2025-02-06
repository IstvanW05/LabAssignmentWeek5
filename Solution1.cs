using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Solution1 : MonoBehaviour
{
    //Declare Variables
    public string CharacterName;
    public int Level;
    public string CharacterClass;
    public int CONScore;
    public bool IsHillDwarf;
    public bool HasToughFeat;
    public bool AveragedRoll;

    //String Array for Classes
    private string[] CharacterClasses = 
        {
        "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", 
        "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock"
        };

    //Dictionary for HitDie
    private Dictionary<string,float> HitDies = new Dictionary<string, float>
    {
        {"Artificer", 8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Fighter", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Wizard", 6},
        {"Warlock", 8}
    };
    //List for CON Modifiers
    private List<int> Modifiers = new List<int> 
    {-5,-4,-4,-3,-3,-2,-2,-1,-1,0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10};
    

    void Start()
    {
        CalculateHP();
    }

    void CalculateHP() 
    {
        // Format class input to match capitalization of dictionary keys
        CharacterClass = CharacterClass.ToLower();
        CharacterClass = char.ToUpper(CharacterClass[0])+CharacterClass.Substring(1);
        
        // Check if character class exists, if not then throw error
        if (CharacterClasses.Contains(CharacterClass))
        {
            // Create private variables for calculating health and outputting final result string
            float HP = 0;
            int Modifier = Modifiers[CONScore - 1];
            string ToughFeatString;
            string HillDwarfString;
            string RollString;
            
            // Check averaged / random option and roll accordingly
            if (AveragedRoll == true)
            {
                HP = (float)(Level * ((HitDies[CharacterClass]/2 + 0.5) + Modifier));
                RollString = "averaged";
            }
            else
            {
                System.Random RandomRoll = new System.Random();
                for (int i = 0; i < Level; i++)
                {
                    HP += RandomRoll.Next(1, (int)(HitDies[CharacterClass] + 1)) + Modifier;
                }
                RollString = "randomized";
            }

            // Add HP for Tough feat and Hill Dwarf, set appropriate strings for the final output
            if (HasToughFeat)
            {
                HP += 2 * Level;
                ToughFeatString = "has";
            }
            else
            {
                ToughFeatString = "does not have";
            }

            if (IsHillDwarf)
            {
                HP += 1 * Level;
                HillDwarfString = "is";
            }
            else
            {
                HillDwarfString = "is not";
            }

            // Output results
            Debug.Log($"My character {CharacterName} is a level {Level} {CharacterClass} with a CON score of {CONScore} and {HillDwarfString} a Hill Dwarf and {ToughFeatString} Tough feat. I want the HP {RollString}");
            Debug.Log($"My Character has {HP} HP");

        }

        else
        {
            Debug.LogError("Invalid Class");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
