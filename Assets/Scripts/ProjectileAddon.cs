using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private bool targetHit;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //make sure only to stick to the first taget you hit
        if (targetHit) 
            return;
        else
            targetHit = true;

        //check if you hit an enemy
        if (collision.gameObject.GetComponent<BasicEnemy>() != null)
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

            enemy.TakeDamage(damage);

            Destroy(gameObject);

        }

        //make sure projectiles stick to surface 
        rb.isKinematic = true;

        //make sure projectiles moves with target
        transform.SetParent(collision.transform);  

    }


    /* Update is called once per frame
    void Update()
    {
        
    }*/
}
