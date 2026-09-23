using UnityEngine;
using UnityEngine.UI;

public class DetectorObstaculoRaycast : MonoBehaviour
{
    public float alcanceDeteccao = 8f;
    public Transform pontoDeOrigem;

    public Image vinhetaPerigo;
    public float opacidadeMaxima = 0.5f;

    public Light luzDeAviso;
    public Color corAlerta = Color.red;
    public float intensidadeAlerta = 3f;

    public float velocidadePulso = 3f;

    private bool detectandoAgora = false;
    private float tempoDesdeDeteccao = 0f;

    void Update()
    {
        DetectarObstaculoAFrente();
    }

    private void DetectarObstaculoAFrente()
    {
        Vector3 origem = pontoDeOrigem != null ? pontoDeOrigem.position : transform.position;
        Vector3 direcao = Vector3.forward; // eixo Z do mundo = direção do túnel

        bool detectou = Physics.Raycast(origem, direcao, out RaycastHit acerto, alcanceDeteccao)
                         && acerto.collider.CompareTag("Obstaculo");

        AtualizarAviso(detectou);

    }

    private void AtualizarAviso(bool perigoDetectado)
    {
        float pulso;

        if (perigoDetectado)
        {
            if (!detectandoAgora)
            {
                tempoDesdeDeteccao = 0f;
            }
            detectandoAgora = true;
            tempoDesdeDeteccao += Time.deltaTime;

            // (seno + 1) / 2 → onda suave de 0 a 1, sem saltos bruscos
            pulso = (Mathf.Sin(tempoDesdeDeteccao * velocidadePulso) + 1f) / 2f;
        }
        else
        {
            pulso = 0f;
            detectandoAgora = false;
        }

        AplicarNaVinheta(pulso);
        AplicarNaLuz(pulso);
    }

    private void AplicarNaVinheta(float pulso)
    {
        if (vinhetaPerigo == null) return;

        Color cor = vinhetaPerigo.color;
        cor.a = pulso * opacidadeMaxima;
        vinhetaPerigo.color = cor;
    }

    private void AplicarNaLuz(float pulso)
    {
        if (luzDeAviso == null) return;

        luzDeAviso.color = corAlerta;
        luzDeAviso.intensity = pulso * intensidadeAlerta;
    }
}