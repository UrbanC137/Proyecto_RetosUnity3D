using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 1000;

    [Header("Audio Settings")]
    [SerializeField]
    private AudioClip shootSound; // Sonido del disparo
    [SerializeField]
    [Range(0f, 1f)]
    private float shootVolume = 0.5f; // Nivel de volumen ajustable desde el Inspector (de 0 a 1)
    private AudioSource audioSource;

    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();

        // Inicializa el AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = shootSound;
        audioSource.volume = shootVolume; // Establece el volumen del sonido
    }

    void Update()
    {
        if (_input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    void Shoot()
    {
        // Instanciar la bala
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        // Reproducir el sonido de disparo con el volumen especificado
        if (audioSource != null && shootSound != null)
        {
            audioSource.Play();
        }

        Destroy(bullet, 1); // Destruye la bala después de 1 segundo
    }
}
