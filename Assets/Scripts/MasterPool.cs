using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPool : MonoBehaviour
{

    static MasterPool _instance;

    public static MasterPool Pool
    {
        get
        {
            return _instance;
        }
    }

    Dictionary<MonoBehaviour, List<MonoBehaviour>> pools = new Dictionary<MonoBehaviour, List<MonoBehaviour>>();

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool AreAnyActive<T>(T mono) where T : MonoBehaviour
    {
        if (!pools.ContainsKey(mono))
        {
            return false;
        }

        foreach (var obj in pools[mono])
        {
            if (obj.gameObject.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    T InstantiateObject<T>(T mono) where T : MonoBehaviour
    {
        var obj = Instantiate(mono, null);
        obj.gameObject.SetActive(false);
        if (!pools.ContainsKey(mono))
        {
            pools.Add(mono, new List<MonoBehaviour>());
        }

        pools[mono].Add(obj);
        return obj;
    }

    public T GetObject<T>(T mono) where T : MonoBehaviour
    {
        if (!pools.ContainsKey(mono))
        {
            return InstantiateObject(mono);
        }

        foreach (var obj in pools[mono])
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return (T)obj;
            }
        }

        return InstantiateObject(mono);
    }
}
