using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartContainer : MonoBehaviour
{
    public PlayerHeartContainer next;   // A single List
    [Range(0, 1)]float fill;
    [SerializeField] Image fillImage = null;

    public void SetHeart(float count)
    {
        fill = count;
        fillImage.fillAmount = fill;
        count--;

        if(next != null)
        {
            next.SetHeart(count);
        }
    }

    /*
     Man fängt mit dem ersten Herz an. WENN der float count einen Wert über 1 hat (z.B. 3.5), dann wird der erste Herz um eins erhöht,
     da die max. Range des fills nur 1 beträgt, geht es zu dem nächsten Herz über, denn es sind noch 2.5 Herze übrig, da Count um 1 verringert wird.
     Wenn das nächste Herz existiert wird das auch um 1 erhöht und es bleiben 1.5 übrig. Das geht so weiter, bis der Wert negativ ist.
     Da der negative Wert die anderen Herze durchläuft, werden sie automatisch 0, sprich es werden keine Herze dazu addiert.
    */
}
