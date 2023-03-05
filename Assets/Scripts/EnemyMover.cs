using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] [Range(0,5f)] float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(MoveOnPath());
    }

    private IEnumerator MoveOnPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(targetPosition);

            while (travelPercent < 1f)
            {
                //Debug.Log("Moving to "+waypoint.name);
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, targetPosition, travelPercent * moveSpeed);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
