using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField]private float damage = 5f;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") 
        {   
            other.GetComponent<EnemyLife>().healthEnemy -= damage;
            Destroy(gameObject);
        }
    }
}
