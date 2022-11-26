using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamageOf = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 15f;
    private float nextTimeToShoot = 0f;
    public Animator animator;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject WoodedEffect;

    

    
    private void Update()
    {
       

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
        {
           
            nextTimeToShoot = Time.time + 1f/fireCharge;
            Shoot();
        }
       
    }
   
   private void Shoot()
   {
    

    muzzleSpark.Play();
    RaycastHit hitInfo;

    if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
    {
        Debug.Log(hitInfo.transform.name);

        ObjectToHit objectToHit = hitInfo.transform.GetComponent<ObjectToHit>();

        if(objectToHit != null)
        {
            objectToHit.ObjectHitDamage(giveDamageOf);
            GameObject WoodGo = Instantiate(WoodedEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(WoodGo, 1f);
        }
    }
   }


   
}
