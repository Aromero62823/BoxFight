using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeIncrement : MonoBehaviour {
    private Text displayedTime;
    public int timeLimit;

    void Start() {
        displayedTime = GetComponent<Text>();
        // Nothing below or at 1!
        if(timeLimit <= 1) { timeLimit = 2; }
    }

    // Update is called once per frame
    void Update() {
        int displaySeconds = (int)Mathf.Round(Time.time) % 60;
        int displayMinutes = (int)Mathf.Round(Time.time) / 60;
        incrementTimer(displaySeconds, displayMinutes);
    }

    private void incrementTimer(int seconds, int minutes) {
        // Changes color when in range
        if(minutes >= timeLimit - 1)  displayedTime.color = Color.red;
        // Print the text from vals
        displayedTime.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
