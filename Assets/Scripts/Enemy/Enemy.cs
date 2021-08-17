using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("0 = invulnerable")]
    [SerializeField]
    private int baseHealth = 1;

    private int currentHealth;

    [SerializeField]
    private int damage = 1;
    PlayerController antoineController;
    PlayerController danielController;

    CharacterManagement characterManagement;

    [SerializeField]
    private int force = 1000;

    

    // Start is called before the first frame update
    void Start()
    {
        antoineController = GameObject.Find("Antoine").GetComponent<PlayerController>();
        danielController = GameObject.Find("Daniel").GetComponent<PlayerController>();
        characterManagement = GameObject.Find("Player").GetComponent<CharacterManagement>();
        currentHealth = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(baseHealth > 0)
        {
            if (collider.gameObject.CompareTag("Grabbed"))
            {
                currentHealth--;
                if (currentHealth <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        if(collider.gameObject.CompareTag("Player") && collider.gameObject.name.Contains("Player")) {
            if (characterManagement.isAntoine)
            {
                antoineController.Hurt(damage, force);
            } else
            {
                danielController.Hurt(damage, force);
            }
        }
    }
}
