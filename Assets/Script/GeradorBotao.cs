using UnityEngine;

/// <summary>
/// Gera obstáculos (botões) ao longo do túnel, na borda do círculo por
/// onde o jogador se move, cada um numa posição angular aleatória —
/// isso força o jogador a girar para desviar. Anexar num objeto vazio
/// ESTÁTICO no mundo (mesma lógica do "TunnelVisual": NÃO filho do
/// TunnelCenter, porque precisa ficar parado enquanto a câmera avança).
/// </summary>
public class GeradorObstaculos : MonoBehaviour
{
    [Header("Prefab do obstáculo")]
    [Tooltip("Precisa ter um Collider marcado como Is Trigger e a tag \"Obstaculo\"")]
    public GameObject prefabObstaculo;

    [Header("Posicionamento")]
    [Tooltip("IMPORTANTE: precisa ser igual ao \"raio\" do TunnelPlayerController, senão o obstáculo nasce fora do alcance do jogador")]
    public float raio = 3f;
    public int quantidadeObstaculos = 20;
    public float espacamento = 9f;
    public float distanciaInicial = 15f; // não colocar obstáculo logo no começo da fase

    void Start()
    {
        GerarObstaculos();
    }

    private void GerarObstaculos()
    {
        for (int i = 0; i < quantidadeObstaculos; i++)
        {
            float z = distanciaInicial + i * espacamento;

            // Ângulo aleatório na volta do círculo — decide de que "lado"
            // do túnel o obstáculo aparece, igual à trigonometria que já
            // usamos no TunnelPlayerController.
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