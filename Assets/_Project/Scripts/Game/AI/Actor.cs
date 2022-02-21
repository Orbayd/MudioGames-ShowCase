using System.Collections;
using System.Collections.Generic;
using MudioGames.Showcase.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace MudioGames.Showcase.GamePlay
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Actor : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent _agent;
        void Start()
        {
            _agent ??= GetComponent<NavMeshAgent>();
        }

        public void Move(Vector3 targetDestination)
        {
            _agent.SetDestination(targetDestination);
            //var randomDestination = Random.insideUnitCircle * 18;
            // GameManager.Singleton.TimerManager.Register(5, () => Move(new Vector3(randomDestination.x, this.transform.position.y, randomDestination.y)),()=>{});
        }

        public void SetSpeed(float inital , int level)
        {
            _agent.speed += inital *  Mathf.Clamp(0.1f * level, 0.1f,1);
        }
    }
}
