using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinConditionals : MonoBehaviour
{

    public Condition correctCombo1;
    //public SauceFishTracker tracker;
    public GameObject mixingPot;
    private SauceFishTracker tracker;
    public GoblinBehavior goblinBehavior;
    public Condition goblin1Satisfied;
    public Condition goblin1Angry;

    

    void Start() {
        tracker = mixingPot.GetComponent<SauceFishTracker>();
        goblin1Satisfied.satisfied = false;
        goblin1Angry.satisfied = false;
    }

    // Update is called once per frame
    void Update() {
        //Red Sauce + Yellow Fish
        if (tracker.isCorrectCombination()) {
            correctCombo1.satisfied = true;
        } else {
            correctCombo1.satisfied = false;
        }
        if (goblin1Angry.satisfied == false) {
            goblinBehavior.resetToIdle();
        }
        if (goblin1Satisfied.satisfied == true) {
            goblinBehavior.victoryCheer();
        }
        if (goblin1Angry.satisfied == true) {
            goblinBehavior.hitPlayer();
            goblin1Angry.satisfied = false;
        }



    }
}
