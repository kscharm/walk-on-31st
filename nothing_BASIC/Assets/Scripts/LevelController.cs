using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        SetTimerText();
        Global.time += 300f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.time >= 0)
        {
            Global.time -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
        }
        SetTimerText();
    }

    void SetTimerText()
    {
        timer.text = "Time remaining: " + Mathf.Round(Global.time * 10f) / 10f;
    }
}
