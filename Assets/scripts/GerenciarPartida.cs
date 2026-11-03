using UnityEngine;

public class GerenciadorPartida : MonoBehaviour
{
    public GameObject chefe;
    public static bool la = false;

     public GameObject exodia;
    public GameObject laserExodia;
    
    void Start()
    {
        chefe.SetActive(false);
        Invoke(nameof(AparecerChefe), 20f);

        exodia.SetActive(false);
        laserExodia.SetActive(false);

        Invoke("AtivarExodia", 60f);
    }

    void AparecerChefe()
    {
        chefe.SetActive(true);
         la = true;
        
    }

      void AtivarExodia()
    {
        exodia.SetActive(true);
        laserExodia.SetActive(true);
    }

}