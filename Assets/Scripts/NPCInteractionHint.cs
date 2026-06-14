using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NPCInteractionHint : MonoBehaviour
{
    [Header("要顯示 / 隱藏的提示文字")]
    public GameObject talkHintText;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        if (talkHintText != null)
        {
            talkHintText.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (interactable == null)
        {
            interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        }

        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnHoverEntered);
            interactable.hoverExited.AddListener(OnHoverExited);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEntered);
            interactable.hoverExited.RemoveListener(OnHoverExited);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (talkHintText != null)
        {
            talkHintText.SetActive(true);
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        if (talkHintText != null)
        {
            talkHintText.SetActive(false);
        }
    }
}