using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 50f;

    public float clampBuffer = 5f; // Looser clamp, adds extra wiggle room

    private bool doMovement = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
            return;

        Vector3 move = Vector3.zero;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            move += Vector3.back;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            move += Vector3.forward;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            move += Vector3.left;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            move += Vector3.right;
        }

        transform.Translate(move * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        // Apply looser clamping
        pos.x = Mathf.Clamp(pos.x, minX - clampBuffer, maxX + clampBuffer);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ - clampBuffer, maxZ + clampBuffer);

        transform.position = pos;
    }
}
