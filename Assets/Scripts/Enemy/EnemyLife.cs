using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float healthEnemy;

   [SerializeField] private DefaultEnemy defaultEnemy;

   private void Start() 
   {
       healthEnemy = defaultEnemy.healthEnemy;
   }  

   private void Update() 
   {
       if(healthEnemy <= 0)
       {
           MoneyChange.Instance.GetMoney(30);
           Destroy(gameObject);
       }
   }

   
}
