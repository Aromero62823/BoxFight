using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    public int sceneIndex;
    void Start() {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => pressStart());
    }

    private void pressStart() {
        SceneManager.LoadScene(sceneIndex);
    }
}
