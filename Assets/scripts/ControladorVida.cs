using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image barraRelleno; 
    public float vidaMaxima = 100f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
        UpdateBarra();
    }

    void Update()
    {
        UpdateBarra();
    }

    public void RecibirDaño(float cantidad)
    {
        vidaActual -= cantidad;
        UpdateBarra();
    }

    void UpdateBarra()
    {
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        
        if (barraRelleno != null)
        {
            barraRelleno.fillAmount = vidaActual / vidaMaxima;
        }
    }
}