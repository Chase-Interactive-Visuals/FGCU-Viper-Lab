using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedGameObjectWorker : MonoBehaviour
{
    GameObjectManager _gameObjectManager;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<GameObjectManager>() != null)
        {
            //Find the instance of the GameObjectManager in the scene and set it to the reference variable _gameObjectManager
            _gameObjectManager = FindObjectOfType<GameObjectManager>();
            //Provide the GameObjectManager manager class with a reference to this.gameObject gameobject 
            _gameObjectManager.AddGOToInstantiatedGOList(this.gameObject);
        }
    }
}
