using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IEntityMouvement
{

    Vector3 camPosition;
    float camPositionCrounsh = 0.5f;

    Camera cam;

    private PlayerInput input;

    public float walkSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float runSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float crounshSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float speed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float jumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool isCrounsh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool isGrounded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Rigidbody rb { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Start is called before the first frame update
    void Awake()
    {
        input = new PlayerInput();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = this.GetComponentInChildren<Camera>();

        isCrounsh = false;
        isGrounded = true;
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
            Crounsh();
            Run();
            Walk();
            Jump();
            Rotate();
        }
    }

    private void Walk()
    {
        Vector2 vector2 = input.Player.Move.ReadValue<Vector2>();
        if (vector2 != null)
        {
            rb.AddForce(vector2 * speed * Time.deltaTime);
        }
    }

    private void Run()
    {
        if (isCrounsh || !isGrounded)
            return;
        if (input.Player.Run.triggered)
        {
            speed = runSpeed;
        }
        else
            speed = walkSpeed;
    }

    private void Jump()
    {
        if(!isGrounded) return;

        if (input.Player.Jump.triggered)
        {
            rb.AddForce(transform.up * jumpForce);
            isGrounded=false;
        }
    }

    private void Crounsh()
    {
        camPosition = cam.transform.position;
        if(camPosition.y > camPositionCrounsh)
            if(input.Player.Run.triggered)
            {
                camPosition = new Vector3(camPosition.x, camPositionCrounsh, camPosition.z);
                speed = crounshSpeed;
                isCrounsh=true; 
            }

    }

    private void Rotate()
    { }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
