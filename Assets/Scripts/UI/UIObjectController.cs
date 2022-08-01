/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Control GameObjects with UI Events 
 */

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIObjectController : MonoBehaviour
{
    [SerializeField] GameObject buttonGameObjectController;
    bool buttonGameObjectControllerActive = true;

    [SerializeField] GameObject cubePrefab;

    List<GameObject> listOfInstantiatedGameObjects = new List<GameObject>();

    GameObject currentInstantiatedPrefab;

    public void DisplayButtonGameObjectControllerExamples()
    {
        buttonGameObjectController.SetActive(buttonGameObjectControllerActive);
        buttonGameObjectControllerActive = !buttonGameObjectControllerActive;
    }
    public void InstantiatePrefabWithoutReference()
    {
        Instantiate(cubePrefab);
    }
    public void InstantiatePrefabWithReference()
    {
        GameObject myInstantiatedObject = Instantiate(cubePrefab);

        currentInstantiatedPrefab = myInstantiatedObject;

        //Get the MeshRenderer component of the the newly instantiated GameObject
        //and change the material.color property to blue
        myInstantiatedObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void InstantiatePrefabAndAddToList()
    {
        GameObject myInstantiatedObject = Instantiate(cubePrefab);

        currentInstantiatedPrefab = myInstantiatedObject;

        //Add the newly instantiated GameObject reference to a list to access later
        listOfInstantiatedGameObjects.Add(myInstantiatedObject);

        //Get the MeshRenderer component of the the newly instantiated GameObject
        //and change the material.color property to blue
        myInstantiatedObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void ChangeColorOfGameObjectsInList()
    {
        foreach (GameObject myGameobject in listOfInstantiatedGameObjects)
        {
            //Get the MeshRenderer component of the the  GameObject in the list
            //and change the material.color property to red

            //NOTE: It is better practice to store a reference of the MeshRenderer components
            //of each gameobject within another list because calling GetComponent<>() is performant heavy
            myGameobject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void InstantiatePrefabAndSetPositionRotation()
    {
        GameObject myInstantiatedObject = Instantiate(cubePrefab, new Vector3(0, 10, 0), new Quaternion(0, 90, 0, 0));

        currentInstantiatedPrefab = myInstantiatedObject;
    }

    public void RotateCurrentInstantiatedPrefab(float sliderValue)
    {
        if (currentInstantiatedPrefab != null)
            currentInstantiatedPrefab.transform.eulerAngles = new Vector3(0, sliderValue, 0);
    }

    public void MoveCurrentInstantiatedPrefabLeft()
    {
        if (currentInstantiatedPrefab != null)
            currentInstantiatedPrefab.transform.Translate(Vector3.left * Time.deltaTime);
    }
    public void MoveCurrentInstantiatedPrefabRight()
    {
        if (currentInstantiatedPrefab != null)
            currentInstantiatedPrefab.transform.Translate(Vector3.right * Time.deltaTime);
    }
    public void MoveCurrentInstantiatedPrefabUp()
    {
        if (currentInstantiatedPrefab != null)
            currentInstantiatedPrefab.transform.Translate(Vector3.up * Time.deltaTime);
    }
    public void MoveCurrentInstantiatedPrefabDown()
    {
        if (currentInstantiatedPrefab != null)
            currentInstantiatedPrefab.transform.Translate(Vector3.down * Time.deltaTime);
    }
    public void DestroyAllInstantiatedObjects()
    {
        if (GameObject.FindGameObjectWithTag("CubePrefab") != null)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("CubePrefab"))
            {
                Destroy(go);
            }
        }
        listOfInstantiatedGameObjects.Clear();
    }
}
