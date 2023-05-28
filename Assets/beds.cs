using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beds : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 initialBedPosition;
    Vector3 currentBedPosition;
    public GameObject[] BedPrefabs;
    public GameObject[] CreatedBeds;
    private int prefabIndex;
    private int createdBedsIndex;
    float offsetBed;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialBedPosition = new Vector3(initialPosition.x - 3.5f, initialPosition.y - 2.41f, initialPosition.z);
        CreatedBeds = new GameObject[30];
        offsetBed = 0.695f;
        CreateBed();
    }

    
    public void CreateBed()
    {
        currentBedPosition = initialBedPosition;
        int k = 0;
        for (int i = 0; i < 10; i++)
        {
            if (i == 0)
            {
                CreatedBeds[k] = Instantiate(BedPrefabs[0], currentBedPosition, BedPrefabs[0].transform.rotation) as GameObject;
                k++;
                currentBedPosition.x += offsetBed;
                CreatedBeds[k] = Instantiate(BedPrefabs[1], currentBedPosition, BedPrefabs[1].transform.rotation) as GameObject;
                k++;
                currentBedPosition.x += offsetBed;
                CreatedBeds[k] = Instantiate(BedPrefabs[2], currentBedPosition, BedPrefabs[2].transform.rotation) as GameObject;
                k++;
            }
            else if (i == 9)
            {
                CreatedBeds[k] = Instantiate(BedPrefabs[2], currentBedPosition, Quaternion.Euler(BedPrefabs[2].transform.rotation.eulerAngles.x, BedPrefabs[2].transform.rotation.eulerAngles.y + 180, BedPrefabs[2].transform.rotation.eulerAngles.z)) as GameObject;
                k++;
                currentBedPosition.x += offsetBed;
                CreatedBeds[k] = Instantiate(BedPrefabs[1], currentBedPosition, Quaternion.Euler(BedPrefabs[1].transform.rotation.eulerAngles.x, BedPrefabs[1].transform.rotation.eulerAngles.y + 180, BedPrefabs[1].transform.rotation.eulerAngles.z)) as GameObject;
                k++;
                currentBedPosition.x += offsetBed;
                CreatedBeds[k] = Instantiate(BedPrefabs[0], currentBedPosition, Quaternion.Euler(BedPrefabs[0].transform.rotation.eulerAngles.x, BedPrefabs[0].transform.rotation.eulerAngles.y + 180, BedPrefabs[0].transform.rotation.eulerAngles.z)) as GameObject;
                k++;
            }
            else
            {
                CreatedBeds[k] = Instantiate(BedPrefabs[3], currentBedPosition, BedPrefabs[3].transform.rotation) as GameObject;
                k++;
                currentBedPosition.x += offsetBed;
                CreatedBeds[k] = Instantiate(BedPrefabs[4], currentBedPosition, Quaternion.Euler(BedPrefabs[4].transform.rotation.eulerAngles.x, BedPrefabs[4].transform.rotation.eulerAngles.y + 90, BedPrefabs[4].transform.rotation.eulerAngles.z)) as GameObject;
                k++;
                currentBedPosition.x += offsetBed;
                CreatedBeds[k] = Instantiate(BedPrefabs[3], currentBedPosition, Quaternion.Euler(BedPrefabs[3].transform.rotation.eulerAngles.x, BedPrefabs[3].transform.rotation.eulerAngles.y + 180, BedPrefabs[3].transform.rotation.eulerAngles.z)) as GameObject;
                k++;
            }
            currentBedPosition.x = initialBedPosition.x;
            currentBedPosition.z += offsetBed;
        }
    }
    public void TransformBed(int countOfSteps, int countOfStages)
    {
        
        if (countOfSteps == 0)
        {
            prefabIndex = (countOfStages + 1) * 5;
            createdBedsIndex = countOfSteps * 3;
            //Invoke("ReplacementBed", 1.0f);

            ReplacementBed();

            prefabIndex = (countOfStages + 1) * 5 + 1;
            createdBedsIndex = countOfSteps * 3 + 1;
            //Invoke("ReplacementBed", 2.0f);

            ReplacementBed();

            prefabIndex = (countOfStages + 1) * 5 + 2;
            createdBedsIndex = countOfSteps * 3 + 2;
            //Invoke("ReplacementBed", 3.0f);

            ReplacementBed();
        }
        else if (countOfSteps == 9)
        {
            prefabIndex = (countOfStages + 1) * 5 + 2;
            createdBedsIndex = countOfSteps * 3;
            //Invoke("ReplacementBed", 1.0f);
            ReplacementBed();
            prefabIndex = (countOfStages + 1) * 5 + 1;
            createdBedsIndex = countOfSteps * 3 + 1;
            //Invoke("ReplacementBed", 2.0f);
            ReplacementBed();
            prefabIndex = (countOfStages + 1) * 5;
            createdBedsIndex = countOfSteps * 3 + 2;
            //Invoke("ReplacementBed", 3.0f);
            ReplacementBed();
        }
        else
        {
            prefabIndex = (countOfStages + 1) * 5 + 3;
            createdBedsIndex = countOfSteps * 3;
            //Invoke("ReplacementBed", 1.0f);
            ReplacementBed();
            prefabIndex = (countOfStages + 1) * 5 + 4;
            createdBedsIndex = countOfSteps * 3 + 1;
            //Invoke("ReplacementBed", 2.0f);
            ReplacementBed();
            prefabIndex = (countOfStages + 1) * 5 + 3;
            createdBedsIndex = countOfSteps * 3 + 2;
            //Invoke("ReplacementBed", 3.0f);
            ReplacementBed();
        }
    }

    public void ReplacementBed()
    {
        Vector3 pos;
        Quaternion rot;
        pos = CreatedBeds[createdBedsIndex].transform.position;
        rot = CreatedBeds[createdBedsIndex].transform.rotation;
        Destroy(CreatedBeds[createdBedsIndex]);
        CreatedBeds[createdBedsIndex] = Instantiate(BedPrefabs[prefabIndex], pos, rot) as GameObject;
    }
}
