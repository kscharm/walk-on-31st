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
    private bool sardinesSelected = false;
    private bool tunaSelected = false;
    private bool catfishSelected = false;
    private bool salmonSelected = false;
    private bool codSelected = false;
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
                } else if (hit.transform.name == "SardinesInteractable") {
                    sardinesSelected = true;
                    tunaSelected = false;
                    catfishSelected = false;
                    salmonSelected = false;
                    codSelected = false;
                } else if (hit.transform.name == "TunaInteractable") {
                    sardinesSelected = false;
                    tunaSelected = true;
                    catfishSelected = false;
                    salmonSelected = false;
                    codSelected = false;
                } else if (hit.transform.name == "CatfishInteractable") {
                    sardinesSelected = false;
                    tunaSelected = false;
                    catfishSelected = true;
                    salmonSelected = false;
                    codSelected = false;
                } else if (hit.transform.name == "SalmonInteractable") {
                    sardinesSelected = false;
                    tunaSelected = false;
                    catfishSelected = false;
                    salmonSelected = true;
                    codSelected = false;
                } else if (hit.transform.name == "CodInteractable") {
                    sardinesSelected = false;
                    tunaSelected = false;
                    catfishSelected = false;
                    salmonSelected = false;
                    codSelected = true;
                }
            }
        }
    }

    public bool isCorrectCombination() {
        //Check if certain booleans are true
        //Conditions = Has at least one sauce and one fish selected
        return sauceCondition.satisfied && fishCondition.satisfied && spicySelected && sardinesSelected;
    }
}
