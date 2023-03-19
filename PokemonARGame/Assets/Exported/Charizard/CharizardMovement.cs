using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharizardMovement : MonoBehaviour
{
    public Transform start;
    public Transform middle;
    public Transform target; // the target transform the object should move towards
    public float speed = 0.00002f; // how fast the object should move
    public Animator animator;
    public Animator animator_beattacked;
    public GameObject be_attacked;
    public GameObject attack;
    private bool isMovingUp = false;
    private bool isMovingdown = false;
    private bool isMovingback = false;
    private float startTime;
    private float middleTime;
    private float backTime;
    // Total distance between the markers.
    private float journeyLength;
    private float journeyLengthDown;
    private float journeyLengthBack;

    void Start()
    {
        // Start moving towards the target
        isMovingUp = false;
        be_attacked=GameObject.Find("Blastoise");
        attack=GameObject.Find("Charizard");
        animator=attack.GetComponent<Animator>();
        animator_beattacked=be_attacked.GetComponent<Animator>();
        journeyLength = Vector3.Distance(start.position, middle.position);
        journeyLengthDown = Vector3.Distance(middle.position, target.position);
        journeyLengthBack = Vector3.Distance(target.position, start.position);
    }

    void Update()
    {
        if(isMovingUp)
        {
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;
        // Set our position as a fraction of the distance between the markers.
        attack.transform.position = Vector3.Lerp(start.position, middle.position, fractionOfJourney);
        Debug.Log(fractionOfJourney);
            if(fractionOfJourney>0.95)
            {
            isMovingUp=false;
            isMovingdown = true;
            middleTime=Time.time;
                // animator.SetTrigger("isAttack");
                // animator_beattacked.SetTrigger("beAttacked");
                // Debug.Log("isattack True");
            
            }
        }

        else if(isMovingdown)
        {
        float distCovered = (Time.time - middleTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLengthDown;
        // Set our position as a fraction of the distance between the markers.
        attack.transform.position = Vector3.Lerp(middle.position,target.position, fractionOfJourney);
        Debug.Log(fractionOfJourney);
            if(fractionOfJourney>0.70)
            {
                isMovingdown=false;
                animator.SetTrigger("isAttack");
                animator_beattacked.SetTrigger("beAttacked");
                Debug.Log("isattack True");
            
            }
        }

        else if(isMovingback)
        {
        float distCovered = (Time.time - backTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLengthBack;
        // Set our position as a fraction of the distance between the markers.
        attack.transform.position = Vector3.Lerp(target.position,start.position, fractionOfJourney);
        Debug.Log(fractionOfJourney);
            if(fractionOfJourney>0.95)
            {   
                isMovingback=false;
                Debug.Log("Come back");
            
            }
        }
    }
    public void UpdateMovingState()
    {   
        isMovingUp=true;
        startTime = Time.time;
        animator.SetTrigger("isMoving");
    }
        public void UpdateBackState()
    {   
         backTime=Time.time;
         isMovingback=true;
    }
}