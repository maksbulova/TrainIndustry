using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAlping : MonoBehaviour
{
    Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }


    public Color newColor;
    public float fadeTime = 0.1f; //maybe rename this to fadeSpeed

    //this should be called somewhere in Update
    void FadeOut()
    {
        label.color = Color.Lerp(label.color, newColor, fadeTime * Time.deltaTime);
    }

    private void Update()
    {
        FadeOut();      
    }
}
