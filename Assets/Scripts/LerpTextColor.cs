using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpTextColor : MonoBehaviour
{
    public Color firstColor;
    public Color secondColor;
    public float lerpDuration;
    private Text _text;
    private float t;
    private bool change;
    
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.color = Color.Lerp(firstColor, secondColor, t);
        var sec = Time.deltaTime / lerpDuration;
        if (!change)
            t += sec;
        else
            t -= sec;
        if (t >= 1)
            change = true;
        if (t <= 0)
            change = false;
    }
}
