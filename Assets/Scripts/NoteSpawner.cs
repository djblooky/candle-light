using System;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static event Action NoteSpawned; 

    [SerializeField] private GameObject[] notes;

    private GameObject noteToCreate;
    private int currentNote = 0;

    private void Start()
    {
        OnRespawn();
    }

    private void OnRespawn()
    {
        if(currentNote < notes.Length)
        {
            noteToCreate = Instantiate(notes[currentNote], notes[currentNote].transform.position, notes[currentNote].transform.rotation);
            noteToCreate.transform.parent = gameObject.transform; //child to note spawner
            currentNote++;
            NoteSpawned?.Invoke();
        }
    }

    private void OnEnable()
    {
        RespawnManager.RespawnTriggered += OnRespawn;
    }

    private void OnDisable()
    {
        RespawnManager.RespawnTriggered -= OnRespawn;
    }
}
