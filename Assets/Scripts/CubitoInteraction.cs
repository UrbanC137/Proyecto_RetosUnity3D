using UnityEngine;

public class CubitoInteraction : MonoBehaviour
{
    // Cantidad de daño que el cubo infligirá al jugador
    public int damageAmount = 1;

    // Método que se llama cuando el jugador entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entró en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Obtener la referencia al script PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Infligir daño al jugador
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
