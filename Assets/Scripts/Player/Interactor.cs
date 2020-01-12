using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact")) {
            RaycastHit hit;
            if(Physics.Raycast (transform.position, transform.forward, out hit)) {
                Interactable i = hit.collider.GetComponent<Interactable> ();
                if(i != null) i.Interact ();
            }
        }
    }
}
