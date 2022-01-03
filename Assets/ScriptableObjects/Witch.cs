using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Witch", order = 1)]
public class Witch : ScriptableObject
{
    public string firstName;
    public string lastName;
    public int health;
    
    [Range(1, 100)]
    public int publicHysteria;

    [Header("Percentage chance to pass test")]
    [Range(1, 100)]
    public int touchTest = 50;
    [Range(1, 100)]
    public int waterTest = 50;
    [Range(1, 100)]
    public int prayerTest = 50;
    [Range(1, 100)]
    public int cakeTest = 50;
    [Range(1, 100)]
    public int markTest = 50;
    [Range(1, 100)]
    public int prickTest = 50;
    [Range(1, 100)]
    public int incantationTest;

    [Space(10)]
    [TextArea(5,100)]
    public string biography;
    [TextArea(5, 100)]
    public string accusation;


}
