using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : Gun
{
    public int damage = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot (Transform head) {
        RaycastHit hit;
        if (Physics.Raycast (head.position, head.forward, out hit)) {
            HP h = hit.collider.GetComponent<HP> ();
            if (h != null) {
                h.hp -= damage;
            }
        }
    }
}
