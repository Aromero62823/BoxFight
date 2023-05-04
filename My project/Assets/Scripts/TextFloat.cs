using UnityEngine;

public class TextFloat : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 2.5f) * 10 + 275, 1);
    }
}
