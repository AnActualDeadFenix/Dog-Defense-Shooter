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
    public float bulletSpeed = 10f;
    public static int totalAmmo = 20;
    int maxAmmo;

    [Header("KeyCodes")]
    public KeyCode shoot = KeyCode.Mouse0;

    float xRotation;
    bool canShoot;
    
    void Start()
    {
        maxAmmo = totalAmmo;
        ammoText.text = totalAmmo.ToString();

        SetCamera(true);
        
    }
    
    void Update()
    {
        if(!CameraHolder.canMovePlayer)
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

    /*void CameraStuff()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotation camera and player && move Audio Listener
        if (!MoveCamera.cameraIsInside)  // Camera Outside
        {
            outside.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerTurret.Rotate(Vector3.up * mouseX);

        }

    }*/

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
        
        if (Input.GetKeyDown(shoot) && canShoot && !CameraHolder.canMovePlayer)
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
        UITorreta.SetActive(set);

        canShoot = set;

    }

}
