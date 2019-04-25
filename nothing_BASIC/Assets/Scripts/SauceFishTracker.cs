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

        if (Global.hasGreenFish) {
            greenFishCondition.satisfied = true;
        } else if (Global.hasYellowFish) {
            yellowFishCondition.satisfied = true;
        } else if (Global.hasRedFish) {
            redFishCondition.satisfied = true;
        } else if (Global.hasPurpleFish) {
            purpleFishCondition.satisfied = true;
        } else if (Global.hasBlueFish) {
            blueFishCondition.satisfied = true;
        }

        if (Global.hasRedSauce) {
            redSauceCondition.satisfied = true;
        } else if (Global.hasBlueSauce) {
            blueSauceCondition.satisfied = true;
        } else if (Global.hasGreenSauce) {
            greenSauceCondition.satisfied = true;
        } else if (Global.hasPinkSauce) {
            pinkSauceCondition.satisfied = true;
        } else if (Global.hasOrangeSauce) {
            orangeSauceCondition.satisfied = true;
        }

    }

    // Update is called once per frame
    void Update()
    {   
        if (greenFishCondition.satisfied) {
            Global.hasGreenFish = true;
        } else if (yellowFishCondition.satisfied) {
            Global.hasYellowFish = true;
        } else if (redFishCondition.satisfied) {
            Global.hasRedFish = true;
        } else if (purpleFishCondition.satisfied) {
            Global.hasPurpleFish = true;
        } else if (blueFishCondition.satisfied) {
            Global.hasBlueFish = true;
        }

        if (redSauceCondition.satisfied) {
            Global.hasRedSauce = true;
        } else if (blueSauceCondition.satisfied) {
            Global.hasBlueSauce = true;
        } else if (greenSauceCondition.satisfied) {
            Global.hasGreenSauce = true;
        } else if (pinkSauceCondition.satisfied) {
            Global.hasPinkSauce = true;
        } else if (orangeSauceCondition.satisfied) {
            Global.hasOrangeSauce = true;
        }

    }

    public bool isCorrectCombination() {
        //Orange Sauce + Green Fish
        return orangeSauceCondition.satisfied && greenFishCondition.satisfied;
    }
    public bool isCorrectCombination2() {
        //green Sauce + Yellow Fish
        return greenSauceCondition.satisfied && yellowFishCondition.satisfied;
    }

}
