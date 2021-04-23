using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowTitleAnimation : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// For animation event at end of Open.anim
    /// </summary>
    public void OpenAnimationDone()
    {
        animator.SetBool("isOpen", true);
    }

    //triggers when start button is pressed
    public void OnStartButtonPressed()
    {
        animator.SetBool("startPressed", true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
