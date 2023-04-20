using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inherit : MonoBehaviour
{
    public Image childImage;
    private Image parentImage;
    private void Start() {
        parentImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        childImage.fillAmount = parentImage.fillAmount;
    }
}
