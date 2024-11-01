using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Showpopup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Showpopup();
        }
        
    }

    void Showpopup()
    {
        PopupManager.Instance.AddPopupToQueue(typeof(TOSPopup));
        PopupManager.Instance.AddPopupToQueue(typeof(InfoPopup));
        PopupManager.Instance.AddPopupToQueue(typeof(WarningPopup));
    }


    
}
