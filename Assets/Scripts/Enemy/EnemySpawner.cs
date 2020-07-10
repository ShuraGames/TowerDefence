using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private DefaultEnemy enmyPrefabSpawn;
    [SerializeField]private Transform startCheck;

    private void Start() {
        StartCoroutine(routine: SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for(var i = 0; i < 5; i++)
        {
            GameObject newEnemy = Instantiate(enmyPrefabSpawn.prefabEnemy, startCheck.position, Quaternion.identity);
            EnemyList.lastEnemy = newEnemy.transform;
            if(EnemyList.lastEnemy != null)
            {
                EnemyList.nextEnemy = EnemyList.lastEnemy;
            }
            EnemyList.ListEnemyObj.Add(newEnemy);
            yield return new WaitForSeconds(5);
        }
    }
}
