using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinConditionals : MonoBehaviour
{

    public Condition correctCombo1;
    //public SauceFishTracker tracker;
    public GameObject mixingPot;
    private SauceFishTracker tracker;

    void Start() {
        tracker = mixingPot.GetComponent<SauceFishTracker>();
    }

    // Update is called once per frame
    void Update() {
        //Red Sauce + Yellow Fish
        if (tracker.isCorrectCombination()) {
            correctCombo1.satisfied = true;
        } else {
            correctCombo1.satisfied = false;
        }
    }
}
