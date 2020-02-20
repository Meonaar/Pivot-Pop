using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float angle;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, angle * Time.deltaTime);
    }
}
