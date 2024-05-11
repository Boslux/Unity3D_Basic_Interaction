using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [Header("Component")]
    Outline outline;
    public UnityEvent onInteraction;
    
    [Header("")]
    public string message;

    
    void Start()
    {
        outline=GetComponent<Outline>();
        DisableOutline();
    }
    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        outline.enabled=false;
    }
    public void EnableOutline()
    {
        outline.enabled=true;
    }
}
