using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //public GameEnding gameEnding;
    public Transform player;
    bool m_IsPlayerInRage;
    public GameObject canvasPerder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            canvasperdido();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRage = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsPlayerInRage)
        {
            Vector3 direction = player.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {

                    canvasperdido();


                }
            }
        }
    }



    public void canvasperdido()
    {

        canvasPerder.SetActive(true);



    }





}
