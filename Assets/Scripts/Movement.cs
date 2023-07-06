using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;

    [SerializeField]
    private float moveSpeed = 5f;

    Joystick stick;

    private void Start()
    {
        stick = FindObjectOfType<Joystick>();
        
    }

    private void Update()
    {

        float moveHorizontal = stick.Horizontal; //Input.GetAxis("Horizontal");
        float moveForward = stick.Vertical;//Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0f, 0f, moveForward);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
        transform.Rotate(0f, moveHorizontal * rotationSpeed * Time.deltaTime , 0f, Space.World);
    }
}
