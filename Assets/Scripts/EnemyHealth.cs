using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint=5;
    int currentHitPoint = 0;
    Enemy enemy;


    public void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    public void OnParticleCollision(GameObject other)
    {
        ProcessHit();    
    }

    private void ProcessHit()
    {
        currentHitPoint--;

        if(currentHitPoint <=0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
