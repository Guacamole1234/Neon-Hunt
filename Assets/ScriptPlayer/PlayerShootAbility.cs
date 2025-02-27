using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShootAbility : MonoBehaviour
{
    public Transform leftCannon;
    public Transform rightCannon;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
    private Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && !IsPointerOverUI())
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    public bool CanShoot ()
    {
        bool shot = true;
        EnergySystem energySystem = GetComponent<EnergySystem>();
        if (energySystem.energyMax < 30f)
        {
            shot = false;
        }
        else if (energySystem.energyMax > 30f)
        {
            shot = true;
        }
        if (shot == true) 
        {
            //Shoot;
        }
        return shot;
    }

    private void Shoot()
    {
        EnergySystem energySystem = GetComponent<EnergySystem>();
        FireBullet(leftCannon);
        FireBullet(rightCannon);
        energySystem.energyMax = energySystem.energyMax - 33f;
        
        // Instancia el efecto de disparo en los cañones
    }

    private void FireBullet(Transform cannon)
    {
        GameObject bullet = GenericPool2.Instance.GetBullet(cannon.position, cannon.rotation * Quaternion.Euler(90, 180, 0));
        BulletBehaviour bulletScript = bullet.GetComponent<BulletBehaviour>();

    }

    private bool IsPointerOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }


}

