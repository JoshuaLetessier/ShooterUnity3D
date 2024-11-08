using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Walk,
    Run,
    Jump,
    Crounsh,
    Idle,
}

public class EnnemyMouvement : MonoBehaviour, IEntityMouvement
{

    public GameObject m_Player;
    public Vector3 m_PlayerPosition;

    public float walkSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float runSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float crounshSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float speed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float jumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool isCrounsh { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool isGrounded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Rigidbody rb { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private float m_minRangeRun = 50;

    State m_state;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isCrounsh = false;
        isGrounded = true;
    }

    void FixedUpdate()
    {
        m_PlayerPosition = m_Player.transform.position;

        Run();
    }

    void Run()
    {
        if (m_PlayerPosition.x - transform.position.x > m_minRangeRun)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    void Walk()
    {
        rb.AddForce(transform.position * speed);
    }
    
}
