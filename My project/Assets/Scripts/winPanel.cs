using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winPanel : MonoBehaviour, Observer {
    private Image winScreen;
    private static int lives = 3;
    public winPanel(Image winScreen) {
        this.winScreen = winScreen;
    }
    public void updateVals(float val, Image health) {
        if (health.fillAmount <= 0f) {
            lives--;
            if (lives < 0) {
                winScreen.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            }
        }
    }
}
