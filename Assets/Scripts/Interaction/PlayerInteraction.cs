using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
public float playerReach=5f;
Interactable currenInteractable;

    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F)&&currenInteractable!=null)
            {
                currenInteractable.Interact();
            }   
    }

    private void CheckInteraction()
    {
        RaycastHit hit; 
        //Kameranın pozisyonundan cameranın baktığı yöne bir ışın gönder
        Ray ray=new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray,out hit,playerReach))
        {
            if(hit.collider.tag=="Interactable")
            {
                Interactable interactable=hit.collider.GetComponent<Interactable>(); 
                if(currenInteractable&&interactable!=currenInteractable)
                {
                    currenInteractable.DisableOutline();
                }
                if(interactable.enabled)
                {
                    SetNewCurrentInteractable(interactable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    private void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
       if(currenInteractable)
       {
        currenInteractable.DisableOutline();
        currenInteractable=null;
       }
    }

    private void SetNewCurrentInteractable(Interactable interactable)
    {
        currenInteractable=interactable;
        currenInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currenInteractable.message); 
    }
}
