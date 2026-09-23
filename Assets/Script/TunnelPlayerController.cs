using UnityEngine;

public class TunnelPlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float raio = 3f;
    public float velocidadeGiro = 180f;
    public float velocidadeAvanço = 10f;
    public Transform centroTunel;
    private float anguloAtual = 90f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputGirar();
        AvancarTunel();
        PosicionarNoCirculo();
    }
    private void InputGirar()
    {
        float input = Input.GetAxis("Horizontal");
        anguloAtual += input * velocidadeGiro * Time.deltaTime;
    }
    private void AvancarTunel()
    {
        if (centroTunel == null) return;
        centroTunel.Translate(Vector3.forward * velocidadeAvanço * Time.deltaTime, Space.World);
    }
    private void PosicionarNoCirculo()
    {
        float rad = anguloAtual * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * raio;
        float y = Mathf.Sin(rad) * raio;

        transform.localPosition = new Vector3(x, y, 0f);
        transform.localRotation = Quaternion.Euler(0f, 0f, anguloAtual - 90f);
    }
    private void Awake()
    {
        if (centroTunel == null)
        {
            centroTunel = transform.parent;
            if (centroTunel == null)
            {
                Debug.LogError("centroTunel nao foi encontrado");
            }
        }
    }
}
