using UnityEngine;

public class FadeAnelPorDistancia : MonoBehaviour
{
       public float distanciaOpacidadeTotal = 15000f;
       public float distanciaMaxima = 400f;
       public Color corDaFase = new Color(0.55f, 0.35f, 0.85f); // roxo, como no mockup
       public float velocidadeOscilacao = 10f;
       public float intensidadeInicial = 0.03f;
       public float crescimentoPorSegundo = 0.01f;
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
       
        float intensidadeAtual = Mathf.Min(intensidadeMaxima, intensidadeInicial + crescimentoPorSegundo * Time.time);

        // Onda seno vai de -1 a 1 ao longo do tempo, multiplicada pela intensidade atual.
        float oscilacao = Mathf.Sin(Time.time * velocidadeOscilacao) * intensidadeAtual;

        // Converte a cor da fase para HSV, mexe só no brilho (V), e converte de volta.
        Color.RGBToHSV(corDaFase, out float matiz, out float saturacao, out float brilho);
        brilho = Mathf.Clamp01(brilho + oscilacao);

        return Color.HSVToRGB(matiz, saturacao, brilho);
    }
}