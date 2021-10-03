using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePivot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = .5f;
    [SerializeField]private float desired_rotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("RotateCamLeft"))
        {
            desired_rotation += 90;
        }
        else if (Input.GetButtonDown("RotateCamRight"))
        {
            desired_rotation -= 90;
        }

        if (transform.rotation.y != desired_rotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(transform.rotation.x, desired_rotation,
                                transform.rotation.z), Time.deltaTime * moveSpeed);
        }
    }
}
