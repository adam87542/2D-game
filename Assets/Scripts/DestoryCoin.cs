using UnityEngine;
public class DestoryCoin : MonoBehaviour
{
    [SerializeField] AudioClip PickupCoinSFX;
    float Voulme = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(PickupCoinSFX , Camera.main.transform.position, Voulme);
        Destroy(gameObject);
    }
}
