using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour {

    public GameObject pooledObject;
    public int startingPooledAmount = 20;
    public bool willGrow = true;

    List<GameObject> pooledObjects;

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < startingPooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public int totalObjects()
    {
        return pooledObjects.Count;
    }

    public int activeObjects()
    {
        int a = 0;
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.activeSelf)
            {
                a++;
            }
        }
        return a;
    }

    public GameObject GetPooledTarget()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }


    void Update()
    {

    }
}
