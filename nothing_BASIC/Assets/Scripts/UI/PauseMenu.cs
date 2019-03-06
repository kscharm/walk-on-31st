using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private CanvasGroup canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.Escape)) {
            if (canvas.interactable)
            {
                canvas.interactable = false;
                canvas.blocksRaycasts = false;
                canvas.alpha = 0f;
                Time.timeScale = 1f;
            } else
            {
                canvas.interactable = true;
                canvas.blocksRaycasts = true;
                canvas.alpha = 1f;
                Time.timeScale = 0f;
            }
        }
    }
}
