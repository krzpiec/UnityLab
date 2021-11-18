using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenager : MonoBehaviour
{
    public bool freeRoam;
    [SerializeField]
    private float cameraSpeed;

    [SerializeField]
    private float zoomSensitivity;
    private float vertical;
    private float horizontal;
    private float scrollWheel;

    private void Awake()
    {
        cameraSpeed = 30f;
        zoomSensitivity = 300f;
        scrollWheel = 0;
        freeRoam = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    float y = Input.GetAxis("Mouse X");
        //    float x = Input.GetAxis("Mouse Y");
        //   //Debug.Log(x + ":" + y);
        //    Vector3 rotateValue = new Vector3(x, y * -1, 0);
        //    transform.eulerAngles = transform.eulerAngles - rotateValue;
        //}

        if (!freeRoam)
            return;

        transform.LookAt(transform.parent);
       

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        Vector3 newCamPos = new Vector3(
            transform.parent.position.x - horizontal, 
            transform.parent.position.y,
            transform.parent.position.z - vertical
            );

        transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, scrollWheel * zoomSensitivity * Time.deltaTime);

        transform.parent.position = Vector3.Lerp(transform.parent.position, newCamPos, cameraSpeed * Time.deltaTime);
        


    }

   

    void FixedUpdate()
    {

        
    }
}
