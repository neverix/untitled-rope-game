using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : Interactable
{
    public GameObject EndPos;
    public bool is_enabled = false;

    public override void Interact() => is_enabled = !is_enabled;
    private void FixedUpdate()
    {
        if (is_enabled) transform.position = Vector3.Lerp((this.transform.position), (EndPos.transform.position), 0.01f);
    }
}
