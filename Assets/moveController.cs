using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class moveController : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 initialBedPosition;
    Vector3 currentPosition;
    Vector3 currentBedPosition;
    Vector3 initialCropPosition;
    Vector3 currentCropPosition;
    public GameObject[] ToolPrefabs;
    public GameObject[] BedPrefabs;
    public GameObject[] CreatedBeds;
    public GameObject UsedItem;
    public GameObject Bed;
    public GameObject Crop;
    public GameObject[] CreatedCrops;
    public float shift;
    int countOfSteps;
    public int numberOfActions;
    int numberOfStages;
    int countOfStages;
    bool timerOn;
    float timeLeft;
    float actionTime;
    bool flagOfStep;
    float offsetBed;
    private int prefabIndex;
    private int createdBedsIndex;
    bool cropsIsPlanted;
    private void Start()
    {
        timerOn = false;
        flagOfStep = false;
        cropsIsPlanted = true;
        actionTime = 3.5f;
        timeLeft = actionTime;
        initialPosition = transform.position;
        currentPosition = initialPosition;
        initialBedPosition = new Vector3(initialPosition.x - 3.5f, initialPosition.y - 2.41f, initialPosition.z);
        initialCropPosition = new Vector3(initialPosition.x - 2.05f, initialPosition.y - 2.23f, initialPosition.z);
        countOfSteps = 0;
        countOfStages = 0;
        numberOfStages = 6;
        CreatedBeds = new GameObject[30];
        CreatedCrops = new GameObject[10];
        offsetBed = 0.695f;
        CreateBed();
        UsedItem = Instantiate(ToolPrefabs[countOfStages], new Vector3(initialPosition.x - 2.9f, initialPosition.y - 1.38f, initialPosition.z), Quaternion.identity) as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
                timeLeft -= Time.deltaTime;
            else
            {
                timeLeft = actionTime;
                timerOn = false;
                flagOfStep = true;
            }
        }
        if (countOfStages == 5 && cropsIsPlanted)
        {
            CreateCrops();
            cropsIsPlanted=false;
        }
        if (countOfStages < numberOfStages)
        {
            if (Input.GetKeyDown(KeyCode.Q) && countOfStages==0)
            {
                timerOn = true;
                UsedItem.GetComponentInChildren<Item>().Interaction();
            }
            if (Input.GetKeyDown(KeyCode.W) && countOfStages==1)
            {
                timerOn = true;
                UsedItem.GetComponentInChildren<Item>().Interaction();
            }
            if (Input.GetKeyDown(KeyCode.E) && countOfStages==2)
            {
                timerOn = true;
                UsedItem.GetComponentInChildren<Item>().Interaction();
            }
            if (Input.GetKeyDown(KeyCode.R) && countOfStages==3)
            {
                timerOn = true;
                UsedItem.GetComponentInChildren<Item>().Interaction();
            }
            if (Input.GetKeyDown(KeyCode.T) && countOfStages==4)
            {
                timerOn = true;
                UsedItem.GetComponentInChildren<Item>().Interaction();
            }
            if (Input.GetKeyDown(KeyCode.Y) && countOfStages==5)
            {
                timerOn = true;
                UsedItem.GetComponent<Item>().Interaction();
                Invoke("HarvestCrop", 3.0f);
            }
        }



        if (!timerOn && flagOfStep)
        {
            UsedItem.GetComponent<moveItem>().MoveItem();
            TransformBed();
            currentPosition.z += shift;
            transform.position = currentPosition;
            countOfSteps += 1;
            if (countOfSteps == numberOfActions)
            {
                currentPosition = initialPosition;
                transform.position = currentPosition;
                countOfSteps = 0;
                Destroy(UsedItem);
                countOfStages++;
                UsedItem = Instantiate(ToolPrefabs[countOfStages], new Vector3(initialPosition.x - 2.9f, initialPosition.y - 1.38f, initialPosition.z), Quaternion.identity) as GameObject;
            }
            flagOfStep = false;
        }
    }

    public void TransformBed()
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
    public void CreateCrops()
    {
        currentCropPosition=initialCropPosition;
        for(int i =0;i<10;i++)
        {
            CreatedCrops[i]= Instantiate(Crop, currentCropPosition, Crop.transform.rotation) as GameObject;
            currentCropPosition.z+=offsetBed;
        }
    }
    public void HarvestCrop()
    {
        Destroy(CreatedCrops[countOfSteps]);
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
}
