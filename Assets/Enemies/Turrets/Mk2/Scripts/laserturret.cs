using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserturret : MonoBehaviour
{
    private bool is_enabled = false;
    private List<GameObject> targets = new List<GameObject>();
    private Animation anim;

    public GameObject head;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (is_enabled)
        {
            Vector3 pos = targets[0].transform.position;
            pos.y = head.transform.position.y;
            head.transform.LookAt(pos);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targets.Remove(other.gameObject);
            if (targets.Count == 0) anim.Play("MK2aftershot");
            is_enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (is_enabled)
            {
                targets.Add(other.gameObject);
            }
            else
            {
                targets.Add(other.gameObject);
                is_enabled = true;

                anim.Play("MK2prepare");
            }
        }
    }
}
