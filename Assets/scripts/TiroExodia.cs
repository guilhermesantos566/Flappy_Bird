using UnityEngine;
using TMPro;
public class TiroExodia : MonoBehaviour
{
    public bool fim = false;
    public TMP_Text cabou;
public GameObject felpudo;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {   
             fim = true;
            Debug.Log("O Exodia acertou o Ruca!");
            Destroy(other.gameObject);
            Destroy(gameObject, 2f);
            FindFirstObjectByType<ControlaJogadorMouseEsquerdo>()
            .CongelarFelpudo();
            cabou.text = "YOU WIN ";
        }
    }
}
