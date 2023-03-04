using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] float movementDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(PrintPathCoordinates());
    }

    private IEnumerator PrintPathCoordinates()
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSecondsRealtime(movementDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
