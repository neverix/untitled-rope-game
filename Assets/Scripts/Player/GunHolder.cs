using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    public float throwSpeed = 10f;
    public float maxDistance = 3f;
    public Transform holder;
    public LayerMask gunMask;

    Gun gun;
    Rigidbody rb;
    Transform prevParent;

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
                if (Physics.Raycast (new Ray(transform.position, transform.forward), out hit, gunMask)) {
                    Gun g = hit.collider.GetComponent<Gun> ();
                    if (g != null) {
                        rb = g.GetComponent<Rigidbody> ();
                        rb.isKinematic = true;
                        gun = g;
                        prevParent = gun.transform.parent;
                        gun.transform.SetParent (holder);
                        gun.transform.localPosition = Vector3.zero;
                        gun.transform.localRotation = Quaternion.identity;
                    }
                }
            } else {
                gun.transform.SetParent (prevParent);
                rb.isKinematic = false;
                rb.velocity = transform.forward * throwSpeed;
                gun = null;
            }
        }
        if(Input.GetButtonDown("Fire1") && gun != null) {
            gun.Shoot (transform);
        }
    }
}
