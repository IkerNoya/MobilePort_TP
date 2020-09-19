using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float speed = 5;
    Vector3 movement;
    private void Start()
    {

    }
    private void Update()
    {
        movement = new Vector3(InputManager.Instance.GetAxis("Horizontal"), 0, InputManager.Instance.GetAxis("Vertical")) * speed * Time.deltaTime;
        transform.position += movement;
    }
}
