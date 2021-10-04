using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTabManager : MonoBehaviour
{

    private Animator anim; // need to make the animator
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    
    //have reference to building placer script
    //have the new building_type int here instead of there

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }
    
    public void ToggleTabState()
    {
        anim.SetBool(IsOpen, !anim.GetBool(IsOpen));
    }

    public void SelectBuilding(int building_num)
    {
        //call building placer script
        //tell it to change the thing here based on passed in building_num
    }
}