using UnityEngine;

/// <summary>
/// Efeito visual dos anéis do túnel: os mais próximos da câmera ficam
/// sempre 100% opacos, e só a partir de uma certa distância começam a
/// desaparecer. A cor não muda de tom (continua sendo a cor da fase),
/// mas oscila sutilmente entre tons mais claros/escuros dela com o
/// tempo, e essa oscilação vai ficando mais forte quanto mais o jogo
/// avança.
/// Anexar diretamente no PREFAB "AnelTunel".
/// </summary>
public class FadeAnelPorDistancia : MonoBehaviour
{
    [Header("Opacidade por distância")]
    [Tooltip("Dentro dessa distância da câmera, o anel fica sempre 100% opaco")]
    public float distanciaOpacidadeTotal = 15000f;
    [Tooltip("A partir daqui (contando desde distanciaOpacidadeTotal), a opacidade some por completo")]
    public float distanciaMaxima = 400f;

    [Header("Cor da fase")]
    [Tooltip("Cor fixa escolhida para essa fase — a oscilação varia só o brilho dela, não o tom")]
    public Color corDaFase = new Color(0.55f, 0.35f, 0.85f); // roxo, como no mockup

    [Header("Oscilação de tom (fica mais forte com o tempo)")]
    [Tooltip("Velocidade da oscilação entre tons mais claros/escuros")]
    public float velocidadeOscilacao = 10f;
    [Tooltip("Intensidade da oscilação logo no início da fase")]
    public float intensidadeInicial = 0.03f;
    [Tooltip("Quanto a intensidade cresce a cada segundo de jogo")]
    public float crescimentoPorSegundo = 0.01f;
    [Tooltip("Teto para a intensidade não ficar exagerada depois de muito tempo")]
    public float intensidadeMaxima = 0.35f;

    private Renderer meuRenderer;
    private Transform camera;

    void Start()
    {
        meuRenderer = GetComponent<Renderer>();
        camera = Camera.main.transform;
    }

    void Update()
    {
        float opacidade = CalcularOpacidadePorDistancia();
        Color corFinal = CalcularCorComOscilacao();
        corFinal.a = opacidade;

        meuRenderer.material.color = corFinal;
    }

    private float CalcularOpacidadePorDistancia()
    {
        float distancia = Vector3.Distance(transform.position, camera.position);

        if (distancia <= distanciaOpacidadeTotal)
        {
            return 1f;
        }

        float distanciaAlemDoLimite = distancia - distanciaOpacidadeTotal;
        float alcanceRestante = distanciaMaxima - distanciaOpacidadeTotal;
        return Mathf.Clamp01(1f - (distanciaAlemDoLimite / alcanceRestante));
    }

    private Color CalcularCorComOscilacao()
    {
        // Intensidade cresce com o tempo de jogo, até o teto definido.
        float intensidadeAtual = Mathf.Min(intensidadeMaxima, intensidadeInicial + crescimentoPorSegundo * Time.time);

        // Onda seno vai de -1 a 1 ao longo do tempo, multiplicada pela intensidade atual.
        float oscilacao = Mathf.Sin(Time.time * velocidadeOscilacao) * intensidadeAtual;

        // Converte a cor da fase para HSV, mexe só no brilho (V), e converte de volta.
        Color.RGBToHSV(corDaFase, out float matiz, out float saturacao, out float brilho);
        brilho = Mathf.Clamp01(brilho + oscilacao);

        return Color.HSVToRGB(matiz, saturacao, brilho);
    }
}