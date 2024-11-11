using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public int scoreValue; // Puntaje para este objetivo (5 para el verde, -1 para el rojo)
    private ScoreManager scoreManager;

    void Start()
    {
        // Encontrar el ScoreManager en la escena
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisionó es el proyectil
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Agregar puntos al puntaje total
            scoreManager.AddPoints(scoreValue);

            // Destruir el proyectil después de la colisión
            Destroy(collision.gameObject);
        }
    }
}
