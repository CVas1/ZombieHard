using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ZombieSO : ScriptableObject
{
    public GameObject zombiePrefab;
    public string zombieName;
    public int zombieSpeed;
    public int zombieHealth;
    public int zombieMaxHealth;
    public int zombieDamage;
}
