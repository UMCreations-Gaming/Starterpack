using UnityEngine;
using UnityEngine.UI;

public class TOSPopup : BasePopup
{
     

    private void Awake()
    {
         
    }

    public override void Show()
    {
   
        AnimateShow(); // Show the popup with animation
    }

    public void OnAccept()
    {
        // Handle TOS acceptance
        Debug.Log("User accepted the Terms of Service.");
        Close(); // Close the popup
    }

    private void OnDecline()
    {
        // Handle TOS decline
        Debug.Log("User declined the Terms of Service.");
        Close(); // Close the popup
    }
}
