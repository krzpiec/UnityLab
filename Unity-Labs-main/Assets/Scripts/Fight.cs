using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{



    public bool activeFlag = false;
   // public FightUI ui;
    public GameObject witcher;
    public GameObject enemy;
    public Camera fightCamera;
    public GameObject marker;
    public GameObject canvasFight;

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
        //canvasFight = GameObject.FindGameObjectWithTag("CanvasFight");
       
            canvasFight.SetActive(true);
       
        marker = GameObject.FindGameObjectWithTag("Marker");
      


        
       
        

    }
    private void OnEnable()
    {
        if (marker)
        {
            marker.GetComponent<Marker>().activeFlag = false;
        }
        witcher.GetComponent<Mover>().active = false;
        fightCamera.GetComponent<CameraMenager>().freeRoam = false;
        Vector3 relativePos = witcher.transform.position - enemy.transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        enemy.transform.rotation = rotation;

        oldCameraPos = fightCamera.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        fightCamera.transform.LookAt(enemy.transform);
        Vector3 newFightCameraPos = new Vector3(witcher.transform.position.x, witcher.transform.position.y + cameraUp, witcher.transform.position.z);
        newFightCameraPos -= 30 * witcher.transform.forward;
        fightCamera.transform.position = Vector3.Lerp(fightCamera.transform.position, newFightCameraPos, smoothingCameraTime * Time.deltaTime);
    }

    public IEnumerator endFight()
    {
        

        yield return new WaitForSeconds(2);
        
        marker.GetComponent<Marker>().activeFlag = true;
        fightCamera.GetComponent<CameraMenager>().freeRoam = true;
        fightCamera.transform.position = oldCameraPos;
        canvasFight.SetActive(false);
        gameObject.SetActive(false);
        enemy.SetActive(false);
    }
   

}
