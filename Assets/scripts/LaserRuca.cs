
using UnityEngine;

public class LaserRuca : MonoBehaviour
{
    public GameObject laserPrefab;
    public float intervalo = 2f;
    public float velocidadeLaser = 8f;
    void Start()
    {
        InvokeRepeating("Atirar", 0f, intervalo);
    }

    void Atirar()
    {
        GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity
        );

        // Ângulo aleatório entre 0 e 30 graus para cima
        float angulo = Random.Range(-30f, 30f);

        // Direção para a esquerda e para cima
        Vector2 direcao = new Vector2(
            -Mathf.Cos(angulo * Mathf.Deg2Rad),
            Mathf.Sin(angulo * Mathf.Deg2Rad)
        );

        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.linearVelocity = direcao * velocidadeLaser;

        // Destrói o laser após 4 segundos
        Destroy(laser, 4f);
    }


}
