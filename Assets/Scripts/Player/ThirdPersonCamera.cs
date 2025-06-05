using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El target es el jugador
    public float distance = 4f;
    public float height = 2f;
    public float sensitivity = 5f;

    public float minVerticalAngle = -45f; // Limite inferior (mirar abajo)
    public float maxVerticalAngle = 45f;  // Limite superior (mirar arriba)

    private float mouseX;
    private float mouseY;

    public void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        mouseY += Input.GetAxis("Mouse X") * sensitivity;    // Rotaci�n horizontal
        mouseX -= Input.GetAxis("Mouse Y") * sensitivity;    // Rotaci�n vertical (invertida como es usual)
        mouseX = Mathf.Clamp(mouseX, minVerticalAngle, maxVerticalAngle); // Limita la rotaci�n vertical

        Quaternion rotation = Quaternion.Euler(mouseX, mouseY, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
