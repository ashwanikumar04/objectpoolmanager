using UnityEngine;
using System.Collections;

public class ObjectPoolsInitializers : MonoBehaviour
{
    public GameObject cube;
    public GameObject cylinder;

    public int cubePoolSize = 1;
    public int cylinderPoolSize = 1;

    public static ObjectPoolsInitializers Instance;

    void Awake()
    {
        //InitializeObjectPools();
        Instance = this;
        InitializeObjectPools();
    }

    private void InitializeObjectPools()
    {
        ObjectPoolManager.Instance.CreatePool(PoolType.Cube, GetPool(cube, cubePoolSize));
        ObjectPoolManager.Instance.CreatePool(PoolType.Cylinder, GetPool(cylinder, cylinderPoolSize));
    }

    public ObjectPool GetPool(GameObject poolGameObject, int poolSize)
    {
        ObjectPool pool = new ObjectPool(poolGameObject, poolSize, (go) =>
        {
        });

        return pool;
    }
}

public enum PoolType
{
    Cube,
    Cylinder
}