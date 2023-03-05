using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int poolSize = 5;
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0.1f,30f)]float spawnTimer = 2f;

    GameObject[] pool;

    public void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        
        for(int i=0; i<pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }

    }

    public void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectsInPool();
            yield return new WaitForSeconds(spawnTimer);
        }


    }

    private void EnableObjectsInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if( ! pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
