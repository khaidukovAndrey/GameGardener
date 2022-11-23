using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveItem : MonoBehaviour
{
    Vector3 positionOfItem;
    float shiftOfItem;

    private void Start() 
    {
        shiftOfItem = 0.7f;
    }
    public void MoveItem()
    {
        positionOfItem = transform.position;
        positionOfItem.z += shiftOfItem;
        transform.position = positionOfItem;
    }
}
