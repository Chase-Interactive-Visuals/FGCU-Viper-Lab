using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controlls the perspective camera
/// </summary>
public class CameraController : MonoBehaviour
{
    Camera _mainCamera;

    [SerializeField] float translationSensitivity = 2;
    [SerializeField] float zoomSensitivity = 10;
    [SerializeField] float rotationSensitivity = 2;

    string mouseHorizontalAxisName = "Mouse X";
    string mouseVerticalAxisName = "Mouse Y";
    string scrollAxisName = "Mouse ScrollWheel";

    [SerializeField] float xMin = -50;
    [SerializeField] float xMax = 50;
    [SerializeField] float yMin = 0;
    [SerializeField] float yMax = 25;
    [SerializeField] float zMin = -50;
    [SerializeField] float zMax = 50;

    float currentYValue;
    Vector3 _spawnPosition;
    Vector3 _spawnRotation;

    /// <summary>
    /// Saves the starting position for the Perspective Camera
    /// </summary>
    void Start()
    {
        _mainCamera = Camera.main;
        _spawnPosition = transform.position;
        _spawnRotation = transform.eulerAngles;
    }

    /// <summary>
    /// Controls movement of Perspective Camera
    /// </summary>
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            //Keep Camera within the Minimum and Maximum X Y, Z position
            if (transform.position.x < xMin) { transform.position = new Vector3(xMin, transform.position.y, transform.position.z); }
            if (transform.position.x > xMax) { transform.position = new Vector3(xMax, transform.position.y, transform.position.z); }
            if (transform.position.y < yMin) { transform.position = new Vector3(transform.position.x, yMin, transform.position.z); }
            if (transform.position.y > yMax) { transform.position = new Vector3(transform.position.x, yMax, transform.position.z); }
            if (transform.position.z < zMin) { transform.position = new Vector3(transform.position.x, transform.position.y, zMin); }
            if (transform.position.z > zMax) { transform.position = new Vector3(transform.position.x, transform.position.y, zMax); }

            //  translation
            float translateX = 0;
            float translateZ = 0;
            // rotation
            float rotationX = 0;
            float rotationY = 0;

            if (Input.GetMouseButtonDown(1))
            {
                currentYValue = transform.position.y;
            }
            if (Input.GetMouseButton(1))
            {
                translateX = Input.GetAxis(mouseHorizontalAxisName) * translationSensitivity;
                translateZ = Input.GetAxis(mouseVerticalAxisName) * translationSensitivity;


                //Provides scroll-to-zoom functionality with respect to THIS (camera.main)
                transform.Translate(-translateX, 0, -translateZ, Space.Self);
                transform.position = new Vector3(transform.position.x, currentYValue, transform.position.z);
            }
            //If mouse scroll detected
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                transform.Translate(0, 0, .5f, Space.Self);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                transform.Translate(0, 0, -.5f, Space.Self);
            }

            if (Input.GetMouseButton(0))
            {
                rotationX = Input.GetAxis(mouseVerticalAxisName) * rotationSensitivity;
                rotationY = Input.GetAxis(mouseHorizontalAxisName) * rotationSensitivity;
                transform.Rotate(0, -rotationY, 0, Space.World);
                transform.Rotate(rotationX, 0, 0);
            }
            //If arrow key input detected
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(-8f * Time.deltaTime, 0, 0, Space.Self);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(8f * Time.deltaTime, 0, 0, Space.Self);
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, 8f * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -8f * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(0, 8f * Time.deltaTime, 0, Space.Self);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(0, -8f * Time.deltaTime, 0, Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            ResetPositionRotation();
        }
    }
    /// <summary>
    /// Resets PerspectiveCamera to the saved starting spawn position
    /// </summary>
    public void ResetPositionRotation()
    {
        transform.position = _spawnPosition;
        transform.eulerAngles = _spawnRotation;
    }
}
