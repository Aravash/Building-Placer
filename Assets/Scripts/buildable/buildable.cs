using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildable : MonoBehaviour
{
    [SerializeField]private int currentHouse = 1;

    [SerializeField]private GameObject selectedHouse;

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0) transform.Rotate(0,0,90);
        else if (Input.mouseScrollDelta.y < 0) transform.Rotate(0,0,-90);

        if (Input.GetButtonDown("CycleDown"))
        {
            currentHouse--;
            if (currentHouse <= 0) currentHouse = 9;
            handleBuildingCycle();
        }
        else if (Input.GetButtonDown("CycleUp"))
        {
            currentHouse++;
            if (currentHouse >= 10) currentHouse = 1;
            handleBuildingCycle();
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (selectedHouse.GetComponent<CheckBuildable>().canBuild)
            {
                Instantiate(Resources.Load<GameObject>
                        ("modernHouses/House_" + currentHouse + "_1"),
                    transform.position, transform.rotation, null);
            }
        }
    }

    void handleBuildingCycle()
    {
        Destroy(selectedHouse);
        selectedHouse = Instantiate(Resources.Load<GameObject>
                ("modernHouseRender/House_" + currentHouse + "_1"),
            transform.position, transform.rotation, transform);
        //changeMaterialsOfBuilding(BuildModeMaterials[0]);
    }

    void changeMaterialsOfBuilding(Material newMat)
    {
        MeshRenderer[] mr = transform.GetComponentsInChildren<MeshRenderer>();
        foreach (var rend in mr)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++) {
                mats[j] = newMat; 
            }
            rend.materials = mats;
        }
    }
}
