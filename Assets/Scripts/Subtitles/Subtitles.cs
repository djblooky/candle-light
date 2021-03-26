using System.Collections;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    [SerializeField] protected TMP_Text textBox;
    [SerializeField] private TMP_Text settingsButtonText; //TODO: add settings toggle for subtitles
    [SerializeField] private bool areSubtitlesOn = false;

    private void Start()
    {
        StartCoroutine(SubSequence());
    }

    protected virtual IEnumerator SubSequence()
    {
        return null;
    }

    /// <summary>
    /// An event to link to a settings button
    /// </summary>
    public void SwitchSubtitles()
    {
        if (areSubtitlesOn)
        {
            textBox.enabled = false;
            areSubtitlesOn = false;
            settingsButtonText.text = "Turn On Subtitles";
            return;
        }
        else
        {
            textBox.enabled = true;
            areSubtitlesOn = true;
            settingsButtonText.text = "Turn Off Subtitles";
            return;
        }
    }
}
