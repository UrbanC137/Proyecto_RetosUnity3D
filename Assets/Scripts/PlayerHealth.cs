using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Aseg�rate de importar TMP

public class PlayerHealth : MonoBehaviour
{
    // Variable para los puntos de vida
    public int maxHealth = 3;
    private int currentHealth;

    // Referencia al TextMeshPro para mostrar la vida
    public TextMeshProUGUI healthText;

    // Start es llamado al inicio del juego
    void Start()
    {
        // Inicializamos la vida actual al m�ximo
        currentHealth = maxHealth;
        UpdateHealthUI(); // Actualizar el UI al inicio
    }

    // M�todo para disminuir la vida
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Verificamos si la vida lleg� a 0
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Asegurarse de que no sea negativo
            Die();
        }

        UpdateHealthUI(); // Actualizar el UI despu�s de recibir da�o
    }

    // M�todo para destruir al jugador
    void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject); // Destruye el objeto PlayerCapsule
    }

    // M�todo para actualizar el texto de vida en el Canvas
    void UpdateHealthUI()
    {
        healthText.text = "x" + currentHealth; // Actualiza el texto a "x" seguido de la vida actual
    }
}
