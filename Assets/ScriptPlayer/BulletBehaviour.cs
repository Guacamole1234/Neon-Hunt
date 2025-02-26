using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [Header("Configuraci�n del Proyectil")]
    public float velocidad = 20f;
    public float tiempoVida = 2f;
    public float radioDeteccion = 20f;
    public float fuerzaSeguimiento = 40f;

    [Header("Configuraci�n de Enemigos")]
    public string etiquetaEnemigo = "Enemy";
    public LayerMask capaEnemigos;

    private Transform objetivo;
    private float contadorTiempo;

    private void Awake()
    {
        // Configura la capa "Enemy" (aseg�rate de que la capa exista en el Editor)
        capaEnemigos = LayerMask.GetMask("Enemy");
    }

    private void OnEnable()
    {
        contadorTiempo = 0f;
        objetivo = null;
    }

    private void Update()
    {
        // Actualiza el temporizador y comprueba si se super� el tiempo de vida
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= tiempoVida)
        {
            RetornarAlPool();
            return;
        }

        // Si a�n no se ha asignado un objetivo, se busca uno
        if (objetivo == null)
        {
            DetectarObjetivo();
            Debug.Log("Buscando objetivo...");
        }

        // Mueve el proyectil: teledirige si hay objetivo o sigue una trayectoria predeterminada
        if (objetivo != null)
        {
            SeguirObjetivo();
            Debug.Log("Objetivo asignado: " + objetivo.name);
        }
        else
        {
            MovimientoLineal();
            Debug.Log("No se encontr� objetivo, moviendo en l�nea recta.");
        }
    }

    // Calcula la direcci�n hacia el objetivo y realiza una interpolaci�n para suavizar el giro
    private void SeguirObjetivo()
    {
        Vector3 direccionDeseada = (objetivo.position - transform.position).normalized;
        Vector3 direccionSuavizada = Vector3.Lerp(transform.forward, direccionDeseada, fuerzaSeguimiento * Time.deltaTime).normalized;
        transform.forward = direccionSuavizada;
        transform.position += direccionSuavizada * velocidad * Time.deltaTime;
    }

    // Movimiento predeterminado cuando no se detecta ning�n objetivo
    private void MovimientoLineal()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime, Space.Self);
    }

    // Utiliza un raycast en la direcci�n del proyectil para buscar enemigos dentro del radio de detecci�n
    private void DetectarObjetivo()
    {
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit[] impactos = Physics.RaycastAll(rayo, radioDeteccion, capaEnemigos);

        float mejorDistancia = Mathf.Infinity;
        Transform mejorObjetivo = null;
        Vector2 centroPantalla = new Vector2(Screen.width / 2f, Screen.height / 2f);

        foreach (RaycastHit impacto in impactos)
        {
            if (impacto.collider.CompareTag(etiquetaEnemigo))
            {
                Vector3 posPantalla = Camera.main.WorldToScreenPoint(impacto.collider.transform.position);
                float distanciaCentro = Vector2.Distance(new Vector2(posPantalla.x, posPantalla.y), centroPantalla);
                if (distanciaCentro < mejorDistancia)
                {
                    mejorDistancia = distanciaCentro;
                    mejorObjetivo = impacto.collider.transform;
                }
            }
        }

        objetivo = mejorObjetivo;
        if (objetivo != null)
        {
            Debug.Log("Objetivo detectado: " + objetivo.name);
        }
        else
        {
            Debug.Log("No se detect� ning�n objetivo mediante raycast.");
        }
    }

    // Retorna el proyectil al pool de objetos
    private void RetornarAlPool()
    {
        GenericPool2.Instance.ReturnBullet(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy")) // Verifica si el objeto que choca es una Enemigo
        {

            Destroy(other.gameObject);



        }



    }








}