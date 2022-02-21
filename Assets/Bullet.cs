using System.Collections;
using System.Collections.Generic;
using MudioGames.Showcase.Events;
using MudioGames.Showcase.Helpers;
using UnityEngine;

namespace MudioGames.Showcase.GamePlay
{
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Actor>())
            {
                MessageBus.Publish<PrepareRewardEvent>(new PrepareRewardEvent(other.gameObject));
                Debug.Log($"[INFO] Collided {other.gameObject.name}");
            }
        }
    }
}