using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public string RecipeName;
    public Item RecipeOutcome;
    public List<Item> RequiredItems = new List<Item>();
}