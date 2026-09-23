using UnityEngine;
public class GeradorPendulos : MonoBehaviour
{
     public GameObject prefabPendulo;
    public int quantidadePendulos = 5;
    public float espacamento = 25f;
    public float distanciaInicial = 40f;
    public float alturaDoPivo = 2f;
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
           GameObject pendulo = Instantiate(prefabPendulo, posicao, Quaternion.identity, transform);
            pendulo.name = "Pendulo_" + i;
        }
    }
}