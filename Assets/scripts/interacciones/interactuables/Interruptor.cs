using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InterruptorLuz : MonoBehaviour, IInterectuable
{
    [SerializeField] private Light2D luzGlobal;
    [SerializeField] private float intensidadObjetivo = 0.5f;

    // Implementación de la propiedad de la interfaz
    public string interaccion => "Presiona E para atenuar las luces";

    public void interactuar()
    {
        if (luzGlobal != null)
        {
            luzGlobal.intensity = intensidadObjetivo;
            Debug.Log("Acción realizada: " + interaccion);
        }
    }
}