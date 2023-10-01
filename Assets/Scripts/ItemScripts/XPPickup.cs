using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPickup : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        player.GetXP(Constants.XPAmount);
        Destroy(gameObject);
    }
}