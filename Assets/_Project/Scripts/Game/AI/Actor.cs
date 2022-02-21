using System.Collections;
using System.Collections.Generic;
using MudioGames.Showcase.Events;
using MudioGames.Showcase.Helpers;
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
            MessageBus.Subscribe<LevelProgressed>((x)=> OnLevelProgressed(x.Value));
        }

        private void OnLevelProgressed(int level)
        {
            SetSpeed(level);
        }

        public void Move(Vector3 targetDestination)
        {
            if(_agent.hasPath)
            {
                return;
            }
            _agent.SetDestination(targetDestination);
        }

        public void SetSpeed(int level)
        {
            _agent.speed +=  Mathf.Clamp(0.1f * level, 0.1f,1);
        }
    }
}
