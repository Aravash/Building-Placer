using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridPlacer : MonoBehaviour
{
    //the object to move
    public Transform objectToMove;

    public Transform testObj;

    private int mask = 1 << 3;

    [SerializeField]private int grid_scalar = 2;

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, mask))
        {

            Vector3 rounded_point = new Vector3(roundToGridScalar(hit.point.x) + grid_scalar/2,
                roundToGridScalar(hit.point.y), roundToGridScalar(hit.point.z) + grid_scalar/2);

            testObj.position = hit.point;
            objectToMove.position = rounded_point;
        }
    }

    float roundToGridScalar(float value)
    {
        int new_value = (int)Math.Round(value) / grid_scalar;
        new_value *= grid_scalar;
        return new_value;
    }
}
