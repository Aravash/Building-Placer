using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuildable : MonoBehaviour
{

    public bool canBuild = true;
    [SerializeField][ColorUsage(true, true)]
    private Color[] colours;
    [SerializeField]private List<GameObject> objects_colliding_with = new List<GameObject>();

    private void Awake()
    {
        canBuild = true;
        changeShader(colours[0]);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if (!ValidToCollide(other.name)) return;
        canBuild = false;
        objects_colliding_with.Add(other.gameObject);
        changeShader(colours[1]);
    }

    private void OnTriggerExit(Collider other)
    {
        objects_colliding_with.Remove(other.gameObject);
        if (objects_colliding_with.Count > 0) return;
        canBuild = true;
        changeShader(colours[0]);
    }

    void changeShader(Color c)
    {
        foreach (var r in transform.GetComponentsInChildren<Renderer>())
        {
            foreach (var mat in r.materials)
            {
                mat.color = c;   
            }
        }
    }
}
