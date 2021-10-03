using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Player
{
    [SerializeField] private Animator fox;
    private static readonly int Speed = Animator.StringToHash("speed");

    void Start()
    {
        PlayerStart();
    }
    void Update()
    {
        //neither of these yet
        CalculateGround();
        Gravity();

        GetInput();

        CalculateCamera();

        MovePlane();

        jones.Move(velocity * Time.deltaTime);

        AnimateFox();
    }

    void AnimateFox()
    {
        if (input.magnitude > 0) fox.SetFloat(Speed, 1);
        else fox.SetFloat(Speed, 0);
    }
}