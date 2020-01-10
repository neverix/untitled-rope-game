using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {
    public float gravity = 9.81f;
    public float jumpVelocity = 9f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    float velocityY;
    CharacterController characterController;

    // Use this for initialization
    void Start ()
    {
        characterController = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update ()
    {
        bool isGrounded = Physics.CheckSphere (groundCheck.position, groundDistance, groundMask);
        if(isGrounded) {
            velocityY = 0f;
            if(Input.GetButtonDown("Jump")) {
                velocityY = jumpVelocity;
            }
        }

        velocityY -= gravity * Time.deltaTime;
        characterController.Move (Vector3.up * velocityY * Time.deltaTime);
    }
}
