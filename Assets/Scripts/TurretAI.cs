﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    private bool is_enabled = false;
    private List<GameObject> targets = new List<GameObject>();
    public GameObject body;
    public GameObject head;
    public GameObject gunbody;
    public float interval = 1;
    private float last_time = 0;

    public GameObject bullet_prefab;

    void Update()
    {
        GameObject target = null; ;
        if (targets.Count == 0) target = null; else target  = targets[0];

        if (target != null && GetComponent<Animation>().isPlaying == false)
        {
            Vector3 pos_for_body = target.transform.position;

            pos_for_body.y = 0;

            body.transform.LookAt(pos_for_body);

            if (Time.time - last_time >= interval)
            {
                gunbody.transform.LookAt(target.transform.position);

                GameObject bullet = Instantiate(bullet_prefab);

                bullet.transform.position = gunbody.transform.position;

                bullet.transform.LookAt(target.transform.position);
                bullet.GetComponent<Rigidbody>().AddForce(gunbody.transform.TransformVector(new Vector3(0, 0, 1000)));

                GetComponent<Animation>().Play("Simple Turret Shot");

                last_time = Time.time;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targets.Remove(other.gameObject);
            if (targets.Count == 0) GetComponent<Animation>().Play("Simple Turret Head Down");
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

                GetComponent<Animation>().Play("Simple Turret Head Up");
            }
        }
    }
}