using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharizardController : MonoBehaviour
{	
	public Animator animator_beattacked;
    public Animator animator;
    public GameObject attack;
    public GameObject be_attacked;
    // public GameObject NoTouchAttack;
	public string m_parametersName = "charizard_states";
    public bool isAttack=false;
    public bool isMove=false;
    // Start is called before the first frame update
    void Start()
    {   
        attack=GameObject.Find("Charizard");
        animator=attack.GetComponent<Animator>();
        be_attacked=GameObject.Find("Blastoise");
        // NoTouchAttack=GameObject.Find("FireRay");
        animator_beattacked=be_attacked.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void Updateattack()
    {   
        animator.SetTrigger("isAttack");
        // animator_beattacked.SetTrigger("beAttacked");
        Debug.Log("isattack True");
        

    }
    public void UpdateMovingandAttack()
    {   
        Debug.Log("UpdateMovingandAttack");
        // animator.SetTrigger("isMoving");
        FindObjectOfType<CharizardMovement>().UpdateMovingState();
    }

    public void UpdateNoTouchattack()
    {   
        animator.SetTrigger("isNoTouchAttack");
        // FindObjectOfType<SpawnManager>().UpdateFireAttack();
        // NoTouchAttack.SetActive(true);
        // animator_beattacked.SetTrigger("beAttacked");
        Debug.Log("isNoTouchattack True");
        

    }
}
