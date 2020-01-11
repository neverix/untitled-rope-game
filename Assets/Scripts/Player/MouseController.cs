using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sensitivity;
    public Transform cam;
    float yRot;
    bool firstFrame = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;

        yRot -= mouseY;
        yRot = Mathf.Clamp (yRot, -90f, 90f);
        if(firstFrame) {
            yRot = 0f;
        }

        cam.localRotation = Quaternion.Euler (yRot, 0f, 0f);
        transform.Rotate (Vector3.up * mouseX);

        firstFrame = false;
    }
}
