using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("Obstaculo"))
        {
            GameManager.Instance.TomarDano();
            Debug.Log("resenhaaaa");
        }
    }
}
