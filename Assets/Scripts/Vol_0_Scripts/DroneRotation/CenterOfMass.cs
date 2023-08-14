using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Vector3 centerOfMassPosition;

    void Start()
    {
        // Ana nesnenin center of mass pozisyonunu güncelle
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.centerOfMass = centerOfMassPosition;
        }
    }
}

