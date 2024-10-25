using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Gun myGun;
    [SerializeField] float lifeTime = 3;
    private void Start()
    {
        myGun = FindAnyObjectByType<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SolidObject"))
        {
            Debug.Log("hit");
            gameObject.SetActive(false);
            return;
        }
    }

    private void Update()
    {
        StartCoroutine(DeactivateAfterSeconds(lifeTime));
    }

    
    IEnumerator DeactivateAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
    /*
    public class UpgradeItemStats
    {
        public float DamageIncrease { get; set; }
        public float ArrowSpeedIncrease { get; set; }
        public float ArrowFireDelay { get; set; }

        public UpgradeItemStats(float damageIncrease, float arrowSpeedIncrease, float arrowFireDelay)
        {
            DamageIncrease = damageIncrease;
            ArrowSpeedIncrease = arrowSpeedIncrease;
            ArrowFireDelay = arrowFireDelay;
        }
    }

    public class WeaponBow : MonoBehaviour
    {
        [SerializeField] GameObject ArrowPrefab;
        [SerializeField] public float ArrowSpeed;

        //[SerializeField] float ArrowDamage;
        [SerializeField] public float arrowFireDelay;
        public BoxCollider2D PickupTrigger;
        float ArrowTime;
        public bool pickup;
        StateMachine stateMachine;
        [SerializeField] public float DamageIncrease;

        [SerializeField] float arrowLifeTime;


        private void Start()
        {
            stateMachine = FindObjectOfType<StateMachine>();
        }

        public void UpDamage(UpgradeItemStats statsIncrease)
        {
            DamageIncrease += statsIncrease.DamageIncrease;
            ArrowSpeed += statsIncrease.ArrowSpeedIncrease;
            arrowFireDelay += (statsIncrease.ArrowFireDelay);
            arrowFireDelay = Mathf.Clamp(arrowFireDelay, 0.1f, 4f);

        }

        void Update()
        {

            //  Move to UppgradeState??
            if (pickup)
            {
                Vector3 bowPositon = transform.position;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 BowDirection = mousePos - (Vector2)transform.position;

                transform.up = BowDirection.normalized;
                // Moved to Damageble??
                if (Time.time > ArrowTime && stateMachine.IsState<PlayingState>() == true)
                {

                    ArrowTime = Time.time + arrowFireDelay;

                    Vector2 bulletDirection = mousePos - (Vector2)transform.position;

                    bulletDirection.Normalize();

                    GameObject Arrow = Instantiate(ArrowPrefab, bowPositon, Quaternion.identity);
                    Arrow.transform.up = bulletDirection.normalized;

                    StartCoroutine(DestroyArrowAfterSeconds(arrowLifeTime, Arrow));

                    if (Arrow.TryGetComponent(out ArrowHead ar))
                    {
                        Debug.Log("Fail Damage Incresses" + DamageIncrease);
                        ar.UpDamage(DamageIncrease);
                    }
                    //Debug.Log(Arrow.transform.position);
                    Arrow.GetComponent<Rigidbody2D>().velocity = Arrow.transform.up * ArrowSpeed;


                }


            }

        }
        IEnumerator DestroyArrowAfterSeconds(float seconds, GameObject theArrow)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(theArrow);

        }
    }
}
public class ArrowHead : MonoBehaviour
{
    public float damageAmount = 2;
    static StateMachine stateMachine;
    private Rigidbody2D rb;
    Vector2 oldVelocity;

    private void Start()
    {
        if (stateMachine == null)
        {
            stateMachine = FindObjectOfType<StateMachine>();
        }
        stateMachine.stateEvent += OnStateChange;

        rb = GetComponent<Rigidbody2D>();

    }


    public void OnStateChange(State currentState)
    {
        if (stateMachine.IsState<PlayingState>())
        {
            if (!rb) return;
            rb.velocity = oldVelocity;
        }
        else if (stateMachine.IsState<PauseState>())
        {
            if (!rb) return;
            oldVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out Enemy e))
            {
                e.EnemyTakeDamage(damageAmount);
                Destroy(gameObject);
            }

        }
        if (collision.CompareTag("StaticGameObject"))
        {
            Destroy(gameObject);
        }

    }

    public void UpDamage(float DFI)
    {

        damageAmount += DFI;

    }
*/
}
