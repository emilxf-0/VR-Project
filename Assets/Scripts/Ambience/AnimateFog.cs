using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFog : MonoBehaviour
{
    public Material fogMat;
    private Color myColor;
    private float startAlpha;
    private float endAlpha;
    public float steppingAlpha;
    private bool isIncreasing;
    private Camera mainCamera;
   

    public float scrollSpeed = 1.0f;
    public Vector2 scrollDirection = new Vector2(1.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        // Initialize myColor with the initial color of the material
        myColor = fogMat.color;
        startAlpha = 0.1f;
        endAlpha = 0.8f;
        steppingAlpha = 0.001f;
        isIncreasing = true;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing)
        {
            myColor.a += steppingAlpha;
        }
        else
        {
            myColor.a -= steppingAlpha;
        }

        // Ensure alpha remains within the range [startAlpha, endAlpha]
        myColor.a = Mathf.Clamp(myColor.a, startAlpha, endAlpha);

        // Update the tiling offset of the material
        float offset = Time.time * scrollSpeed;
        Vector2 offsetVector = new Vector2(offset * scrollDirection.x, offset * scrollDirection.y);
        fogMat.SetTextureOffset("_MainTex", offsetVector);

        // Make the game object face the camera
     //   Vector3 lookAtPosition = transform.position + mainCamera.transform.rotation * Vector3.forward;
       // transform.LookAt(lookAtPosition);


        // Assign the updated color back to the material
        fogMat.color = myColor;

        if (myColor.a >= endAlpha && isIncreasing)
        {
            isIncreasing = false;
        }
        else if (myColor.a <= startAlpha && !isIncreasing)
        {
            isIncreasing = true;
        }
    }
}