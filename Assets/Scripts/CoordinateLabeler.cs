using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways] //Editor sirasinda da calisacak
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinate ;
    Waypoint waypoint;

    public void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
    }


    void Update()
    {
        ColorDebug();
        ToggleLabels();

        if (Application.isPlaying) { return; } // oynarken calismasin sadece editorde calissin

        DisplayCoordinates();

        UpdateObjectName();
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void ColorDebug()
    {
        if (waypoint.IsPlaceable())
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    private void UpdateObjectName()
    {
        transform.parent.name = "Tile "+label.text;
    }

    private void DisplayCoordinates()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);// ustten baktigimiz icin y yerine z kullanicaz 
        label.text = $"{coordinate.x},{coordinate.y}";    
    
    }
}
