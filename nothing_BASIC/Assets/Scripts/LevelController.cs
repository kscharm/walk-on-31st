using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Text timer;
   public float timeLeft = 120f;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = Global.timerText;
        SetTimerText();
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
        timer.text = Global.timerText;
        SetTimerText();
    }

    void SetTimerText()
    {
        timer.text = "Time remaining: " + Mathf.Round(Global.time * 10f) / 10f;
        Global.timerText = timer.text;
    }
}
