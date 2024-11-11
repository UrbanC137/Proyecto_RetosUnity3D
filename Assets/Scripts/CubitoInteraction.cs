using UnityEngine;

public class CubitoInteraction : MonoBehaviour
{
    // Cantidad de da�o que el cubo infligir� al jugador
    public int damageAmount = 1;

    // M�todo que se llama cuando el jugador entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entr� en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Obtener la referencia al script PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Infligir da�o al jugador
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
