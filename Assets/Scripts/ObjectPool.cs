﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    bool shouldParentToThisObject = false;

    [SerializeField]
    int initialSize = 0;

    [SerializeField]
    T objectPrefab = null;

    List<T> objects = new List<T>();

    protected virtual void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            var temp = InstantiateObject();
            temp.gameObject.SetActive(false);
        }
    }

    T InstantiateObject()
    {
        T instantiatedObject;
        if (shouldParentToThisObject)
        {
            instantiatedObject = Instantiate(objectPrefab, transform);
        }
        else
        {
            instantiatedObject = Instantiate(objectPrefab);
        }

        objects.Add(instantiatedObject);

        return instantiatedObject;
    }

    public bool AreAnyObjectsActive()
    {
        foreach (var obj in objects)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    public void DisableAllObjects()
    {
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public T GetObject()
    {
        foreach (var obj in objects)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        var newObj = InstantiateObject();
        newObj.gameObject.SetActive(false);
        return newObj;
    }
}
