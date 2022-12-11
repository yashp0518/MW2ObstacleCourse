using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;
    public bool allowButtonHold;
    public Camera fpsCam;
    //public Transform attackPoint;
    RaycastHit hitInfo;
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI ammoDisplay;
    private AudioSource audiosrc;
    public AudioClip gunshotSound;
    public AudioClip reloadSound;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    //Update is called once per frame
    void Update()
    {
        ammoDisplay.text = bulletsLeft.ToString() + "/" + magazineSize.ToString();
        myInput();

    }
    private void myInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetMouseButton(0);
        }
        else
        {
            shooting = Input.GetMouseButtonDown(0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
            muzzleFlash.Play();
            audiosrc.PlayOneShot(gunshotSound, timeBetweenShots);
        }
    }

    private void Reload()
    {
        reloading = true;
        Invoke("reloadFinished", reloadTime);
        audiosrc.PlayOneShot(reloadSound, reloadTime);
    }

    private void reloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }


    void Shoot()
    {
        
        readyToShoot = false;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            
            Debug.Log(hitInfo.transform.name);
            
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            //if we actually hit something that is an "enemy"
            if (enemy != null)
            {
                //enemy health reduced by what we set damage to
                enemy.takeDamage(damage);
            }
        }
        bulletsLeft--;
        bulletsShot--;
        Invoke("resetShot", timeBetweenShooting);
        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
       
    }
    private void resetShot()
    {
        readyToShoot = true;
    }
}
