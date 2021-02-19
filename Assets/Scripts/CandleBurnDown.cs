using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleBurnDown : MonoBehaviour
{

    public int DeathCount = 0;
    public float CandleScale = 1;
    public GameObject CandlePivotPointer;
    public float CandleDurationSeconds = 300;
    public float CandleDurationSecondsLIVE;
    public GameObject DeathMaskPointer;
    private CanvasGroup canvasGroup;
    private bool hold = false;
    private bool dyinganim = false;


    // Start is called before the first frame update
    void Start()
    {

        CandleDurationSecondsLIVE = CandleDurationSeconds;
        canvasGroup = DeathMaskPointer.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && CandleScale > 0f && !hold)
        {
            CandleDurationSecondsLIVE -= 2 *Time.deltaTime;
        }
        else if (CandleScale > 0f && !hold)
        {
            CandleDurationSecondsLIVE -= 1 * Time.deltaTime;
        }

        CandleScale = CandleDurationSecondsLIVE / CandleDurationSeconds;

        CandlePivotPointer.transform.localScale = new Vector3(1f, CandleScale, 1f);

        if (CandleScale <= 0.1f && !hold)
        {
            TriggerDeath();
            DeathCount++;
        }

        if (dyinganim)
        {
            canvasGroup.alpha += 0.005f;
            if (canvasGroup.alpha >= .95)
            {
                dyinganim = false;
                Invoke("DeathReset", 2f);
            }
        }

    }

    private void TriggerDeath()
    {

        hold = true;

        CandlePivotPointer.transform.localScale = new Vector3(0f, 0f, 0f);

        //trigger audio que for pre-death

        Invoke("DeathAnim", 5f);

    }

    private void DeathAnim()
    {

        dyinganim = true;

    }

    private void DeathReset()
    {

        dyinganim = false;
        hold = false;
        CandleDurationSecondsLIVE = CandleDurationSeconds + (DeathCount * 10);
        CandleDurationSeconds = CandleDurationSecondsLIVE;
        canvasGroup.alpha = 0f;
        CandleScale = 1;

        //gameObject.transform.position = new Vector3(4.86f,0.25f,-13.58f);
        SceneManager.LoadScene("Prototype");////////////////////////////////////////////////////////////////HARD CODED TEMP, NEED TO FIX
        Debug.Log("ahhh");

    }


}
