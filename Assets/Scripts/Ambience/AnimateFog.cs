using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFog : MonoBehaviour
{
    public Material fogMat;

    public Color myColor;
    private float startAlfa;
    private float endAlfa;
    public float steppingAlfa;
    private bool isIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        startAlfa = 0.1f;
        endAlfa = 0.8f;
        steppingAlfa = 0.001f;
        isIncreasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing)
        {
            myColor.a += steppingAlfa;
        }
        else
        {
            myColor.a -= steppingAlfa;
        }
        fogMat.color = myColor;
        if (myColor.a > endAlfa && isIncreasing)
        {
            isIncreasing = false;
        }
        if (myColor.a < startAlfa && !isIncreasing)
        {
            isIncreasing = true;
        }
    }
}
