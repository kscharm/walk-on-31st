using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinConditionals : MonoBehaviour
{

    public Condition correctCombo1;
    public Condition correctCombo2;
    public GameObject mixingPot;
    private SauceFishTracker tracker;
    public GoblinBehavior goblinBehavior1;
    public GoblinBehavior goblinBehavior2;
    public Condition goblin1Satisfied;
    public Condition goblin1Angry;
    public Condition goblin2Satisfied;
    public Condition goblin2Angry;

    

    void Start() {
        tracker = mixingPot.GetComponent<SauceFishTracker>();
        goblin1Satisfied.satisfied = false;
        goblin1Angry.satisfied = false;
        goblin2Satisfied.satisfied = false;
        goblin2Angry.satisfied = false;
    }

    // Update is called once per frame
    void Update() {
        //Red Sauce + Yellow Fish
        if (tracker.isCorrectCombination()) {
            correctCombo1.satisfied = true;
        } else {
            correctCombo1.satisfied = false;
        }

        if (tracker.isCorrectCombination2()) {
            correctCombo2.satisfied = true;
        } else {
            correctCombo2.satisfied = false;
        }

        // if (goblin1Angry.satisfied == false) {
        //     goblinBehavior1.resetToIdle();
        // }
        if (goblin1Satisfied.satisfied == true) {
            goblinBehavior1.victoryCheer();
        }
        if (goblin1Angry.satisfied == true) {
            goblinBehavior1.hitPlayer();
            goblin1Angry.satisfied = false;
        }


        // if (goblin2Angry.satisfied == false) {
        //     goblinBehavior2.resetToIdle();
        // }
        if (goblin2Satisfied.satisfied == true) {
            goblinBehavior2.victoryCheer();
        }
        if (goblin2Angry.satisfied == true) {
            goblinBehavior2.hitPlayer();
            goblin2Angry.satisfied = false;
        }



    }
}
