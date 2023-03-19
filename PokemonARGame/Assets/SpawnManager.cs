using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject objectToSpawn;
    public GameObject objectToSpawn_2;
    public GameObject battlefield;
    public GameObject players;
    public GameObject Fire;
    public PlacementManager placementManager;
    public GameObject placementQuad;
    public GameObject FireThrow;
    // public GameObject CharizardFire;
    public bool shouldSpawnOnce;
    private bool allowMultipleSpawn = true;

    // public Transform startPosition;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (allowMultipleSpawn)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                GameObject arObj = Instantiate(objectToSpawn, placementQuad.transform.position, placementQuad.transform.rotation);
                GameObject arObj_2 = Instantiate(objectToSpawn_2, placementQuad.transform.position, placementQuad.transform.rotation);
                GameObject field = Instantiate(battlefield, placementQuad.transform.position, placementQuad.transform.rotation);
                GameObject trainer = Instantiate(players, placementQuad.transform.position, placementQuad.transform.rotation);
                transform.position=placementQuad.transform.position;
                transform.rotation=placementQuad.transform.rotation;
                Debug.Log("startPosition");
                // CharizardFire=GameObject.Find("FireRay");
                // CharizardFire.SetActive(false);
                
                if (shouldSpawnOnce == true)
                {
                    allowMultipleSpawn = false;

                    placementQuad.transform.GetChild(0).transform.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
    public void UpdateFireAttack()
    {
        FireThrow = Instantiate(Fire, transform.position, transform.rotation);
    }

    public void UpdateCancelFireAttack()
    {
       Destroy(FireThrow);
    }
}
