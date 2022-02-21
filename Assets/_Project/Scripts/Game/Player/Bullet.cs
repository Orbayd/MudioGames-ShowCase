using System.Collections;
using System.Collections.Generic;
using MudioGames.Showcase.Events;
using MudioGames.Showcase.Helpers;
using UnityEngine;

namespace MudioGames.Showcase.GamePlay
{
    public class Bullet : MonoBehaviour
    {
        public Vector3 ShootPosition;
        public Vector3 ShootEndPosition;
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Actor>())
            {
                MessageBus.Publish<PrepareRewardEvent>(new PrepareRewardEvent(other.gameObject,CalculateScore()));
                //Debug.Log($"[INFO] Collided {other.gameObject.name}");
            }
        }

        private float CalculateScore()
        {
            var ratio = MathExtensions.InverseLerp(ShootPosition, ShootEndPosition, transform.position);
            //Debug.Log($"[INFO] Score Gain {Mathf.Clamp(100 * ratio,20,100)}");
            return Mathf.Clamp(100 * ratio,20,100); 
        }

        
    }
}