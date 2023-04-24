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
     Man f�ngt mit dem ersten Herz an. WENN der float count einen Wert �ber 1 hat (z.B. 3.5), dann wird der erste Herz um eins erh�ht,
     da die max. Range des fills nur 1 betr�gt, geht es zu dem n�chsten Herz �ber, denn es sind noch 2.5 Herze �brig, da Count um 1 verringert wird.
     Wenn das n�chste Herz existiert wird das auch um 1 erh�ht und es bleiben 1.5 �brig. Das geht so weiter, bis der Wert negativ ist.
     Da der negative Wert die anderen Herze durchl�uft, werden sie automatisch 0, sprich es werden keine Herze dazu addiert.
    */
}
