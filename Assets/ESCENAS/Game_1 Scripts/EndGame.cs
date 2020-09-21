using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static event Action<EndGame> ChangeScene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            if (ChangeScene != null)
                ChangeScene(this);
        }
        if (other.gameObject.layer == 9)
        {
            if (ChangeScene != null)
                ChangeScene(this);
        }
    }
}
