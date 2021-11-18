using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody rigbod;
    public List<Vector2> corners;
    public bool active = false;
    public float speed;
    public float searchRadius = 10f;
    Animator animator;
    public int routeCounter = 0;
    public List<Vector3> route;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        route = new List<Vector3>
        {
            transform.position
        };
        routeCounter = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        //routeCounter = 0;
        if (routeCounter >= route.Count)
        {
            active = false;
            routeCounter = 0;
            rigbod.velocity = Vector3.zero;
        }

        if (active)
        {
            animator.SetBool("isRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, route[routeCounter], speed*Time.deltaTime);

            Vector3 relativePos = route[routeCounter] - transform.position ;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;


        }
        else
        {
            animator.SetBool("isRunning", false) ;
            rigbod.velocity = Vector3.zero;
        }
        
    }




    private void createPoints()
    {
        route = new List<Vector3>();
        route.Add(new Vector3(corners[3].x + searchRadius, transform.position.y, corners[3].y));
        route.Add(new Vector3(corners[0].x + searchRadius, transform.position.y, corners[0].y));
        route.Add(new Vector3(corners[0].x + 2*searchRadius, transform.position.y, corners[0].y));
        route.Add(new Vector3(corners[3].x + 2 * searchRadius, transform.position.y, corners[3].y));
    }
}
