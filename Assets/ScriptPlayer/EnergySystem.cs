using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public int energyMax = 99;/*La energía máxima será 99, idealmente siempre múltiplo del costo de disparo. En este caso si el jugador dispara 3 veces se quedará con 0 de energía y necesitaría 33 de energía adicionales para disparar de nuevo. Mientras que si tuviera 100, al disparar las 3 veces se quedaría con 1 de energía, necesitan 32 de energía para disparar de nuevo. Esto incentiva a spamear el disparo ya que con 1 de energía disparas antes*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
