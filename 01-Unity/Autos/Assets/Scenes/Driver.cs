using System;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField]  float moveSpeed = 0.8f;
    private void Start()
    { 
        
        
        
    //transform.Rotate(0,0,45); solo se  mueve al iniciar 
    
    
}

    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 
        transform.Rotate(0,0,-steerAmount);// se muede en cada tick
        transform.Translate(0,moveAmount,0);// se muede en cada tick
    }
}
    