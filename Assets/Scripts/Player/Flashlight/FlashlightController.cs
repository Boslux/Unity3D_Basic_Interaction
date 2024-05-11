using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public void Flashlight()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!gameObject.activeSelf)
               gameObject.SetActive(true);

            else
                gameObject.SetActive(false);
            
        }
    }
}
