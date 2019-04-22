using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceFishTracker : MonoBehaviour
{

    public Condition redSauceCondition;
    public Condition blueSauceCondition;
    public Condition greenSauceCondition;
    public Condition pinkSauceCondition;
    public Condition orangeSauceCondition;
    public Condition yellowFishCondition;
    public Condition redFishCondition;
    public Condition greenFishCondition;
    public Condition purpleFishCondition;
    public Condition blueFishCondition;

    // Start is called before the first frame update
    void Start()
    {
        redSauceCondition.satisfied = false;
        blueSauceCondition.satisfied = false;
        greenSauceCondition.satisfied = false;
        pinkSauceCondition.satisfied = false;
        orangeSauceCondition.satisfied = false;

        yellowFishCondition.satisfied = false;
        redFishCondition.satisfied = false;
        greenFishCondition.satisfied = false;
        purpleFishCondition.satisfied = false;
        blueFishCondition.satisfied = false;

    }

    // Update is called once per frame
    void Update()
    {   

    }

    public bool isCorrectCombination() {
        //Red Sauce + Yellow Fish
        return redSauceCondition.satisfied && yellowFishCondition.satisfied;
    }
    public bool isCorrectCombination2() {
        //Orange Sauce + Purple Fish
        return orangeSauceCondition.satisfied && purpleFishCondition.satisfied;
    }

}
