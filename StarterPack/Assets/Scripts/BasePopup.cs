using UnityEngine;
using DG.Tweening;
using System;

public abstract class BasePopup : MonoBehaviour
{
    [SerializeField] protected float animationDuration = 0.5f; // Duration for animations
     public float AutoCloseDuration = 2.0f; // Default auto-close duration for toast


    public PopupType ThisPopuptype;
    protected virtual void Start()
    {
        // Add a close button or listener if necessary
    }

    public abstract void Show();

    public virtual void Close()
    {
        Debug.Log("close click");
        AnimateClose();
    }

    protected void AnimateShow()
    {
        transform.localScale = Vector3.zero; // Start with no scale
        transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.OutBack);
    }

    protected void AnimateClose()
    {
        transform.DOScale(Vector3.zero, animationDuration).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                gameObject.SetActive(false); // Disable popup after animation
                PopupManager.Instance.OnPopupClosed();
            });
    }
}

public enum PopupType
{
    Popup,
    TostPopup
}
