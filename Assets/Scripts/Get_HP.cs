using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_HP : MonoBehaviour
{
    HP player_hp;
    UnityEngine.UI.Text text;

    void Start()
    {
        player_hp = GameObject.Find("Player").GetComponent<HP>();

        text = GetComponent<UnityEngine.UI.Text>();
    }

    void Update() => text.text = player_hp.hp.ToString();
}
