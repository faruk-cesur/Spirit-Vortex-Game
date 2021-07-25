using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatControl : MonoBehaviour
{

    public Transform modelRoots;

    void Update()
    {
        modelRoots.Rotate(0, 0, 360 * Time.deltaTime * 3);
    }
}
