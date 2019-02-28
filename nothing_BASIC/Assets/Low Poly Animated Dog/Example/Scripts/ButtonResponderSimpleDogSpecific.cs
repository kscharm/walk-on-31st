using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonResponderSimpleDogSpecific : MonoBehaviour
{
    public GameObject[] GameObjects;
    private int CurrentModel = 0;
    private AnimateLowPolyDog CurrentModelSelected;
    private GameObject Camera;


    void Start()
    {
        Camera = GameObject.Find("Camera");
        CurrentModelSelected = GameObjects[CurrentModel].GetComponent<AnimateLowPolyDog>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonResponderClicked()
    {
        if (CurrentModel < GameObjects.Length - 1)
        {
            CurrentModel++;
        }
        else CurrentModel = 0;
        CurrentModelSelected = GameObjects[CurrentModel].GetComponent<AnimateLowPolyDog>();
        Camera.GetComponentInChildren<MouseOrbitImprovedMod>().target = GameObjects[CurrentModel].transform;
        GetComponentInChildren<Text>().text = CurrentModelSelected.name;
    }
    public void StandButtonClicked()
    {
        CurrentModelSelected.StandButtonClicked();
        print("Stand Button CLicked");
    }
    public void SitButtonClicked()
    {
        CurrentModelSelected.SitButtonClicked();
    }
    public void LayButtonClicked()
    {
        CurrentModelSelected.LayButtonClicked();
    }
    public void ConsumeButtonClicked()
    {
        CurrentModelSelected.ConsumeButtonClicked();
    }
    public void AggressiveButtonClicked()
    {
        CurrentModelSelected.AggressiveButtonClicked();
    }
    public void WalkButtonClicked()
    {
        CurrentModelSelected.WalkButtonClicked();
    }
    public void ChangeMatButtonClicked()
    {
        print("Change mat clicked");
        CurrentModelSelected.GetComponentInChildren<ChangeShader>().ChangeShaderButtonClicked();
    }
    public void ChangeBlendButtonClicked()
    {
        CurrentModelSelected.GetComponentInChildren<ChangeBlendShape>().ChangeBlend();
    }
}
