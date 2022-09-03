using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class CardsInfo : ScriptableObject
{
    public Sprite image;

    public new string name;
    public string description;

    public int manaCost;

}
