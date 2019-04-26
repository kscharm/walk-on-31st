using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayTime : MonoBehaviour
{
    public Text time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = "Your time: " + ((9.0f*60f) - Global.time) + " seconds";
    }
}
