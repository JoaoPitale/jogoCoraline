using UnityEngine;
public class GeradorTunel : MonoBehaviour
{
    public GameObject prefabAnel;
    public int quantidadeAneis = 60;
    public float espacamento = 3f;
    public float rotacaoIncrementalPorAnel = 8f;

    void Start()
    {
        GerarTunel();
    }

    private void GerarTunel()
    {
        for (int i = 0; i < quantidadeAneis; i++)
        {
            Vector3 posicao = new Vector3(0f, 0f, i * espacamento);

            // Gira cada anel um pouco em relação ao anterior, para não parecer
            // uma pilha de fotocópias idênticas — dá uma sensação mais orgânica.
            Quaternion rotacao = Quaternion.Euler(0f, 0f, i * rotacaoIncrementalPorAnel);

            GameObject anel = Instantiate(prefabAnel, posicao, rotacao, transform);
            anel.name = "Anel_" + i;
        }
    }
}