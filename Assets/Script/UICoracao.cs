using UnityEngine;
using UnityEngine.UI;

public class UICoracao : MonoBehaviour
{
    [SerializeField] private Image[] coracoes;
    [SerializeField] private Sprite spriteCheio;
    [SerializeField] private Sprite spriteVazio;
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnVidasAlteradas += AtualizarCoracoes;
            AtualizarCoracoes(GameManager.Instance.vidasAtuais);
            Debug.Log("resenha???");

        }

    }
    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnVidasAlteradas -= AtualizarCoracoes;
        }
    }
    private void AtualizarCoracoes(int vidasAtuais)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].sprite = i < vidasAtuais ? spriteCheio : spriteVazio;
        }
    }
}
