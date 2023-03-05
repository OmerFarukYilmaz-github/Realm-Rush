using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable() { return isPlaceable;}

    [SerializeField] GameObject tower;

    public void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
            Instantiate(tower,transform.position, transform.rotation);
            isPlaceable = false;
        }
    }
}
