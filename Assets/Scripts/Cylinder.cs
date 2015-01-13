
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Rand = UnityEngine.Random;

public class Cylinder : MonoBehaviour
{
    #region Variables
    float startTime;
    #endregion

    #region Methods

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        gameObject.transform.renderer.material.color = Rand.Range(1, 10) % 2 == 0 ? Color.red : Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if ((startTime + 4.0f) < Time.time)
        {
            ObjectPoolManager.Instance.Destroy(PoolType.Cylinder, gameObject);
        }
    }
    #endregion
}
