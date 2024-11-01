using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    [SerializeField] private Transform popupParent; // Parent object to hold all popups
    [SerializeField] private List<BasePopup> popupPrefabs; // List of popup prefabs to pre-instantiate

    private Queue<Type> popupQueue = new Queue<Type>();
    private bool isPopupActive = false;

    // Dictionary to store instantiated popup instances
    private Dictionary<Type, BasePopup> popupDictionary = new Dictionary<Type, BasePopup>();

    private void Awake()
    {
        Instance = this;
        InitializePopups();
    }

    // Pre-instantiates each popup and stores it in the dictionary
    private void InitializePopups()
    {
        foreach (var popupPrefab in popupPrefabs)
        {
            var popupInstance = Instantiate(popupPrefab, popupParent);
            popupInstance.gameObject.SetActive(false); // Start with each popup disabled
            popupDictionary[popupPrefab.GetType()] = popupInstance;
        }
    }

    // Adds a popup type to the queue and shows it if no other popup is active
    public void AddPopupToQueue(Type popupType)
    {
        if (!popupDictionary.ContainsKey(popupType))
        {
            Debug.LogError($"{popupType} is not a valid popup type.");
            return;
        }
       

        popupQueue.Enqueue(popupType);
        if (!isPopupActive)
        {
            ShowNextPopup();
        }
    }

    private void ShowNextPopup()
    {
        if (popupQueue.Count == 0) return;

        Type popupType = popupQueue.Dequeue();

        if (popupDictionary.TryGetValue(popupType, out BasePopup popup))
        {
            popup.gameObject.SetActive(true); // Enable the popup
            popup.Show(); // Call the Show method to animate and display content

            switch (popup.ThisPopuptype)
            {
                case PopupType.TostPopup:
                    StartCoroutine(AutoCloseToast(popup));
                    break;
                case PopupType.Popup:
                    break;
            }
            
            isPopupActive = true;
        }
    }

    public void OnPopupClosed()
    {
        Debug.Log("close popup ");
        isPopupActive = false;
        ShowNextPopup();
    }

    private IEnumerator AutoCloseToast(BasePopup popup)
    {
        yield return new WaitForSeconds(popup.AutoCloseDuration); // Wait for set duration
        popup.Close(); // Close the toast popup
    }
}
