using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour, Observer {
    private Sprite[] hearts;
    private GameObject livesGO;
    private static int counter;
    public Lives(GameObject livesGO,  Sprite[] lives) {
        hearts = lives;
        this.livesGO = livesGO;
        counter = lives.Length - 1;
    }

    public void updateVals(float damage, Image image) {
        if(image.fillAmount == 0f) {
            livesGO.GetComponent<SpriteRenderer>().sprite = hearts[counter];
            counter = counter - 1;
            if(counter <= 0) {
                counter = 0;
            }
        }
    }
}