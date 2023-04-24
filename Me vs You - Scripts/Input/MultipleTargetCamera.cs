using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    Transform cameraPivotTransform;

    public Vector3 playerOffset;

    public Transform player;
    public float cameraSlack;
    public float cameraDistance;

    private Vector3 pivotPoint;

    float velocity;

    void Start()
    {
        pivotPoint = transform.position;
    }

    void LateUpdate()
    {
        
        //____________________________________________________________________________

        Vector3 current = pivotPoint;       // Player's Position
        Vector3 target = player.transform.position + playerOffset;
      
        // Move from current pivot Point towards player with an Offset which can be defined
        pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

        // Update that position
        transform.position = Vector3.Lerp(pivotPoint, transform.position, Time.deltaTime);

        // Look at current target and set the position of camera above the player but barely, cause its devided by 2; ALso Move torwards enemy
        if (FindObjectOfType<Player>().currentTarget != null)
            transform.LookAt((FindObjectOfType<Player>().currentTarget.position + player.position) / 2);

        // hold the Camera behind the player and multiply that with a varaible so we can adjust that in inspector
        transform.position -= (transform.forward * cameraDistance);

       // Vector3 dir = FindObjectOfType<Player>().currentTarget.position - transform.position * 10f;
       // dir.Normalize();
       // dir.y = 0;
       //
       // Quaternion targetRot = Quaternion.LookRotation(dir);
       // transform.rotation = targetRot;
       //
       // //cameraPivotTransform.position = FindObjectOfType<Player>().currentTarget.position;
       //
       // dir = FindObjectOfType<Player>().currentTarget.position - cameraPivotTransform.position;
       // dir.Normalize();
       //
       // targetRot = Quaternion.LookRotation(dir);
       // Vector3 eulerAngle = targetRot.eulerAngles;
       // eulerAngle.y = 0;
       // cameraPivotTransform.eulerAngles = eulerAngle;

    }

}