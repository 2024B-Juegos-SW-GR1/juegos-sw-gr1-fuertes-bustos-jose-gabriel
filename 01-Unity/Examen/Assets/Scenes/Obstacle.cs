    using System;
    using UnityEngine;

    public class Obstacle : MonoBehaviour

    {

        private bool hasPackage; 
        private SpriteRenderer _spriteRenderer;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("GOLPEEEE");
        }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        
    }