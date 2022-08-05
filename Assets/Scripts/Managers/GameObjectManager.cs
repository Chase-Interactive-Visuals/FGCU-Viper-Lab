using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    List<GameObject> _instantiatedGOList = new List<GameObject>();
    List<InstantiatedGameObjectWorker> _instantiatedGameObjectWorkerList = new List<InstantiatedGameObjectWorker>();

    private GameObject currentGameObject;
    
    public void SetCurrentGameObject(GameObject currentGO)
    {
        currentGameObject = currentGO;
    }

    public void AddGOToInstantiatedGOList(GameObject newGo)
    {
        _instantiatedGOList.Add(newGo);
        SetCurrentGameObject(newGo);
    }

    
    
}
