using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class moveController : MonoBehaviour
{
    Vector3 pos;
    Vector3 posOfItem;
    public GameObject UsedItem;
    public float shift;
    public int countOfSteps;
    public int numberOfActions;
    private void Start() {
        pos = transform.position;
        countOfSteps = 0;
        numberOfActions=10;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && countOfSteps < numberOfActions)
        {
            print ("sdfsdfsdf2");
            posOfItem = UsedItem.GetComponentInParent<Transform>().transform.position;
            UsedItem.GetComponent<Item>().Interaction();
            posOfItem.z+=1;
            UsedItem.GetComponentInParent<Transform>().transform.position = posOfItem;
            //UsedItem.GetComponent<Item>().Interaction();
            pos.z += shift;
            transform.position = pos;
            countOfSteps += 1;
            
        }
    }
}
