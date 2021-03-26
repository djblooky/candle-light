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
        SpawnNote();
    }

    private void OnRespawn()
    {
        bool LastNoteRead = notes[currentNote].GetComponent<Note>().HasBeenRead;

        if (currentNote < notes.Length) //if there are notes left to spawn
        {
            if (LastNoteRead)
            {
                currentNote++;
                SpawnNote();
            }
        }
    }

    private void SpawnNote()
    {
        Debug.Log("Spawned Note #" + currentNote +1);
        noteToCreate = Instantiate(notes[currentNote], notes[currentNote].transform.position, notes[currentNote].transform.rotation);
        noteToCreate.transform.parent = gameObject.transform; //child to note spawner
        NoteSpawned?.Invoke();
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
