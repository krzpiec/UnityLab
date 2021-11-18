using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject hopbit;
    public GameObject potato;
    public GameObject elf;
    public GameObject winna;
    public GameObject paluch;

    public int radius =100;

    public int elfCount=0;
    public int winnaCount = 0;
    public int paluchCount = 0;
    public int hobitCount = 0;
    public int potatoCount = 0;

    private void spawn(GameObject prefab, int count)
    {
        if (prefab == null) return;

        Vector2 pos = Random.insideUnitCircle* radius;

        float x = transform.position.x;
        float z = transform.position.z;

        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, new Vector3(x+Random.Range(-radius, radius), transform.position.y, z + Random.Range(-radius, radius)), Quaternion.identity);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        spawn(hopbit, hobitCount);
        spawn(potato, potatoCount);
        spawn(elf, elfCount);
        spawn(paluch, paluchCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
