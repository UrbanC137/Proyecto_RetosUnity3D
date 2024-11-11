using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private Animator animator;
    public Transform player; // Referencia al jugador
    public float chaseRange = 10f; // Rango para iniciar la persecución
    public float attackRange = 1.5f; // Rango para activar el ataque
    public float moveSpeed = 3f; // Velocidad de movimiento del Boss
    public int health = 50; // Vida del Boss
    public string bulletTag = "Bullet"; // Tag para identificar el proyectil
    public string damageAnimation = "Standing React"; // Nombre de la animación de daño

    private bool isAttacking = false; // Bandera para controlar si el Boss está atacando
    private int collisionCounter = 0; // Contador de colisiones con proyectiles
    private bool isDead = false; // Bandera para controlar si el Boss ha muerto

    [Header("Health UI")]
    public Slider healthBarSlider; // Asigna el Slider de la barra de vida en el Inspector

    void Start()
    {
        animator = GetComponent<Animator>();

        // Inicializa la barra de vida con el valor máximo de salud
        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = health;
            healthBarSlider.value = health;
        }
    }

    void Update()
    {
        // Verificar si el Boss está muerto o si el jugador ha sido destruido
        if (isDead || player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            animator.SetBool("isRunning", true);

            if (distanceToPlayer < attackRange)
            {
                animator.SetBool("isRunning", false);
                Attack();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            isAttacking = false;
        }
    }

    private void MoveTowardsPlayer()
    {
        // Verificar si el jugador sigue existiendo antes de moverse
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;

        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Holding Idle"))
            {
                if (Random.value < 0.5f)
                {
                    animator.SetBool("isAttacking1", true);
                    animator.SetBool("isAttacking2", false);
                }
                else
                {
                    animator.SetBool("isAttacking2", true);
                    animator.SetBool("isAttacking1", false);
                }
                isAttacking = true;
            }
        }
        else
        {
            // Verificar si el jugador sigue existiendo antes de continuar el ataque
            if (player == null) return;

            if (Vector3.Distance(transform.position, player.position) > attackRange)
            {
                isAttacking = false;
                animator.SetBool("isAttacking1", false);
                animator.SetBool("isAttacking2", false);
                animator.SetBool("isRunning", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            collisionCounter++;

            if (collisionCounter >= 10)
            {
                collisionCounter = 0;
                TakeDamage(true);
            }
            else
            {
                TakeDamage(false);
            }

            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(bool playAnimation)
    {
        health--;

        if (playAnimation)
        {
            animator.SetTrigger("TakeDamage");
        }

        // Actualizar el valor de la barra de vida
        if (healthBarSlider != null)
        {
            healthBarSlider.value = health;
        }

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
    }

    // Método público para saber si el Boss está atacando
    public bool IsAttacking()
    {
        return isAttacking;
    }
}
