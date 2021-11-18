using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 
    GetMouseButton	Returns whether the given mouse button is held down.
GetMouseButtonDown	Returns true during the frame the user pressed the given mouse button.
GetMouseButtonUp


     */


public class Marker : MonoBehaviour
{

    [Header("Settings")]

    public float yLeeWay = 200;
    public LayerMask groundMask;
    public LayerMask monsterMask;
    [Header("Refrences")]
    public Image image;
    public Camera raycastCmera;
    [Header("Variables")]
    List<RaycastHit> corners;
    public bool activeFlag;
    //In object scope for debug purposes
    Vector3 minVec;
    Vector3 maxVec;

    private void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        
        image.enabled = false;

        if (raycastCmera == null) raycastCmera = Camera.main;

        activeFlag = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }






    void sendRaycast()
    {

        Debug.Log("asdasdasdasdasd");
        //Take 4 Corners from selct box
        corners = new List<RaycastHit>();


        Ray ray;
        RaycastHit hit;
        Vector3 screenPoint;

        screenPoint = transform.position;
        ray = raycastCmera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray,out hit,float.MaxValue, groundMask.value))
        {
            corners.Add(hit);
        }


        screenPoint = transform.position + new Vector3(transform.localScale.x, 0, 0);
        ray = raycastCmera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out hit, float.MaxValue, groundMask.value))
        {
            corners.Add(hit);
        }

        screenPoint = transform.position + new Vector3(transform.localScale.x, -transform.localScale.y, 0);
        ray = raycastCmera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out hit, float.MaxValue, groundMask.value))
        {
            corners.Add(hit);
        }

        screenPoint = transform.position + new Vector3(0, -transform.localScale.y, 0);
        ray = raycastCmera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out hit, float.MaxValue, groundMask.value))
        {
            corners.Add(hit);
        }

        //Build overlap box based on select box coordinates
        

        minVec = corners[0].point;
        maxVec = corners[0].point;

        foreach (var corner in corners)
        {

            minVec.x = Mathf.Min(minVec.x, corner.point.x);
            minVec.y = Mathf.Min(minVec.y, corner.point.y);
            minVec.z = Mathf.Min(minVec.z, corner.point.z);

            maxVec.x = Mathf.Max(maxVec.x, corner.point.x);
            maxVec.y = Mathf.Max(maxVec.y, corner.point.y);
            maxVec.z = Mathf.Max(maxVec.z, corner.point.z);

        }

        minVec.y -= yLeeWay;
        maxVec.y += yLeeWay;

        var  coliders = Physics.OverlapBox((minVec + maxVec) / 2, (maxVec - minVec) / 2, Quaternion.identity, monsterMask.value);

        List<Vector3> route = new List<Vector3>();
        //Do smthing with the result
        foreach (var colider in coliders)
        {
            

            if (colider.gameObject.CompareTag("Player"))//uliczny wojownik zostal znaleziony
            {

               colider.gameObject.GetComponent<Mover>().route = route;
               colider.gameObject.GetComponent<Mover>().active = true;
            }
            else//przeciwnik do wyjasnienia za garazami
            {
                route.Add(colider.transform.position);
            }
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        if(!activeFlag)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            transform.parent.position = Input.mousePosition;
            image.enabled = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            image.enabled = false;
            sendRaycast();

        }


        Vector2 scale = Input.mousePosition - transform.parent.position;
        scale.y = -scale.y;
        transform.localScale = scale;

    }


    private void OnDrawGizmosSelected()
    {


        Gizmos.color = new Color(0.1f, 0.7f, 0.3f, 0.3f);

        Gizmos.DrawCube((minVec + maxVec) / 2, (maxVec - minVec) / 2);

    }

}
