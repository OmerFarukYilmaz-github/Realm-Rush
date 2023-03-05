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
        FindPath();
        StartOnFirstPathTile();
        StartCoroutine(MoveOnPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject pathHolder = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform childPath in pathHolder.transform)
        {
            path.Add(childPath.GetComponent<Waypoint>());
        }

    }

    void StartOnFirstPathTile()
    {
        transform.position = path[0].transform.position;
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

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
