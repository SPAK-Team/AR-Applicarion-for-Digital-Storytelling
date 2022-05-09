using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashing : MonoBehaviour
{
    public Text GreetingText;
    public Color yellow => Color.yellow;
    public Color purple => new Color(0.5f, 0.48f, 0.84f);
    public Color blue => Color.blue;
    public Color black => Color.black;

    public Color Lerp(Color firstColor, Color secondColor, float speed) => Color.Lerp(firstColor, secondColor, Mathf.Sin(Time.time * speed));

    public void Update()
    {
        GreetingText.color = Lerp(blue, black, 10);
    }
}
