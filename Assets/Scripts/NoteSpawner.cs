using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] notes;

    private GameObject noteToCreate;
    private int currentNote = 0;

    private void Start()
    {
        noteToCreate = Instantiate(notes[0], notes[0].transform.position, notes[0].transform.rotation); //on start spawn first note
        noteToCreate.transform.parent = gameObject.transform; //child to note spawner
    }

    private void OnRespawn()
    {
        currentNote++;
        noteToCreate = Instantiate(notes[currentNote], notes[currentNote].transform.position, notes[currentNote].transform.rotation);
        noteToCreate.transform.parent = gameObject.transform; //child to note spawner
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
