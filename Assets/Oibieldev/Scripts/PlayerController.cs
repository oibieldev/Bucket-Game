using UnityEngine;
using UnityEngine.InputSystem; // Injeção obrigatória para o novo sistema

public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool isPressingLeft = false;
    private bool isPressingRight = false;

    [Header("Configurações de Movimento")]
    [SerializeField] private float baseSpeed = 20f;       // Velocidade inicial estável
    [SerializeField] private float maxSpeed = 50f;      // Teto para o balde não ficar infinito
    [SerializeField] private float acceleration = 25f;  // Taxa de aceleração por segundo
    
    [SerializeField] private float currentSpeed; // Controla a velocidade em tempo real

    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if(BallSpawner.Instance.activeSpawn) CheckInput();
        CheckSpeed();
        MovePlayer();

        CheckPosition(); // Checa a posição após mover para evitar jitter
    }

    private void MovePlayer()
    {
        if (isPressingLeft){ this.transform.position += new Vector3(-currentSpeed * Time.deltaTime, 0, 0);}
        if (isPressingRight){ this.transform.position += new Vector3(currentSpeed * Time.deltaTime, 0, 0); }
    }

    private void CheckInput()
    {
        // Resolução definitiva do erro do Input System usando a API moderna
        if (Keyboard.current != null)
        {
            isPressingLeft = Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed;
            isPressingRight = Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed;
        }
    }

    private void CheckSpeed()
    {
        // Se estiver pressionando, acelera de forma linear com base no tempo (Time.deltaTime)
        if (isPressingLeft || isPressingRight)
        { 
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed); // Trava no teto máximo
        }
        else
        { 
            currentSpeed = baseSpeed; // Reseta ao soltar o botão
        }
    }

    private void CheckPosition()
    {
        // Limites de tela
        float clampedX = Mathf.Clamp(this.transform.position.x, 3, 51);
        this.transform.position = new Vector3(clampedX, this.transform.position.y, this.transform.position.z);
    }
}
