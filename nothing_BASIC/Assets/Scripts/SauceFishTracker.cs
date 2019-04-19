using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceFishTracker : MonoBehaviour
{
    public Condition sauceCondition;
    public Condition fishCondition;
    private bool spicySelected = false;
    private bool sourSelected = false;
    private bool sweetSelected = false;
    private bool saltySelected = false;
    private bool creamySelected = false;
    private bool yellowFishSelected = false;
    private bool redFishSelected = false;
    private bool blueFishSelected = false;
    private bool greenFishSelected = false;
    private bool purpleFishSelected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //Changes boolean values when cauldrons are selected. 
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "SpicyInteractable") {
                    spicySelected = true;
                    sourSelected = false;
                    sweetSelected = false;
                    saltySelected = false;
                    creamySelected = false;
                } else if (hit.transform.name == "SourInteractable") {
                    spicySelected = false;
                    sourSelected = true;
                    sweetSelected = false;
                    saltySelected = false;
                    creamySelected = false;
                } else if (hit.transform.name == "SweetInteractable") {
                    spicySelected = false;
                    sourSelected = false;
                    sweetSelected = true;
                    saltySelected = false;
                    creamySelected = false;
                } else if (hit.transform.name == "SaltyInteractable") {
                    spicySelected = false;
                    sourSelected = false;
                    sweetSelected = false;
                    saltySelected = true;
                    creamySelected = false;
                } else if (hit.transform.name == "CreamyInteractable") {
                    spicySelected = false;
                    sourSelected = false;
                    sweetSelected = false;
                    saltySelected = false;
                    creamySelected = true;
                } else if (hit.transform.name == "YellowFishInteractable") {
                    yellowFishSelected = true;
                    redFishSelected = false;
                    blueFishSelected = false;
                    greenFishSelected = false;
                    purpleFishSelected = false;
                } else if (hit.transform.name == "RedFishInteractable") {
                    yellowFishSelected = false;
                    redFishSelected = true;
                    blueFishSelected = false;
                    greenFishSelected = false;
                    purpleFishSelected = false;
                } else if (hit.transform.name == "BlueFishInteractable") {
                    yellowFishSelected = false;
                    redFishSelected = false;
                    blueFishSelected = true;
                    greenFishSelected = false;
                    purpleFishSelected = false;
                } else if (hit.transform.name == "GreenFishInteractable") {
                    yellowFishSelected = false;
                    redFishSelected = false;
                    blueFishSelected = false;
                    greenFishSelected = true;
                    purpleFishSelected = false;
                } else if (hit.transform.name == "PurpleFishInteractable") {
                    yellowFishSelected = false;
                    redFishSelected = false;
                    blueFishSelected = false;
                    greenFishSelected = false;
                    purpleFishSelected = true;
                }
            }
        }
    }

    public bool isCorrectCombination() {
        //Check if certain booleans are true
        //Conditions = Has at least one sauce and one fish selected
        return spicySelected && yellowFishSelected;
    }
}
