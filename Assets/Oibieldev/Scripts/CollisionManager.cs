using System;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Lógica para quando a bolinha colidir com o balde
            Debug.Log("Bola colidiu com o balde!");
            other.gameObject.SetActive(false);
            if(BallSpawner.Instance.activeSpawn)GameManager.Instance.addScore(); // Incrementa a pontuação
        }
    }
}
