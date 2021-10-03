using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createColliders : MonoBehaviour
{
    [SerializeField]private bool make_triggers = true;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            var mc = child.gameObject.AddComponent<MeshCollider>();
            if (make_triggers)
            {
                mc.convex = true;
                mc.isTrigger = true;
            }
        }
    }
}
