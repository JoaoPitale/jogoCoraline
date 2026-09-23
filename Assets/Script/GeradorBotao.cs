using UnityEngine;
public class GeradorObstaculos : MonoBehaviour
{
    public GameObject prefabObstaculo;
    public float raio = 3f;
    public int quantidadeObstaculos = 20;
    public float espacamento = 9f;
    public float distanciaInicial = 15f;
    void Start()
    {
        GerarObstaculos();
    }

    private void GerarObstaculos()
    {
        for (int i = 0; i < quantidadeObstaculos; i++)
        {
            float z = distanciaInicial + i * espacamento;
            float anguloAleatorio = Random.Range(0f, 360f);
            float rad = anguloAleatorio * Mathf.Deg2Rad;

            float x = Mathf.Cos(rad) * raio;
            float y = Mathf.Sin(rad) * raio;
            Vector3 posicao = new Vector3(x, y, z);

            // Rotação aleatória só para variar visualmente o modelo do
            // botão — não tem relação com a posição de desvio.
            Quaternion rotacaoVisual = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            GameObject obstaculo = Instantiate(prefabObstaculo, posicao, rotacaoVisual, transform);
            obstaculo.name = "Obstaculo_" + i;
        }
    }
}