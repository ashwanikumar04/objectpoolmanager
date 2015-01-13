
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Rand = UnityEngine.Random;

public class Cube : MonoBehaviour
{

    #region Variables
    float startTime;
    #endregion

    #region Methods
    void Start()
    {
        startTime = Time.time;
        gameObject.transform.renderer.material.color = Rand.Range(1, 10) % 2 == 0 ? Color.red : Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if ((startTime + 3.0f) <Time.time)
        {
            ObjectPoolManager.Instance.Destroy(PoolType.Cube, gameObject);
        }
    }

    #endregion
}
