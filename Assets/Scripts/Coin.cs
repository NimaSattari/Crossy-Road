using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public GameObject coin;
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Manager.insance.UpdateCoinCount(coinValue);
            coin.SetActive(false);
            this.GetComponent<AudioSource>().PlayOneShot(audioClip);
            Destroy(this.gameObject,audioClip.length);
        }
    }
}
