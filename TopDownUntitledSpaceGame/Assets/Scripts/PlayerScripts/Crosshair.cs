using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Vector3 MouseCoords;
    //public GameObject crosshair;
    public float MouseSensitivity = 10.0f;
    void Update()
    {
        MouseCoords = Input.mousePosition;
        MouseCoords = Camera.main.ScreenToWorldPoint(MouseCoords);
        //Vector3 MouseCoords = MouseCoords.position;
        MouseCoords.z = transform.position.z;
        transform.position = MouseCoords;
        //crosshair.transform.position = Vector2.Lerp(transform.position, MouseCoords, MouseSensitivity);
        //print(MouseCoords);

    }
}
