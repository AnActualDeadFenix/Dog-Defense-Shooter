using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torreta : MonoBehaviour
{
    [Header("UI")]
    public GameObject UITorreta;
    public Text ammoText;

    [Space(5)]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public static int totalAmmo = 10;
    int maxAmmo;

    [Header("KeyCodes")]
    public KeyCode shoot = KeyCode.Mouse0;
    public KeyCode reload = KeyCode.R;

    float xRotation;
    bool canShoot;
    
    void Start()
    {
        maxAmmo = totalAmmo;
        ammoText.text = totalAmmo.ToString();
        canShoot = true;

        SetCamera(true);
        
    }
    
    void Update()
    {
        if(CameraHolder.canMovePlayer)
        {
            //CameraStuff();
            GunStuff();

            SetCamera(true);

        }
        else
        {
            SetCamera(false);

        }

        ammoText.text = totalAmmo.ToString();
        
    }

    public void GunStuff()
    {
        // Mas
        if (totalAmmo > maxAmmo)
            totalAmmo = maxAmmo;
        // Nada
        else if (totalAmmo <= 0)
            canShoot = false;
        else
            canShoot = true;
        
        if (Input.GetKeyDown(reload)) // Reload Gun
        {
            totalAmmo = maxAmmo;

        }
        
        if (Input.GetKeyDown(shoot) && canShoot && CameraHolder.canMovePlayer)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            --totalAmmo;
            if (totalAmmo <= 0)
                canShoot = false;
            else
                canShoot = true;

        }

    }

    public void SetCamera(bool set)
    {
        // Debug.Log("canShoot = " + set);
        UITorreta.SetActive(set);
        canShoot = set;

    }

}
