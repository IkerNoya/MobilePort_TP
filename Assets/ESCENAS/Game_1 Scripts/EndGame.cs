using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static event Action<EndGame> AddScore1;
    public static event Action<EndGame> AddScore2;
    public static event Action<EndGame> ChangeScene;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 8)
        {
            if (AddScore1 != null)
                AddScore1(this);
            if (ChangeScene != null)
                ChangeScene(this);
        }
        if (collision.collider.gameObject.layer == 9)
        {
            if (AddScore2 != null)
                AddScore2(this);
            if (ChangeScene != null)
                ChangeScene(this);
        }
    }
}
