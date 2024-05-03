using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPView : MonoBehaviour
{

    [SerializeField] Transform firstPersonCam;
    [SerializeField] private float sensitivity;
    [SerializeField] private float smoothLook = 2f;

    Vector2 velocity;
    Vector2 frameVelocity;

    private void Reset()
    {
        firstPersonCam = GetComponentInParent<FPMove>().transform;
    }




    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);

        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothLook);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        firstPersonCam.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

    }
}
