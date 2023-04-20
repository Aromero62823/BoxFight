using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    void Start() {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => pressStart());
    }

    private void pressStart() {
        Debug.Log("Pressed");
        SceneManager.LoadScene(0);
    }
}