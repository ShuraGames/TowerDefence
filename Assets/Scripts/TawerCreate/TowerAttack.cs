using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour {
    [HideInInspector] public Transform target;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float minimalDistance;
    [SerializeField] private Transform children;

    private float timeState;
    private float defaultTime = 0.5f;
    private float distanceToLast;

    private void Start () 
    {
        timeState = defaultTime;
    }

    private void Update () 
    {
        if (target != null) 
        {
            children.LookAt(target);

            if (timeState <= 0) 
            {
                var createBullet = Instantiate(bulletPrefab, children.position, children.rotation);
                createBullet.GetComponent<BulletMove>().target = target;
                timeState = defaultTime;
            } 
            else 
            {
                timeState -= Time.deltaTime;
            }
        }
    }
}