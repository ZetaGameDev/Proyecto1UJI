using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteraccionesJugador : MonoBehaviour
{
    [SerializeField] private Transform puntoInteractuable;
    [SerializeField] private float radioAlcance;
    [SerializeField] private LayerMask capaInteractuable;

    private Collider2D[] _colliders = new Collider2D[1];
    [SerializeField] private int _cantidadEncontrada;

    [UnitHeaderInspectable("Config UI")]
    [SerializeField] private GameObject panelInteraccion;
    [SerializeField] private TextMeshProUGUI textoInteraccion;

    void Start()
    {
        if (panelInteraccion != null) panelInteraccion.SetActive(false);
    }

    void Update()
    {

        _cantidadEncontrada = Physics2D.OverlapCircleNonAlloc(puntoInteractuable.position, radioAlcance, _colliders, capaInteractuable);

        if (_cantidadEncontrada > 0)
        {
           
            var interactuable = _colliders[0].GetComponent<IInterectuable>();
            
            if(interactuable != null)
            {
                ActualizarUI(true, interactuable.interaccion);

                if(Input.GetKeyDown(KeyCode.E)){

                    interactuable.interactuar();
                
                }
            }
            
            
        }else
        {
            ActualizarUI(false,"");
        }
    }

    private void ActualizarUI(bool estado, string mensaje)
    {
        if(panelInteraccion != null)
        {
            panelInteraccion.SetActive(estado);
            textoInteraccion.text = mensaje;
        }
    }

    private void OnDrawGizmos() // Corregido el nombre
    {
        if (puntoInteractuable == null) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoInteractuable.position, radioAlcance);
    }
}