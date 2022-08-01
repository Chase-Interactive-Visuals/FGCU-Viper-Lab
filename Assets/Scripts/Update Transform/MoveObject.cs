/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Move Object in specified direction
 */

using UnityEngine;

public class MoveObject : MonoBehaviour
{
    //The translation vectorre for this object
    [SerializeField] Vector3 vectorDirection;

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(vectorDirection * Time.deltaTime);

        //Display Offset to console to see what value is being calculated
        if (debuggingIsActive)
        {
            Debug.Log("\nObject Position: \n" + "X Axis: " + transform.position.x + "\nY Axis: " + transform.position.y + "\nZ Axis: " + transform.position.z);
        }
    }
}
