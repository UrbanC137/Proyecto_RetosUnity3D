using UnityEngine;

public class BossHandDamage : MonoBehaviour
{
    // Cantidad de daño que cada mano infligirá al jugador
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Obtener la referencia al script PlayerHealth del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Infligir daño al jugador
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
