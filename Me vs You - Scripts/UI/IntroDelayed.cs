using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroDelayed : MonoBehaviour
{
    [SerializeField] VideoPlayer player;
    void Start()
    {
        player.enabled = false;
        StartCoroutine(wasMaen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wasMaen()
    {
        yield return new WaitForSeconds(2f);
        player.enabled = true;
    }
}
