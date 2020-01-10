using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour
{
    public float speed;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start ()
    {
        characterController = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move *= speed * Time.deltaTime;

        characterController.Move (move);
    }
}
