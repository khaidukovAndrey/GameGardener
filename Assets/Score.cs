using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private float score;
    private void Start() {
        score=0.0f;
    }

    private void Update() {
        text.text = "Score: "+ Mathf.Round(score);
    }

    public void SetScore(float s)
    {
        score = s;
    }
}
