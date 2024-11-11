using UnityEngine;
using TMPro; // Asegúrate de tener TextMeshPro en tu proyecto

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Arrastra aquí el TextMeshProUGUI del contador en el Inspector
    private float elapsedTime = 0f;
    private int displayedSeconds = 0;

    void Update()
    {
        // Acumular el tiempo transcurrido
        elapsedTime += Time.deltaTime;

        // Solo actualizar cada segundo
        if ((int)elapsedTime > displayedSeconds)
        {
            displayedSeconds = (int)elapsedTime;
            UpdateTimerUI(displayedSeconds);
        }
    }

    void UpdateTimerUI(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        timerText.text = $"{minutes:D2}:{remainingSeconds:D2}";
    }
}
