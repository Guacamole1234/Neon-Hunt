using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public int energyMax = 99;/*La energ�a m�xima ser� 99, idealmente siempre m�ltiplo del costo de disparo. En este caso si el jugador dispara 3 veces se quedar� con 0 de energ�a y necesitar�a 33 de energ�a adicionales para disparar de nuevo. Mientras que si tuviera 100, al disparar las 3 veces se quedar�a con 1 de energ�a, necesitan 32 de energ�a para disparar de nuevo. Esto incentiva a spamear el disparo ya que con 1 de energ�a disparas antes*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
