using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public float energyMax = 99f;/*La energía máxima será 99, idealmente siempre múltiplo del costo de disparo. En este caso si el jugador dispara 3 veces se quedará con 0 de energía y necesitaría 33 de energía adicionales para disparar de nuevo. Mientras que si tuviera 100, al disparar las 3 veces se quedaría con 1 de energía, necesitan 32 de energía para disparar de nuevo. Esto incentiva a spamear el disparo ya que con 1 de energía disparas antes*/
    public float reloadCooldown = 10f;
    public float recoveryAmount = 3f;


    public void Start()
    {
        reloadCooldown = 10f - Time.deltaTime; 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShootAbility playerShootAbily = GetComponent<PlayerShootAbility>();
        if (energyMax <= 100f && playerShootAbily.CanShoot())
        {
            reloadCooldown = reloadCooldown - Time.deltaTime;
            if (reloadCooldown <= 0)
            {
                energyMax = energyMax + recoveryAmount * Time.deltaTime;
            }
        }
    }

    private void powerUp1 (Collision powerUp1)
    {
        energyMax = 99f;
        energyMax.ToString("");
    }
    // AL chocar contra el PowerUp#1

    private void powerUp2 (Collision powerUp2)
    {
        float temporizador = 30f - Time.deltaTime;
        if (temporizador > 0 )
        {
            energyMax = 999f;
        }
        else
        {
            energyMax = 99f;
        }

    }
    //Al chocar contra el PowerUp#2

}
