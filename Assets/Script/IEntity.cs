
using UnityEngine;

public interface IEntityMouvement
{
    float walkSpeed {  get; set; }
    float runSpeed { get; set; }
    float crounshSpeed { get; set; }
    float speed { get; set; }

    float jumpForce { get; set; }

    bool isCrounsh { get; set; }
    bool isGrounded { get; set; }
    Rigidbody rb { get; set; }
}

