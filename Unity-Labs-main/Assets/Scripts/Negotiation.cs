using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negotiation : MonoBehaviour
{
    public bool activeFlag = false;
    // public FightUI ui;
    public GameObject witcher;
    public GameObject negotiator;
    public Camera NegotiationCamera;
    public GameObject marker;
    public GameObject canvasNegotiation;
    //public GameObject canvasFight;

    private Vector3 oldCameraPos;
    private Vector3 oldLookAtPos;


    [SerializeField]
    private float smoothingCameraTime;
    [SerializeField]
    private float cameraUp = 30f;
    private void Awake()
    {
        gameObject.SetActive(false);
        smoothingCameraTime = 2f;
    }
    void Start()
    {
        canvasNegotiation = GameObject.FindGameObjectWithTag("CanvasNegotiation");



        marker = GameObject.FindGameObjectWithTag("Marker");







    }
    private void OnEnable()
    {
        if (marker)
        {
            marker.GetComponent<Marker>().activeFlag = false;
        }
        witcher.GetComponent<Mover>().active = false;
        NegotiationCamera.GetComponent<CameraMenager>().freeRoam = false;
        Vector3 relativePos = witcher.transform.position - negotiator.transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        negotiator.transform.rotation = rotation;

        oldCameraPos = NegotiationCamera.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        NegotiationCamera.transform.LookAt(negotiator.transform);
        Vector3 newFightCameraPos = new Vector3(witcher.transform.position.x, witcher.transform.position.y + cameraUp, witcher.transform.position.z);
        newFightCameraPos -= 30 * witcher.transform.forward;
        NegotiationCamera.transform.position = Vector3.Lerp(NegotiationCamera.transform.position, newFightCameraPos, smoothingCameraTime * Time.deltaTime);
    }

    public IEnumerator endNegotiation()
    {


        yield return new WaitForSeconds(1);

        marker.GetComponent<Marker>().activeFlag = true;
        NegotiationCamera.GetComponent<CameraMenager>().freeRoam = true;
        NegotiationCamera.transform.position = oldCameraPos;
        canvasNegotiation.SetActive(false);
        gameObject.SetActive(false);
        negotiator.SetActive(false);
    }

}
