using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public event System.Action<int> OnVidasAlteradas;
    public int vidasAtuais;
    public int vidasIniciais = 3;
    public float duracaoInvencibilidade;
    public bool estaInvencível = false;
    public string nomeCreditos = "Creditos";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        vidasAtuais = vidasIniciais;
        OnVidasAlteradas?.Invoke(vidasAtuais);
    }
    public void TomarDano()
    {
        if (estaInvencível) return;
        
        vidasAtuais--;
        OnVidasAlteradas?.Invoke(vidasAtuais);
        Debug.Log("Tomou dano. Vidas: " + vidasAtuais);
        if (vidasAtuais <= 0)
        {
            RodarCreditos();
        }
        else
        {
            StartCoroutine(Invencibilidade());
        }
    }

    private IEnumerator Invencibilidade()
    {
        estaInvencível = true;
        yield return new WaitForSeconds(duracaoInvencibilidade);
        estaInvencível = false;
    }
    private void RodarCreditos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nomeCreditos);
    }
}
