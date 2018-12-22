using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour, IDamageable {

    private IInteractable interactionObject;
	private int playerHealth = 100;


	[SerializeField]
	private Image health;

    public AudioSource sound;
    public AudioClip gunShot;

    public RectTransform crosshair;
    private float tooltipTimer = 0.3f;
    private float enemyHudTimer = 0.2f;
    [SerializeField]
    private Text interactionDisplayText;
 //   [SerializeField]
   // private EnemyHud enemyHud;
    [Header("Weapon Info")]
    public ParticleSystem muzzleFlash;
    #region weaponInfo
    public float fireCooldown = .5f;
    public float fireRate = .5f; //time between shots
    bool canFire = false;
    public int magazineCapacity = 25;

#endregion
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        #region gunLogic
        fireCooldown -= Time.deltaTime;
        if (fireCooldown < 0)
        {
            canFire = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (canFire)
            {
                canFire = false;
                muzzleFlash.Play();
                sound.PlayOneShot(gunShot);
                Invoke("disableFlash", .1f);

                fireCooldown = fireRate;
                Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
                RaycastHit h;
                Debug.DrawRay(transform.position, ray.direction * 55, Color.red, 3f);
                if (Physics.Raycast(ray, out h, 55))
                {
                    Debug.Log("Fire gun");
                    IDamageable damageable = h.collider.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        Debug.Log("Hit" + h.collider.tag);
                        damageable.takeDamage(5);
                    }
                }
            }
        }


        #endregion


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (interactionObject != null)
            {
                interactionObject.interact(gameObject);
            }
        }



        tooltipTimer -= Time.deltaTime;
        if (tooltipTimer < 0)
        {
            interactionObject = null;
            tooltipTimer = .3f;
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);


            Debug.DrawRay(transform.position, ray.direction, Color.blue, 3f);
            if (Physics.Raycast(ray, out hit, 45))
            {
                interactionObject = hit.collider.GetComponent<IInteractable>();

                if (interactionObject != null)
                {
                    Debug.Log("Raycast Tooltip hit something" + hit.collider.gameObject);
                    interactionDisplayText.text = "[F] " + interactionObject.getObjectName();

                }
                else
                {
                    interactionDisplayText.text = "";
                }
            }
            else
            {
                interactionDisplayText.text = "";
            }
        }

        enemyHudTimer -= Time.deltaTime;
        if (enemyHudTimer < 0)
        {
            enemyHudTimer = .2f;
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
            Debug.DrawRay(transform.position, ray.direction, Color.cyan, 3f);
            if (Physics.Raycast(ray, out hit, 65))
            {
                if (hit.collider.gameObject.tag == "NPC")
                {
                    //   Debug.Log("Enemy target hit something" + hit.collider.gameObject);
               //     enemyHud.enemyName.text = hit.collider.gameObject.name;
               //     enemyHud.enemyHealth.fillAmount = (float)100 / 100;
                };
            }
            else
            {
                interactionDisplayText.text = "";
            }
        }
    

        //order button, does action on far away objects of possible. 
        orderTarget();
    }

    private void orderTarget()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
            Debug.DrawRay(transform.position, ray.direction, Color.blue, 3f);
            if (Physics.Raycast(ray, out hit, 45))
            {
                IInteractable i  = hit.collider.GetComponent<IInteractable>();

                if (i != null)
                {

                }
            }
        }
    }

    public void disableFlash() {
      //  muzzleFlash.SetActive(false);
    }

    public string getObjectName()
    {
        throw new System.NotImplementedException();
    }

    public bool takeDamage(int damage)
    {
		playerHealth -= damage;
		health.fillAmount = (float)playerHealth / 100;
		return true;
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }


}
