using TMPro;
using UnityEngine;

public class UIVidas : MonoBehaviour
{   
    [SerializeField] private Transform player;

    void Update()
    {
        float pontos = player.position.z;
        textoVidas.text = "Pontos: " + Mathf.FloorToInt(pontos);
    }
    [SerializeField] private TextMeshProUGUI textoVidas;
    private void Start()
    {
        if (GameManager.Instance != null) 
        {
            GameManager.Instance.OnVidasAlteradas += AtualizarTexto;
            AtualizarTexto(GameManager.Instance.vidasAtuais);
            Debug.Log("resenha???");
            
        }
   
    }
    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnVidasAlteradas -= AtualizarTexto;
        }
    }
    private void AtualizarTexto(int vidasAtuais)
    {
    }
}
