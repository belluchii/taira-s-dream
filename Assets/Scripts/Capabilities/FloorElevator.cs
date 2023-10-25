using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public Transform puntoX; // Asigna el punto X en el Inspector
    public Transform puntoY; // Asigna el punto Y en el Inspector
    public float velocidad = 2.0f; // Velocidad de movimiento
    public float delay = 2.0f; // Tiempo de espera en segundos antes de retroceder
    private bool interacting = false;
    private Vector3 objetivo;
    private float tiempoEspera = 0.0f;

    private void Start()
    {
        objetivo = puntoX.position; // Iniciar en el punto X
    }

    private void Update()
    {
        if (interacting)
        {
            // Si estamos interactuando, mueve la plataforma hacia el objetivo
            transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
        }
        else
        {
            // Si no estamos interactuando, comienza a contar el tiempo de espera
            if(tiempoEspera <= delay)
            {

            tiempoEspera += Time.deltaTime;
            }

            // Cuando el tiempo de espera alcance el valor de 'delay', cambia el objetivo a puntoX
            if (tiempoEspera >= delay)
            {
                objetivo = puntoX.position;
                transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interacting = true;
            tiempoEspera = 0; // Reinicia el contador al interactuar
            objetivo = puntoY.position; // Cambia el objetivo inmediatamente al interactuar
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interacting = false;
        }
    }
}