﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform parent;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = parent.rotation;
    }
}
