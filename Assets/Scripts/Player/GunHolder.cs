using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    public float throwSpeed;
    public Transform holder;

    Gun gun;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Pick Up")) {
            if (gun == null) {
                RaycastHit hit;
                if (Physics.Raycast (transform.position, transform.forward, out hit)) {
                    Gun g = hit.collider.GetComponent<Gun> ();
                    if (g != null) {
                        rb = g.GetComponent<Rigidbody> ();
                        gun = g;
                    }
                }
            } else {
                gun = null;
                rb.velocity = transform.forward * throwSpeed;
            }
        }
        if(gun != null) {
            rb.MovePosition (holder.position);
            rb.MoveRotation (holder.rotation);
        }
    }
}
