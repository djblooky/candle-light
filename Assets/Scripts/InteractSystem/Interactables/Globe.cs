using UnityEngine;

public class Globe : Openable
{
    private int piecesRemaining = 3;

    private void Start()
    {
        isLocked = true;
    }

    private void OnPiecePlaced()
    {
        Debug.Log("Piece Placed");
        piecesRemaining--;
        //play SFX
        CheckForUnlockedDoor();
    }

    private void CheckForUnlockedDoor()
    {
        if (piecesRemaining <= 0)
        {
            isLocked = false;
            Debug.Log("Globe opened");
            //animate globe open
        }
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
