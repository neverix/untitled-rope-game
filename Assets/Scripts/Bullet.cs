using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        HP object_health = collision.gameObject.GetComponent<HP>();
        if (object_health) object_health.hp -= 10;
        Destroy(gameObject);
    }
}
