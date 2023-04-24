using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextPos(i);
            Gizmos.DrawSphere(GetPosition(i), .3f);
            Gizmos.DrawLine(GetPosition(i), GetPosition(j));
        }
    }

    public int GetNextPos(int i)
    {
        if (i + 1 >= transform.childCount) return 0;

        return i + 1;
    }

    public Vector3 GetPosition(int i)
    {
        return transform.GetChild(i).position;
    }
}
