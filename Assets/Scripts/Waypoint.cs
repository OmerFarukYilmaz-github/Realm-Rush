using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable() { return isPlaceable;}

    [SerializeField] Tower tower;

    public void OnMouseDown()
    {
        if (isPlaceable)
        {
           bool isPlaced = tower.PlaceTower(tower, transform.position);
           isPlaceable = !isPlaced;
        }
    }
}
 