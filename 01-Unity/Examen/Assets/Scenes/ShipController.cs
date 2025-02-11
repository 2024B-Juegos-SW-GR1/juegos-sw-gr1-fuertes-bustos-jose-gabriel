using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float baseGravity = 1f; // Valor inicial de la gravedad
    private float currentGravity; // Gravedad actual del barco
    private int treasureCount = 0; // Número de tesoros recogidos
    private float gravityIncrement = 5f; // Incremento de gravedad por cada tesoro

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        currentGravity = baseGravity;
        _rigidbody2D.gravityScale = currentGravity;
    }

    private void Update()
    {
        // Opcional: Restringir la velocidad para evitar acumulaciones inesperadas
        if (_rigidbody2D.linearVelocity.magnitude > 10f)
        {
            _rigidbody2D.linearVelocity = _rigidbody2D.linearVelocity.normalized * 10f;
        }
    }
    

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puerto"))
        {
            Debug.Log("Barco en el puerto. Entregando tesoros...");

            if (treasureCount > 0)
            {
                // Dejar todos los tesoros
                treasureCount = 0;

                // Resetear el peso (gravedad) al valor base
                currentGravity = baseGravity;
                _rigidbody2D.gravityScale = currentGravity;

                Debug.Log("Todos los tesoros entregados. Gravedad reseteada.");
            }
            else
            {
                Debug.Log("No hay tesoros para entregar.");
            }
        }
        
        if (other.gameObject.CompareTag("Treasure"))
        {
            Debug.Log("Tesoros recogidos: " + (++treasureCount));
            
            // Aumentar el peso (gravedad) del barco
            currentGravity = baseGravity + (treasureCount * gravityIncrement);
            _rigidbody2D.gravityScale = currentGravity;

            Destroy(other.gameObject); // Destruir el tesoro
        }
    }
}
