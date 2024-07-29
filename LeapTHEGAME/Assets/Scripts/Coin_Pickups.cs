using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Pickups : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointOfCoin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(pointOfCoin);
        FindObjectOfType<AudioManager>().Play("cpickups");
        //AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
