using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    public float startingHealth = 100f;
    public float currentHealth;
    public float stamina;
    float speedToGoDownBy = 2f;

    public Slider healthSlider;

    public Animation deathScreen;
    public Animation hurtFlash;

    bool isDead = false;

    bool isRagDoll = false;

    GameObject player;

    void Start()
    {
        isDead = false;

        player = gameObject;
        player.GetComponent<Rigidbody>().isKinematic = true;

        UpdateSlider();
    }

    private void Update()
    {
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }

        float targetHealth = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * speedToGoDownBy);
        healthSlider.value = targetHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            isDead = true;
            StartCoroutine(Die());
        }

        hurtFlash.Play();
        Debug.Log(transform.name + " took " + damage + " damage.");
    }

    IEnumerator Die()
    {
        if (isDead)
        {
            Debug.Log("Die");

            isRagDoll = true;
            EnableRagDoll();
            yield return new WaitForSeconds(3f);
            deathScreen.Play();
            yield return new WaitForSeconds(deathScreen.clip.length);
            loadScene.LoadScene("Facility");
        }
    }

    public void UpdateSlider()
    {
        healthSlider.value = currentHealth;
    }

    void EnableRagDoll()
    {
        if (isRagDoll)
        {
            player.GetComponent<CharacterController>().enabled = !isRagDoll;
            player.GetComponent<CharacterMovement>().enabled = !isRagDoll;
            player.GetComponentInChildren<canMouseLook>().enabled = !isRagDoll;
            player.GetComponentInChildren<NightVision>().enabled = !isRagDoll;

            player.GetComponent<Rigidbody>().isKinematic = false;
            player.transform.Rotate(Vector3.right, 1f);
            FindObjectOfType<PauseMenu>().ableToDisplayMeny = false;
        }
    }
}
