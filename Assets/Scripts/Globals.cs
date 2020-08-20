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
        if (Input.GetMouseButton(0))
            paused = false;
        if (Input.GetKeyDown(KeyCode.Space))
            paused = !paused;
        pausedTextObject.SetActive(paused);
        hintText.SetActive(paused);
    }
}
