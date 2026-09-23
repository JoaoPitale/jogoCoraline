using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCenas : MonoBehaviour
{
    [SerializeField] private string nomeCenaCreditos = "Creditos";
    [SerializeField] private string nomeCenaMenu = "Menu";
    [SerializeField] private string nomeCenaJogo = "SampleScene";

    public void IrParaCreditos()
    {
        SceneManager.LoadScene(nomeCenaCreditos);
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene(nomeCenaMenu);
    }
    public void IrParaJogo()
    {
        SceneManager.LoadScene(nomeCenaJogo);
    }
    public void ReiniciarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
