using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement1 : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject helix;
    [SerializeField] private int rotateSpeed = 10;
    [SerializeField] private float moveSpeed = 10f;
    private float verticalInput;
    private float horizontalInput;
    private float speedInput;
    private float turbo;
    private bool won = false;
    private Vector3 cosa = new Vector3(0, 0, 0);
    private float zoffset = -10;
    private float yoffset = 2;
    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Gyro");
        speedInput = Input.GetAxis("Horizontal");
        turbo = Input.GetAxis("Turbo");
        moveSpeed += speedInput * 0.05f;
        if (moveSpeed < 5)
        {
            moveSpeed = 5;
        }
        else if (moveSpeed > 30) 
        {
            moveSpeed = 30;
        }
        if(turbo !=0)
        {
            moveSpeed = 60;
        }
        transform.Translate(0,0,moveSpeed*Time.deltaTime);
        transform.Rotate(verticalInput*Time.deltaTime * rotateSpeed,0,horizontalInput*Time.deltaTime*rotateSpeed);


        camera.transform.rotation = transform.rotation;
        camera.transform.position = transform.position + zoffset * transform.forward + yoffset * transform.up;


        if (transform.position.z >=250 && !won)
        {
            Debug.Log("You Win");
            won = true;
        }
        helix.transform.Rotate(0, 0, Time.deltaTime * moveSpeed * 100);

    }
}
