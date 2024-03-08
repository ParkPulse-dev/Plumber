using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset, vect;
    public GameObject tool1;
    public GameObject problem;
    float dist;
    int isMouseButton;
    void Start()
    {
        vect = new Vector3(5, 0, 0);
        tool1 = GameObject.Find("tool1");
        problem = GameObject.Find("Problem");
        dist = 3f;
        isMouseButton = 0;
    }

    void Update()
    {
        if (isDragging)
        {
            // Update the position of the object to follow the mouse cursor
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);

            if (Input.GetMouseButtonUp(isMouseButton))
            {
                // Stop dragging when mouse button is released
                isDragging = false;
            }
        }
        if (Vector3.Distance(tool1.transform.position, vect) < dist)
        {
            Destroy(problem);
        }
    }

    void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
}
