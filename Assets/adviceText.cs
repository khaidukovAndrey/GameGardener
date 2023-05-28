using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adviceText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    private string finger;
    private void Start() {
        finger="большой палец";
    }

    private void Update() {
        text.text = "Сгибайте "+ finger;
    }

    public void SetFinger(string fingName)
    {
        finger = fingName;
    }
}
