using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipie", menuName = "Inventory/Recipie")]
public class Recipie : ScriptableObject {
    public Item Input01;
    public Item Input02;
    public Item Result;
}
