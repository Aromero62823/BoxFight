using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, Observer {
    
    public Health() {}

    public void updateVals(float val, Image health) {
        if(health.fillAmount <= 0f) {
            health.fillAmount = 1f;
            
        } else {
            health.fillAmount = health.fillAmount - val;
        }
    }
}
