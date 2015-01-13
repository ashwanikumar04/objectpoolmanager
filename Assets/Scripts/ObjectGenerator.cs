
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Rand = UnityEngine.Random;

public class ObjectGenerator : MonoBehaviour
{

    #region Variables
    float rateOfSpawn = .1f;
    float nextSpawn = .5f;
    #endregion

    #region Methods
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PoolType type = PoolType.Cube;
        string name = string.Empty;
        if (Time.time > nextSpawn)
        {
            switch (Rand.Range(0, 2))
            {
                case 0: name = "Cube";
                    type = PoolType.Cube;
                    break;
                case 1: name = "Cylinder";
                    type = PoolType.Cylinder;
                    break;
                default: break;
            }
            ObjectPoolManager.Instance.Spawn(type, new Vector3(Rand.Range(0, 5), Rand.Range(0, 5), Rand.Range(0, 5)));
            rateOfSpawn = Rand.Range(.01f,.1f);
            nextSpawn = Time.time + rateOfSpawn;
        }
    }

    #endregion
}
