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
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
        }
        SetTimerText();
    }

    void SetTimerText()
    {
        timer.text = "Time remaining: " + Mathf.Round(timeLeft * 10f) / 10f;
    }
}
