using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public Transform playerArea;
    public Transform headPos;

    private void LateUpdate()
    {
        SetPlayerAreaPosition();
    }

    private void SetPlayerAreaPosition()
    {
        playerArea.position = transform.position + (playerArea.position - headPos.position);
        playerArea.rotation = transform.rotation;
    }
}
