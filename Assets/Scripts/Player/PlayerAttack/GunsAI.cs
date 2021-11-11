using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunsAI : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash;

    [Header("Animation")]
    [Space(5)]
    public Animator animations;



    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        animations = gameObject.GetComponent<Animator>();
    }

    public void Shoot()
    {
        if(readyToShoot){
            //Spread
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            //Calculate Direction with Spread
            Vector3 direction = attackPoint.transform.forward + new Vector3(x, y, 0);
        

            //RayCast
            if (Physics.Raycast(attackPoint.transform.position, direction, out rayHit, range, whatIsEnemy))
            {
                //Debug.Log(rayHit.collider.name);

                //if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            //Graphics
            //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

            bulletsLeft--;
            bulletsShot--;

            readyToShoot = false;
            Invoke("ResetShot", timeBetweenShooting);
            animations.SetBool("Shooting", true);
        }
    }
    private void ResetShot()
    {
        readyToShoot = true;
        animations.SetBool("Shooting", false);
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        animations.SetBool("Reload", true);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
        animations.SetBool("Reload", false);
    }
}