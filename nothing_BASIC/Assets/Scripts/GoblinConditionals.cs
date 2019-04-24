using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinConditionals : MonoBehaviour
{

    public Condition correctCombo1;
    public Condition correctCombo2;
    public Condition bothGoblinsSatisfied;
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
        bothGoblinsSatisfied.satisfied = false;
        if (Global.goblin1Done) {
            goblin1Satisfied.satisfied = true;
        }
        if (Global.golbin2Done) {
            goblin2Satisfied.satisfied = true;
        }
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

        if (goblin1Satisfied.satisfied) {
            goblinBehavior1.victoryCheer();
            Global.goblin1Done = true;
        }
        if (goblin1Angry.satisfied) {
            goblinBehavior1.hitPlayer();
            goblin1Angry.satisfied = false;
        }


        if (goblin2Satisfied.satisfied) {
            goblinBehavior2.victoryCheer();
            Global.golbin2Done = true;
        }
        if (goblin2Angry.satisfied) {
            goblinBehavior2.hitPlayer();
            goblin2Angry.satisfied = false;
        }

        if (goblin2Satisfied.satisfied && goblin1Satisfied.satisfied) {
            bothGoblinsSatisfied.satisfied = true;
        }



    }
}
