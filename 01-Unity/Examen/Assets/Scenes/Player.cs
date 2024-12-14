using System;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Velocidad de rotación
    [SerializeField] private float moveSpeed = 5f;       // Velocidad de movimiento

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Rotación del barco
        float rotationInput = Input.GetAxis("Vertical");
        float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MoveRotation(_rigidbody2D.rotation - rotationAmount);

        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 forward = transform.right * horizontalInput * moveSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + forward);

        // Ajustar orientación del sprite según la dirección
        if (horizontalInput != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = horizontalInput > 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }
}