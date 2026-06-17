using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{


        ////////////////////////////////////////////////////////////////////////////////
    // Singleton Pattern: Garantir que haja apenas uma instância do BallSpawner

    [Header("Singleton Pattern")]
    public static BallSpawner Instance { get; private set; }

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



    [SerializeField] public List<GameObject> ballPrefabs;

    [Header("Configurações de Spawn")]
    [SerializeField]public Vector3 originPoint = new Vector3(0, 40, 28);
    [SerializeField] public float spawnInterval = 1f;
    [SerializeField] private float spawnCooldown = 0f;
    [SerializeField] public bool activeSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CooldownTimer();
    }

    private void CooldownTimer()
    {

        spawnCooldown -= Time.deltaTime;
        if(spawnCooldown <= 0f)
        {
            spawnCooldown = spawnInterval; // Reseta o cooldown para o próximo spawn
            if(activeSpawn)SpawnBall();
        }
    }

    private void SpawnBall()
    {
        // get prefab
        int randomIndex = Random.Range(0, ballPrefabs.Count);
        GameObject prefab = ballPrefabs[randomIndex];

        // get position
        float randomX = Random.Range(-28f, 28f); 
        Vector3 position = new Vector3(randomX, originPoint.y, originPoint.z);

        // get rotation
        Quaternion rotation = prefab.transform.rotation;

        Instantiate(prefab, position, rotation);
    }

    internal void desactivateSpawn()
    {
        activeSpawn = false;
    }

    internal void activateSpawn()
    {
        activeSpawn = true;
    }
}
