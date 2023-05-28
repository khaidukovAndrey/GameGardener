using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    public GameObject[] CreatedCrops;
    Vector3 initialCropPosition;
    Vector3 currentCropPosition;
    public GameObject Crop;
    Vector3 initialPosition;
    int numOfDestroyedObj;
    void Start()
    {
        initialPosition = transform.position;
        initialCropPosition = new Vector3(initialPosition.x - 2.05f, initialPosition.y - 2.23f, initialPosition.z);
        CreatedCrops = new GameObject[10];
        numOfDestroyedObj=0;
    }

    
    public void CreateCrops(float offsetBed)
    {
        currentCropPosition = initialCropPosition;
        for (int i = 0; i < 10; i++)
        {
            CreatedCrops[i] = Instantiate(Crop, currentCropPosition, Crop.transform.rotation) as GameObject;
            currentCropPosition.z += offsetBed;
        }
    }
    public void HarvestCrop(int countOfSteps)
    {
        numOfDestroyedObj = countOfSteps;
        Invoke("DestroyCrop", 3.0f);
    }

    public void DestroyCrop()
    {
        Destroy(CreatedCrops[numOfDestroyedObj]);
    }
}
