using System.Collections;
using UnityEngine;

public class EndDoor : Openable
{
    public int LocksRemaining
    {
        get { return _locksRemaining; }
        set
        {
            //TODO: update locksRemaining anim param
            _locksRemaining = value;
        }
    }

    [Header("EndDoor.cs")]
    [SerializeField] private int _locksRemaining = 3;
    [SerializeField] private AudioClip lockUnlockedClip;
    [SerializeField] private GameObject doorModel;

    private new AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isLocked = true;
    }

    /// <summary>
    /// The door has multiple locks, when all the locks are unlocked the whole door unlocks
    /// </summary>
    private void OnLockUnlocked()
    {
        audioSource.PlayOneShot(lockUnlockedClip);
        LocksRemaining--;
        RemovePadlock();
        CheckForUnlockedDoor();
    }

    private void RemovePadlock()
    {

    }

    private void CheckForUnlockedDoor()
    {
        if (_locksRemaining <= 0)
        {
            isLocked = false;
            doorModel.GetComponent<Renderer>().enabled = false; //TODO: remove this because door will animate instead
            StartCoroutine(SetDoorInactiveAfterDelay());
        }
    }

    IEnumerator SetDoorInactiveAfterDelay()
    {
        yield return new WaitForSeconds(lockUnlockedClip.length);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        EquipmentManager.ObjectPlaced += OnLockUnlocked; //TODO: change to subscribe from lock script
    }

    private void OnDisable()
    {
        EquipmentManager.ObjectPlaced += OnLockUnlocked;
    }

}
