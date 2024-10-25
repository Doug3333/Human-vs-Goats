using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunBarrel;
    public List<GameObject> bulletList = new();
    [SerializeField] Transform bulletParent;
    public int Speed = 10;
    public float bulletIntervals = 1;
    float timer;
    bool hasInactiveBullets = false;
    GameObject inActiveBullet;
    private void Update()
    {
        timer += Time.deltaTime;

        if (bulletList != null)
        {
            foreach (GameObject bullet in bulletList)
            {
                if (!bullet.activeSelf)
                {
                    hasInactiveBullets = true;
                    inActiveBullet = bullet;
                    break;
                }
                else if (bulletList[^1] == bullet && bullet.activeSelf)
                {
                    hasInactiveBullets = false;
                    break;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (bulletIntervals <= timer && bulletList != null)
            {
                SpawnBullet();
                timer = 0;
            }
        }
        if (bulletList.Count != 0)
        {
            UpdateBullets();
        }
    }

    void SpawnBullet()
    {
        if (hasInactiveBullets)
        {
            inActiveBullet.SetActive(true);
            inActiveBullet.transform.position = gunBarrel.transform.position;
            inActiveBullet.transform.rotation = gunBarrel.transform.rotation;
        }
        else if (!hasInactiveBullets)
        {
            GameObject bulletInstance = Instantiate(bullet, gunBarrel.transform.position, transform.rotation);
            bulletInstance.transform.parent = bulletParent.transform;
            bulletList.Add(bulletInstance);
        }
    }

    void UpdateBullets()
    {
        foreach (GameObject bullet in bulletList)
        {
            var rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = bullet.transform.forward * Speed;
        }
    }


}
