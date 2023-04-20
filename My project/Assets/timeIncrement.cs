using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeIncrement : MonoBehaviour
{
    private Text displayedTime;
    private int r60Minutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        displayedTime = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int displayTime =  (int)Mathf.Round(Time.time) % 61;
        displayedTime.text = r60Minutes.ToString() + ":" + displayTime.ToString();
        if(displayTime == 60) {
            r60Minutes++;
        }
    }
}
