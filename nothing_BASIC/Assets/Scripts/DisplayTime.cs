using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayTime : MonoBehaviour
{
    public Text time;
    public Text minute;
    public Text seconds;
    private float remaining;
    private float minutes;
    
    // Start is called before the first frame update
    void Start()
    {
        remaining = Global.time;
    }

    // Update is called once per frame
    void Update()
    {
        remaining = (540f - Mathf.Round(Global.time * 10f) / 10f);
        if (remaining > 60f)
        {
            //remaining += 2f;
            minutes = Mathf.Floor(remaining / 60);
            remaining = Mathf.Round(remaining%60);
            time.text = "Your time: ";
            minute.text = minutes + " minutes and ";
            seconds.text = +remaining + " seconds";
        }
        else
        {
            time.text = "Your time: " + (540f - Mathf.Round(Global.time * 10f) / 10f);
            minute.text = " seconds";
        }
    }
}
