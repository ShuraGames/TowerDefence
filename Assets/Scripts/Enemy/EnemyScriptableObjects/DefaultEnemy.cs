using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultEnemy", menuName = "TowerDefence/DefaultEnemy", order = 0)]
public class DefaultEnemy : ScriptableObject {
    public GameObject prefabEnemy;
    public int healthEnemy;
    public int giveMoneyForDeath;
}
