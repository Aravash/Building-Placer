using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobaMovement : MonoBehaviour
{
    [SerializeField] private Animator fox;

    Vector2 input;

    int UnitsPerSec = 5;
    private static readonly int Speed = Animator.StringToHash("speed");

    void Update ()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        input = Vector2.ClampMagnitude(input, 1);

        if (input.x != 0 || input.y != 0) fox.SetFloat(Speed, 1);
        else fox.SetFloat(Speed, 0);

        //make object's x position increase by the Horizontal input option over time
        transform.position += new Vector3(input.x, 0, input.y) * (Time.deltaTime * UnitsPerSec);
    }
}
