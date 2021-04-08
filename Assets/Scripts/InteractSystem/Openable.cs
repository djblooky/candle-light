using UnityEngine;

public class Openable : InteractiveObject
{
    public bool IsOpen
    {
        get { return isOpen; }

        set
        {
            animator.SetBool(isOpenAnimatorParam, value);
            isOpen = value;
        }
    }

    [Header("Openable.cs")]
    [SerializeField]
    public bool isLocked = false;

    [SerializeField]
    private bool canBeClosed = true;

    //[SerializeField]
    private string openText = "open", closeText = "close";

    [SerializeField]
    private AudioClip openSound, closeSound, lockedSound, slamSound, unlockSound;

    [SerializeField]
    protected Animator animator;

    protected bool isOpen = false;
    private readonly int isOpenAnimatorParam = Animator.StringToHash("isOpen");

    public override void Interact()
    {
        ToggleOpen();
    }

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);

        if(!isLocked)
            SetHoverText();
    }

    private void SetHoverText()
    {
        if (IsOpen)
        {
            hoverText = closeText + " " + objectName;
        }
        else
        {
            hoverText = openText + " " + objectName;
        }
    }

    private void ToggleOpen()
    {
        if (isLocked)
        {
            hoverText = "Locked";
            audioSource.PlayOneShot(lockedSound);
        }
        else
        {
            if (isOpen && canBeClosed)
            {
                IsOpen = false;
                audioSource.PlayOneShot(closeSound);
            }
            else
            {
                IsOpen = true;
                audioSource.PlayOneShot(openSound);
                if (!canBeClosed)
                    gameObject.tag = "Untagged";
            }
        }
    }
}
