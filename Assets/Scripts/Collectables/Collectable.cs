using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Player = collision.GetComponent<PlayerMovement>();

        if (Player != null)
        {
            _collectableBehaviour.OnCollected(Player.gameObject);
            Destroy(gameObject);
        }
    }
}
