using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    public Transform gunBarrel;
    List<Bullet> bulletList = new();
    public int Speed = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet bulletInstance = Instantiate(bullet, gunBarrel.transform.position, transform.rotation);
            bulletList.Add(bulletInstance);
        }
        if (bulletList.Count != 0)
        {
            UpdateBullets();
        }
    }

    void UpdateBullets()
    {
        foreach (Bullet bullet in bulletList)
        {
            var rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = bullet.transform.forward * Speed;
        }
    }


}
