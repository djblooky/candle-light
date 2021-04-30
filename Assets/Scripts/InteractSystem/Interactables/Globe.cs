using System.Collections;
using UnityEngine;

public class Globe : Openable
{
    [SerializeField] Door doorToUnlock;
    [SerializeField] GameObject keyItemInside;
    [SerializeField] protected AudioSource globeAudioSource;
    [SerializeField] protected AudioClip globeUnlock, doorUnlock, piecePlaced;


    private int piecesRemaining = 3;

    private void Start()
    {
        isLocked = true;
    }

    private void OnPiecePlaced()
    {
        Debug.Log("Piece Placed");
        piecesRemaining--;
        globeAudioSource.PlayOneShot(piecePlaced);
        CheckForUnlockedDoor();
    }

    private void CheckForUnlockedDoor()
    {
        if (piecesRemaining <= 0 && isLocked == true)
        {
           
            isLocked = false;
            Debug.Log("Globe opened");
            IsOpen = true;
            StartCoroutine(MakeKeyItemInteractable());
            doorToUnlock.isLocked = false;
            var dooraudioscource = doorToUnlock.gameObject.GetComponent<AudioSource>();
            globeAudioSource.PlayOneShot(globeUnlock);
            new WaitForSeconds(1);
            dooraudioscource.PlayOneShot(doorUnlock);
        }
    }

    IEnumerator MakeKeyItemInteractable()
    {
        yield return new WaitForSeconds(1); //TODO: change to length of open animation
        keyItemInside.tag = "InteractiveObject";
    }

    private void OnEnable()
    {
        EquipmentManager.ObjectPlaced += OnPiecePlaced;
    }

    private void OnDisable()
    {
        EquipmentManager.ObjectPlaced -= OnPiecePlaced;
    }
}
