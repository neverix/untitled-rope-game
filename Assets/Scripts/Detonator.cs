using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [Header("Система частиц для взрыва:")]
    [Header("Для взрыва вызовите Detonator.Detonate()")]
    public GameObject ExplosionParticleSystem;
    [Header("Количество взрывчатки C4 (в граммах):")]
    public float C4_count = 300f;
    [Header("Мощность взрывчатки (в метрах):")]
    public float explosion_radius = 5f;
    [Header("Текстура для уничтоженных обьектов:")]
    public Texture tex;
    
    public void Detonate()
    {
        MeshRenderer r = gameObject.GetComponent<MeshRenderer>();
        if (r) r.material.mainTexture = tex;

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

        Destroy(this.gameObject, 5f);
    }

    private void detonate_childs(GameObject parent) //Разрушаем связь между родительными и дочерними обьектами, выключяем все скрипты в дочерних обьектах
    {
        Transform[] childrens = parent.GetComponentsInChildren<Transform>();

        foreach (Transform child in childrens)
        {
            child.parent = parent.transform.parent;

            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(C4_count, transform.position, explosion_radius);

            MeshRenderer r = child.GetComponent<MeshRenderer>();
            if (r) r.material.mainTexture = tex;

            Destroy(child.gameObject, 5.0f);
        }
    }
}
