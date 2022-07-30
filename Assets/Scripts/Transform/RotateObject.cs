/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Rotates an object at the center of the transform.position at x|y|z degrees per second
 */

using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;

    // Update is called once per frame 
    void Update()
    {
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime);
    }
}