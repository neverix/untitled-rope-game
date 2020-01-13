using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    public GameObject ExplosionParticleSystem;

    public void Detonate()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, 5f);

        foreach (MonoBehaviour component in GetComponents<MonoBehaviour>())
        {
            if (gameObject.ToString() + " \"" + component.ToString() + "\"" != "Detonator")
            {
                Destroy(component);
            }
        }

        detonate_childs(this.gameObject);

        GameObject explosion = Instantiate(ExplosionParticleSystem);

        explosion.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }

    private void detonate_childs(GameObject parent) //Разрушаем связь между родительными и дочерними обьектами, выключяем все скрипты в дочерних обьектах
    {
        Transform[] childrens = parent.GetComponentsInChildren<Transform>();

        foreach (Transform child in childrens)
        {
            child.parent = parent.transform.parent;

            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(300f, parent.transform.position, 5f);

            Destroy(child.gameObject, 5.0f);
        }
    }
}
