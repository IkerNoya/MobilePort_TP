using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject player1; 
    [SerializeField] GameObject player2;
    [SerializeField] Vector3 offset;
    [SerializeField] float followSpeed;
    public enum PlayerCam
    {
        player1, player2
    }
    public PlayerCam player;

    void Start()
    {
    }

    void Update()
    {
        switch(player)
        {
            case PlayerCam.player1:
                if(player1 != null)
                {
                    transform.position = Vector3.Lerp(transform.position, player1.transform.position + offset, followSpeed * Time.deltaTime);
                    transform.LookAt(player1.transform.position);
                }
                break;
            case PlayerCam.player2:
                if (player2 != null)
                {
                    transform.position = Vector3.Lerp(transform.position, player2.transform.position + offset, Time.deltaTime);
                    transform.LookAt(player2.transform.position);
                }
                break;
        }
    }
}
