using System;
using UnityEngine;

public class Colision : MonoBehaviour

{

    private bool hasPackage; 
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float destroyDelay=0.5f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("GOLPEEEE");
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrada de Trigger ");
        if (other.tag == "Paquete" && hasPackage != true)
        {
            Debug.Log("Paquete recogido");
            hasPackage = true; 
            Destroy(other.gameObject,destroyDelay);
        }
        
        if (other.tag == "Cliente" && hasPackage==true)
        {
            Debug.Log("Paquete Entregado");
            hasPackage = false; 
            _spriteRenderer.color = Color.blue;
        }
    }
}
        