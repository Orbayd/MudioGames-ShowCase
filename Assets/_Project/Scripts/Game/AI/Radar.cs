using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MudioGames.Showcase.GamePlay
{
    public class Radar : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {

                var randomDestination = Random.insideUnitCircle * 18;

                var actor = GetComponentInParent<Actor>();
                actor.Move(new Vector3(randomDestination.x, this.transform.position.y, randomDestination.y));
            }
        }
    }
}
