using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class moveController : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 currentPosition;

    public GameObject[] ToolPrefabs;
    private GameObject UsedItem;
    public Canvas advices;


    public float shift;
    int countOfSteps;
    public int numberOfActions;
    static int numberOfStages;
    static int countOfStages;
    bool timerOn;
    float timeLeft;
    float prevTimeLeft;
    float actionTime;
    bool flagOfStep;
    float offsetBed;
    private int prefabIndex;
    bool cropsIsPlanted;

    float score;
    string[] fingers = { "большой палец", "указательный палец", "средний палец", "безымянный палец", "мизинец", "все пальцы" };

    private void Start()
    {
        timerOn = false;
        flagOfStep = false;
        cropsIsPlanted = true;
        actionTime = 3.5f;
        timeLeft = actionTime;
        prevTimeLeft = actionTime;
        initialPosition = transform.position;
        currentPosition = initialPosition;

        countOfSteps = 0;
        countOfStages = 1;
        numberOfStages = 6;

        offsetBed = 0.695f;
        score = 0.0f;
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
                prevTimeLeft = timeLeft;
                timeLeft = actionTime;
                timerOn = false;
                flagOfStep = true;
            }
        }
        if (countOfStages == 5 && cropsIsPlanted)
        {
            GetComponent<Crops>().CreateCrops(offsetBed);
            cropsIsPlanted = false;
        }
        if (countOfStages < numberOfStages)
        {
            advices.GetComponent<adviceText>().SetFinger(fingers[countOfStages]);
            if (Input.GetKey(KeyCode.Q) && countOfStages == 0)
            {
                score += (actionTime - timeLeft) / 250;
                advices.GetComponent<Score>().SetScore(score);
                if (Input.GetKeyDown(KeyCode.Q) && !timerOn)
                {
                    timerOn = true;
                    UsedItem.GetComponentInChildren<Item>().Interaction();
                }
            }
            if (Input.GetKey(KeyCode.W) && countOfStages == 1)
            {
                score += (actionTime - timeLeft) / 250;
                advices.GetComponent<Score>().SetScore(score);
                if (Input.GetKeyDown(KeyCode.W) && !timerOn)
                {
                    timerOn = true;
                    UsedItem.GetComponentInChildren<Item>().Interaction();
                }
            }
            if (Input.GetKey(KeyCode.E) && countOfStages == 2)
            {
                score += (actionTime - timeLeft) / 250;
                advices.GetComponent<Score>().SetScore(score);
                if (Input.GetKeyDown(KeyCode.E) && !timerOn)
                {
                    timerOn = true;
                    UsedItem.GetComponentInChildren<Item>().Interaction();
                }
            }
            if (Input.GetKey(KeyCode.R) && countOfStages == 3)
            {
                score += (actionTime - timeLeft) / 250;
                advices.GetComponent<Score>().SetScore(score);
                if (Input.GetKeyDown(KeyCode.R) && !timerOn)
                {
                    timerOn = true;
                    UsedItem.GetComponentInChildren<Item>().Interaction();
                }
            }
            if (Input.GetKey(KeyCode.T) && countOfStages == 4)
            {
                score += (actionTime - timeLeft) / 250;
                advices.GetComponent<Score>().SetScore(score);
                if (Input.GetKeyDown(KeyCode.T) && !timerOn)
                {
                    timerOn = true;
                    UsedItem.GetComponentInChildren<Item>().Interaction();
                }
            }
            if (Input.GetKey(KeyCode.Y) && countOfStages == 5)
            {
                score += (actionTime - timeLeft) / 250;
                advices.GetComponent<Score>().SetScore(score);
                if (Input.GetKeyDown(KeyCode.Y) && !timerOn)
                {
                    timerOn = true;
                    UsedItem.GetComponentInChildren<Item>().Interaction();
                    GetComponent<Crops>().HarvestCrop(countOfSteps);
                }
            }
        }



        if (!timerOn && flagOfStep)
        {
            UsedItem.GetComponent<moveItem>().MoveItem();
            GetComponent<beds>().TransformBed(countOfSteps, countOfStages);
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

}
