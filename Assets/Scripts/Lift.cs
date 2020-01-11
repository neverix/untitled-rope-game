using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : Interactable
{
    public GameObject EndPos;
    public override void Interact()
    {
        FixedUpdate();
        throw new System.NotImplementedException();
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp((this.transform.position), (EndPos.transform.position), 0.005f);
    }
}
