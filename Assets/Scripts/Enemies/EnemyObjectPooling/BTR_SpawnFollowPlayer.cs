using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_SpawnFollowPlayer : MonoBehaviour
{
    [Header("What To Follow")]
    public Transform target;
    
    [Tooltip("How far the enemies spawn from the player")]
    public int offset;

    [HideInInspector]
    public int numberOfSpawn;
    private Vector3 desiredPosition;

    void FixedUpdate()
    {
        switch (numberOfSpawn)
        {
            case 0:
                desiredPosition = target.position + new Vector3(1,0,1) * offset;
                break;
            case 1:
                desiredPosition = target.position + new Vector3(-1,0,1) * offset;
                break;
            case 2:
                desiredPosition = target.position + new Vector3(1,0,-1) * offset;
                break;
            case 3:
                desiredPosition = target.position + new Vector3(1,0,0) * offset;
                break;
            case 4:
                desiredPosition = target.position + new Vector3(0,0,1) * offset;
                break;
            case 5:
                desiredPosition = target.position + new Vector3(-1,0,-1) * offset;
                break;
            case 6:
                desiredPosition = target.position + new Vector3(-1,0,0) * offset;
                break;
            case 7:
                desiredPosition = target.position + new Vector3(0,0,-1) * offset;
                break;
        }
        
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1f);
                transform.position = smoothedPosition;
    }
}
