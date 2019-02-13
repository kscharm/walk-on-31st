using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{

    GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();

    // Use this for initialization
    void Start()
    {
        //Not sure if this does anything
        definedButton = this.gameObject;
    }

    void invokeOnClick()
    {
        OnClick.Invoke();
    }
}