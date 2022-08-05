/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Moves an object on specified axis (axes) using mouse input (with optional grid snapping)
 */

using UnityEngine;

public class DragObject : MonoBehaviour
{
    //The grid position size that draggable objects will 'Snap' to (Unity Unit of measurement ? 1 meter)
    [SerializeField] float gridSize = .5f;

    private float mZCoord;
    Vector3 offset = Vector3.zero;

    [SerializeField] bool snapToGrid;

    [SerializeField] bool activateXAxis;
    [SerializeField] bool activateYAxis;
    [SerializeField] bool activateZAxis;

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;
    
    public void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = worldPos - transform.position;
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y) in relation to active Camera
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
    /// <summary>
    /// Controls the transform Vector3 of this compoent
    /// </summary>
    public void OnMouseDrag()
    {
        //If grid snapping is enabled, constrain object movement to specified grid positions
        if (snapToGrid)
        {
            if (activateXAxis && activateYAxis && activateZAxis)
                transform.position = new Vector3(RoundToNearestGrid(GetMouseAsWorldPoint().x), RoundToNearestGrid(GetMouseAsWorldPoint().y), RoundToNearestGrid(GetMouseAsWorldPoint().z));

            else if (!activateXAxis && activateYAxis && activateZAxis)
                transform.position = new Vector3(transform.position.x, RoundToNearestGrid(GetMouseAsWorldPoint().y), RoundToNearestGrid(GetMouseAsWorldPoint().z));

            else if (activateXAxis && !activateYAxis && activateZAxis)
                transform.position = new Vector3(RoundToNearestGrid(GetMouseAsWorldPoint().x), transform.position.y, RoundToNearestGrid(GetMouseAsWorldPoint().z));

            else if (activateXAxis && activateYAxis && !activateZAxis)
                transform.position = new Vector3(RoundToNearestGrid(GetMouseAsWorldPoint().x), RoundToNearestGrid(GetMouseAsWorldPoint().y), transform.position.z);

            else if (!activateXAxis && !activateYAxis && activateZAxis)
                transform.position = new Vector3(transform.position.x, transform.position.y, RoundToNearestGrid(GetMouseAsWorldPoint().z));

            else if (!activateXAxis && activateYAxis && !activateZAxis)
                transform.position = new Vector3(transform.position.x, RoundToNearestGrid(GetMouseAsWorldPoint().y), transform.position.z);

            else if (activateXAxis && !activateYAxis && !activateZAxis)
                transform.position = new Vector3(RoundToNearestGrid(GetMouseAsWorldPoint().x), transform.position.y, transform.position.z);

            else if (!activateXAxis && !activateYAxis && !activateZAxis)
                Debug.Log("No Movement Vector Selected!");
        }
        //If grid snapping is disabled, move object freely
        else
        {
            if (activateXAxis && activateYAxis && activateZAxis)
                transform.position = new Vector3(GetMouseAsWorldPoint().x, GetMouseAsWorldPoint().y, GetMouseAsWorldPoint().z);

            else if (!activateXAxis && activateYAxis && activateZAxis)
                transform.position = new Vector3(transform.position.x, GetMouseAsWorldPoint().y, GetMouseAsWorldPoint().z);

            else if (activateXAxis && !activateYAxis && activateZAxis)
                transform.position = new Vector3(GetMouseAsWorldPoint().x, transform.position.y, GetMouseAsWorldPoint().z);

            else if (activateXAxis && activateYAxis && !activateZAxis)
                transform.position = new Vector3(GetMouseAsWorldPoint().x, GetMouseAsWorldPoint().y, transform.position.z);

            else if (!activateXAxis && !activateYAxis && activateZAxis)
                transform.position = new Vector3(transform.position.x, transform.position.y, GetMouseAsWorldPoint().z);

            else if (!activateXAxis && activateYAxis && !activateZAxis)
                transform.position = new Vector3(transform.position.x, GetMouseAsWorldPoint().y, transform.position.z);

            else if (activateXAxis && !activateYAxis && !activateZAxis)
                transform.position = new Vector3(GetMouseAsWorldPoint().x, transform.position.y, transform.position.z);

            else if (!activateXAxis && !activateYAxis && !activateZAxis)
                Debug.Log("No Movement Vector Selected!");
        }
        //Display Position to console to see what value is being calculated
        if (debuggingIsActive)
        {
            Debug.Log("\nObject Position: \n" + "X Axis: " + transform.position.x + "\nY Axis: " + transform.position.y + "\nZ Axis: " + transform.position.z);
        }
    }
}
