using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform pointA; // Ponto inicial da plataforma
    public Transform pointB; // Ponto final da plataforma
    public float speed = 2f; // Velocidade da plataforma

    private Vector3 targetPosition; // Próximo ponto de destino
    private GameObject player; // Referência ao jogador que sobe na plataforma

    void Start()
    {
        // Inicia o destino como o ponto A
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Move a plataforma para o ponto de destino
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Alterna entre os pontos quando chega a um deles
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Quando o jogador entra no trigger da plataforma
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.transform.SetParent(transform); // Torna a plataforma o pai do jogador
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Quando o jogador sai do trigger da plataforma
        if (other.CompareTag("Player"))
        {
            player.transform.SetParent(null); // Remove o jogador da plataforma
            player = null;
        }
    }
}
