using UnityEngine;

public class Porton : MonoBehaviour
{

    [SerializeField] bool opening = false;

    void Update()
    {
        if (opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z), Time.deltaTime * 2f);

            if (transform.position.x <= 120f)
            {
                opening = false;
            }
            Debug.Log("transform.position.x: " + transform.position.x);
        }
    }

    public void Open()
    {
        opening = true;
    }
}
