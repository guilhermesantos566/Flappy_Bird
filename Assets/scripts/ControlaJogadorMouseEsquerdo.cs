using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControlaJogadorMouseEsquerdo : MonoBehaviour {
  public int life=5;
  bool comecou;
  bool acabou;
  Rigidbody2D corpoJogador;
  Vector2 forcaImpulso = new Vector2(0, 200f);
   public static bool lose = false;
   public TMP_Text vidaTexto;
  void Start () { 
    corpoJogador = GetComponent<Rigidbody2D> ();
    vidaTexto.text = "Vida: " + life;
  }
  
  void Update () {
    if (ControlaJogadorMouseEsquerdo.lose)
    {
        return;
    }
    if (Input.GetButtonDown ("Fire1")) { 
    
      if (!comecou) {
        comecou = true;
        corpoJogador.isKinematic = false;
      }

      corpoJogador.linearVelocity = new Vector2 (0, 0);
      corpoJogador.AddForce(forcaImpulso);    
    }
    
    
  }

 void OnCollisionEnter2D(Collision2D collider2D)
{Debug.Log("Colidiu com: " + collider2D.gameObject.name);
    // Verifica se bateu na barreira (usando Tag)
    if (collider2D.gameObject.CompareTag("Cima"))
    {
        corpoJogador.linearVelocity = new Vector2(corpoJogador.linearVelocity.x, 0); 
    } else if (collider2D.gameObject.CompareTag("Baixo"))
    {
        Derrota();
        lose = true;
    }
}
public void Derrota()
{
    MonoBehaviour[] scripts = FindObjectsByType<MonoBehaviour>(
        FindObjectsSortMode.None
    );

    foreach (MonoBehaviour script in scripts)
    {
        if (script != this)
        {
            script.enabled = false;
        }
    }

    corpoJogador.linearVelocity = Vector2.zero;
}

private void OnTriggerEnter2D(Collider2D other)
{
    
    if (other.CompareTag("Inimigo"))
    {
        life--;
        AtualizarVida();
        if(life<=0){
             Derrota();
            lose = true;
        }
    }
}
public void CongelarFelpudo()
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();

    rb.linearVelocity = Vector2.zero;
    rb.gravityScale = 0;
    enabled = false;
}
 public void AtualizarVida()
{
    vidaTexto.text = "Vida: " + life;
}
}
