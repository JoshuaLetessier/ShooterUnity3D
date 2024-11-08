using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float walkSpeed = 1f;
    float runSpeed = 5f;

    private PlayerInput input;

    // Start is called before the first frame update
    void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
       input.Disable();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (input != null)
        {
            //input
        }
    }

    private void Walk()
    {
    }

    private void lateralWalk()
    {

    }

    private void Run()
    {

    }

    private void Jump()
    {

    }

    private void Crounsh()
    {

    }

}
