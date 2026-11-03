using UnityEngine;

public class ColisaoLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo atingiu o laser: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("O laser acertou o Felpudo!");

            ControlaJogadorMouseEsquerdo jogador =
                other.GetComponent<ControlaJogadorMouseEsquerdo>();

            if (jogador != null)
            {
                jogador.life--;

                jogador.AtualizarVida();

                if (jogador.life <= 0)
                {
                    jogador.Derrota();
                    ControlaJogadorMouseEsquerdo.lose = true;
                }
            }

            Destroy(gameObject);
        }
    }
}