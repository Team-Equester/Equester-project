using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModels : MonoBehaviour
{
    public Transform Models;
    public float xAngle, yAngle, zAngle;

    
    private void Update()
    {
        Models.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }

}
