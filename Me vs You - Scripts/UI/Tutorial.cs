using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    [SerializeField] GameObject firstTutBut;
    [SerializeField] GameObject secondTutBut;
    [SerializeField] GameObject thirdTutBut;
    [SerializeField] GameObject forthTutBut;
    [SerializeField] GameObject fifthTutBut;
    [SerializeField] GameObject sixthTutBut;

    public bool isInteracting = true;

    [SerializeField] UnityEvent eventsActive;
    [SerializeField] UnityEvent deactive;

    int tutCount = 0;

    IEnumerator Start()
    {
        this.enabled = false;
        yield return new WaitForSeconds(1f);
        this.enabled = true;
        instance = this;
        eventsActive.Invoke();
        IngameUIHandler.instance.GetNextButton(firstTutBut);
    }


    void Update()
    {
        if (isInteracting)
        {
            Player.instance.Input.DisablePause();

            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void DisableInteracting()
    {
        deactive.Invoke();
        isInteracting = false;
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
