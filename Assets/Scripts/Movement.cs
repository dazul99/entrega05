using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject helix;
    [SerializeField] private Vector3 offset = new Vector3(5,0,0);
    [SerializeField] private int rotateSpeed = 10;
    [SerializeField] private int moveSpeed = 10;
    private float verticalInput;
    private bool won = false;
    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0,0,moveSpeed*Time.deltaTime);
        transform.Rotate(verticalInput*Time.deltaTime * rotateSpeed,0,0);
        camera.transform.position = transform.position + offset;
        if (transform.position.z >=250 && !won)
        {
            Debug.Log("You Win");
            won = true;
        }
        helix.transform.Rotate(0, 0, Time.deltaTime * moveSpeed * 100);
    }
}
