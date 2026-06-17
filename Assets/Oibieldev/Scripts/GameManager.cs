using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////
    // Singleton Pattern: Garantir que haja apenas uma instância do GameManager

    [Header("Singleton Pattern")]
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o GameManager entre cenas
        }
        else if(Instance != this)
        {
            Destroy(gameObject); // Garante que apenas uma instância exista
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    
    public int loses = 0, score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        if(loses >= 5 || score >= 10) BallSpawner.Instance.desactivateSpawn();
        else BallSpawner.Instance.activateSpawn(); // Ativa o spawn de bolas quando o jogador não atingiu os limites
    }

    public void addLose(){ loses++; }
    public void addScore(){ score++; }

}
