using System.Collections;
using UnityEngine;

public class IntroSubtitles : Subtitles
{
    protected override IEnumerator SubSequence()
    {
        yield return new WaitForSeconds(4);
        textBox.text = "How long have I been trapped here?";
        yield return new WaitForSeconds(3.5f);
        textBox.text = "How long have I been wandering in this suffocating darkness with nothing but a flicker to sustain me?";
        yield return new WaitForSeconds(6);
        textBox.text = "It seems that I have no choice but to continue on and hope that the cycle of suffering will end.";
        yield return new WaitForSeconds(6);
        textBox.text = "This place, as strange as my cage is, the walls hold a sort of familiarity to them...";
        yield return new WaitForSeconds(11);
        textBox.text = "I have seen this place ennumerable times and yet...";
        yield return new WaitForSeconds(4);
        textBox.text = "It is ever so different.";
    }
}
