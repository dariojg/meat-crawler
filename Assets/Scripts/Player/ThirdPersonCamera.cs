using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; //El target es el jugador
    public float distance = 4f;
    public float height = 2f;
    public float sensitivity = 5f;
    public float maxRotation = 10f;

    public float mouseX;
    public float mouseY;

    public void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        mouseY += Input.GetAxis("Mouse X") * sensitivity;
        mouseX -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -800f, 8000f);

        Quaternion rotation = Quaternion.Euler(mouseX, mouseY, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
