using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    public GameObject pausedTextObject;
    public GameObject hintText;
    public static bool paused = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
            paused = false;
        if (Input.GetKey(KeyCode.Space))
            paused = !paused;
        pausedTextObject.SetActive(paused);
        hintText.SetActive(paused);
    }
}
