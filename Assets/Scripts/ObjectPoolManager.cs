using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ObjectPoolManager
{
    public Dictionary<PoolType, ObjectPool> objectsPool;

    static ObjectPoolManager instance = null;

    public static ObjectPoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectPoolManager();
                instance.objectsPool = new Dictionary<PoolType, ObjectPool>();
            }

            return instance;
        }
    }

    public void CreatePool(PoolType type, ObjectPool pool)
    {
        if (!objectsPool.ContainsKey(type))
        {
            objectsPool.Add(type, pool);
        }
        else
        {
            objectsPool[type].Clear();
        }
    }

    public void Reset()
    {
        foreach (var item in objectsPool)
        {
            item.Value.Reset();
        }
    }

    public ObjectPool GetPool(PoolType type)
    {
        try
        {
            return objectsPool[type];
        }
        catch
        {
            Debug.Log(type);
        }
        return null;
    }

    public void Spawn(PoolType type, Vector3 instantiateVector)
    {
        if (Instance.objectsPool.Any())
        {
            ObjectPoolManager.Instance.GetPool(type).Spawn(instantiateVector, Quaternion.identity);
        }
    }

    public void Destroy(PoolType type, GameObject target)
    {
        if (ObjectPoolManager.Instance.objectsPool.Any())
        {
            ObjectPoolManager.Instance.GetPool(type).Destroy(target);
        }
    }

}
