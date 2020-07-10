using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float healthEnemy;

   [SerializeField] private DefaultEnemy defaultEnemy;
   private MoneyChange moneyChange;

   private void Start() 
   {
       moneyChange = GameObject.FindWithTag("MoneyManager").GetComponent<MoneyChange>();
       healthEnemy = defaultEnemy.healthEnemy;
   }  

   private void Update() 
   {
       if(healthEnemy <= 0)
       {
           moneyChange.GetMoney(defaultEnemy.giveMoneyForDeath);
           Destroy(gameObject);
       }
   }

   
}
