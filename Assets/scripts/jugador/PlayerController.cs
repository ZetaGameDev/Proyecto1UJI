using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
        private Vector2 movimiento;
        public float velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = new Vector2(Input.GetAxisRaw("Horizontal")*velocidad,rb.linearVelocity.y);
        rb.linearVelocity = movimiento;
    }
}
