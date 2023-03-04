using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways] //Editor sirasinda da calisacak
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    public void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();

    }


    void Update()
    {
        if (Application.isPlaying) { return; } // oynarken calismasin sadece editorde calissin

        DisplayCoordinates();

        UpdateObjectName();
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
