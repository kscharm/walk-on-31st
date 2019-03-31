using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionFishTracker : MonoBehaviour
{
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
                    spicySelected = !spicySelected;
                } else if (hit.transform.name == "SourInteractable") {
                    sourSelected = !sourSelected;
                } else if (hit.transform.name == "SweetInteractable") {
                    sweetSelected = !sweetSelected;
                } else if (hit.transform.name == "SaltyInteractable") {
                    saltySelected = !saltySelected;
                } else if (hit.transform.name == "CreamyInteractable") {
                    creamySelected = !creamySelected;
                } else if (hit.transform.name == "SardinesInteractable") {
                    sardinesSelected = !sardinesSelected;
                } else if (hit.transform.name == "TunaInteractable") {
                    tunaSelected = !tunaSelected;
                } else if (hit.transform.name == "CatfishInteractable") {
                    catfishSelected = !catfishSelected;
                } else if (hit.transform.name == "SalmonInteractable") {
                    salmonSelected = !salmonSelected;
                } else if (hit.transform.name == "CodInteractable") {
                    codSelected = !codSelected;
                }
            }
        }
    }

    public bool isCorrectCombination() {
        //Check if certain booleans are true
        return false;
    }
}
