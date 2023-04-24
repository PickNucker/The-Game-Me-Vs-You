using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] CanvasGroup button;
    [SerializeField] string sceneName;
    [SerializeField] bool savePos;

    bool activateButton;

    float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateButton)
        {
            button.alpha = Mathf.Lerp(button.alpha, 1, Time.deltaTime * 5f);

            if (Input.GetButton("Jump"))
            {
                //    if(savePos)
                //        SaveSystem.instance.SavePos();
                SaveSystem.instance.SaveGame();
                SaveSystem.instance.SavePos();
                SceneManager.LoadScene(sceneName);
            }
        }

        if (!activateButton)
        {
            button.alpha = Mathf.Lerp(button.alpha, 0, Time.deltaTime * 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activateButton = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activateButton = false;
        }
    }
}
