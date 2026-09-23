using UnityEngine;

/// <summary>
/// Instancia cópias do prefab do pêndulo (a mão) ao longo do túnel.
/// O PREFAB em si já precisa vir pronto — com Rigidbody, Collider
/// (Is Trigger + tag "Obstaculo") e Hinge Joint configurados nele
/// (veja o passo a passo de configuração do Hinge Joint). Este script
/// só cuida de espalhar cópias prontas pelo percurso, em vez de você
/// arrastar cada uma manualmente na cena.
/// Anexar num objeto vazio ESTÁTICO no mundo — não filho do TunnelCenter.
/// </summary>
public class GeradorPendulos : MonoBehaviour
{
    [Header("Prefab do pêndulo")]
    [Tooltip("Prefab já configurado com Rigidbody + Collider + Hinge Joint")]
    public GameObject prefabPendulo;

    [Header("Posicionamento")]
    public int quantidadePendulos = 5;
    public float espacamento = 25f; // bem mais espaçado que os botões comuns
    public float distanciaInicial = 40f;
    public float alturaDoPivo = 2f; // posição Y de onde o pêndulo fica pendurado

    void Start()
    {
        GerarPendulos();
    }

    private void GerarPendulos()
    {
        for (int i = 0; i < quantidadePendulos; i++)
        {
            float z = distanciaInicial + i * espacamento;
            Vector3 posicao = new Vector3(0f, alturaDoPivo, z);

            // Cada cópia nasce com a MESMA configuração de física e Joint
            // que o prefab original tem — isso inclui o Rigidbody, o
            // Collider e o Hinge Joint já prontos.
            GameObject pendulo = Instantiate(prefabPendulo, posicao, Quaternion.identity, transform);
            pendulo.name = "Pendulo_" + i;
        }
    }
}