using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class touchableArea : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits= new List<ARRaycastHit>();
    [SerializeField]
    GameObject spawnablePrefab;
    Camera arCam;
    GameObject  spawnedObject;
    public string m_parametersName = "charizard_states";
    public int[] m_stateIDArray = { 0, 1, 2, 3, 4,5 ,6, 7};

    void Start()
    {   spawnedObject=null;
        arCam=GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    void Update()
    {   
        if(Input.touchCount==0)
            return;
        RaycastHit  hit;
        Ray ray =arCam.ScreenPointToRay(Input.GetTouch(0).position);
        if(m_RaycastManager.Raycast(Input.GetTouch(0).position,m_Hits))
        {
            if(Input.GetTouch(0).phase==TouchPhase.Began &&spawnedObject== null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag=="Aces")
                    {
                        spawnedObject=hit.collider.gameObject;
                        Debug.Log("hit_Aces!");
                        FindObjectOfType<CharizardController>().UpdateMovingandAttack();
                    }
                    else if(hit.collider.gameObject.tag=="CynthiaS")
                    {
                        spawnedObject=hit.collider.gameObject;
                        Debug.Log("hit!");
                        FindObjectOfType<CharizardController>().UpdateNoTouchattack();
                    }
                }
            }
            else if(Input.GetTouch(0).phase==TouchPhase.Moved && spawnedObject!=null)
            {
                spawnedObject.transform.position=m_Hits[0].pose.position;

            }
            if(Input.GetTouch(0).phase==TouchPhase.Ended)
            {
                spawnedObject=null;
            }
        }
    }
    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject=Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }

}