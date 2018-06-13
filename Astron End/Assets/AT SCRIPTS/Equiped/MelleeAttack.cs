using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleeAttack : MonoBehaviour {

    public float damage = 10f;
    public string IntState;

    bool ableToHit;
    bool hitting;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hitting && !InventoryUI.instance.inventoryEnabled)
        {
            anim.SetInteger(IntState, 1);
            Debug.Log("Clicked Mouse Button");
        }
    }

    void MelleAttack()
    {
        Debug.Log("Attack");
    }

    private void OnTriggerStay(Collider other)
    {
        if (ableToHit)
        {
            if(other.tag != "Player")
            {
                if(other.GetComponent<EnemyHealth>() != null)
                {
                    if (!hitting)
                    {
                        other.GetComponent<EnemyHealth>().TakeDamage(damage);
                        hitting = true;
                        Debug.Log("Hit: " + other.gameObject.name);
                    }
                }
            }
        }
    }

    #region Small Functions
    public void EnableBool()
    {
        ableToHit = true;
    }

    public void DisableBool()
    {
        ableToHit = false;
        hitting = false;
    }

    public void StopAttack()
    {
        anim.SetInteger(IntState, 0);
    }
    #endregion
}