using UnityEngine;
using MudioGames.Showcase.GamePlay;
using System.Collections.Generic;
using System.Linq;

namespace MudioGames.Showcase.Services
{
    public class ResourceService : IService
    { 
        public PoolingService PoolingService { get; private set; }
        private Player _player; 
        private ResourceConfig _resourceConfig;

        public List<GameObject> _actors = new List<GameObject>();
        
        public ResourceService(ResourceConfig resourceConfig)
        {
            _resourceConfig = resourceConfig;
        }

        public void Init()
        {
            InitServices();
        }

        private void InitServices()
        {
            PoolingService = new PoolingService(_resourceConfig.MaxActorCount, _resourceConfig.AIPrefab);
            PoolingService.Init();
        }

        public void CreateActor(int level)
        {
            var randomValue = Random.insideUnitCircle;
            var positionBounds = _resourceConfig.SpawnPositionBounds;
            var pooledObject = PoolingService.Spawn(new Vector3(randomValue.x * positionBounds.x, _resourceConfig.PlayerSpawnPosition.y, randomValue.y * positionBounds.y), Vector3.zero);
            var agent = pooledObject.GetComponent<Actor>();
            agent.SetSpeed(_resourceConfig.ActorSpeed,level);
            _actors.Add(pooledObject);
        }

        public void CreateActors(int count, int level)
        {
            for (int i = 0; i < count; i++)
            {
                CreateActor(level);
            }
        }

        public void Release(GameObject gameObject)
        {
            if (gameObject is null)
            {
                return;
            }
            _actors.Remove(gameObject);
            PoolingService.Release(gameObject);
        }

        public Player GetPlayer()
        {
            if (_player is null)
            {
                var go = GameObject.Instantiate(_resourceConfig.PlayerPrefab);
                _player = go.GetComponent<Player>();
                _player.SetSpeed(_resourceConfig.PlayerSpeed);
            }

            ResetPlayer();

            return _player;
        }

        public void ResetPlayer()
        {
            if (_player is null)
            {
                return;
            }

            _player.transform.SetPositionAndRotation(_resourceConfig.PlayerSpawnPosition, Quaternion.identity);
        }

        public bool IsAllReleased()
        {
            return !_actors.Any();
        }

        internal void ReleaseAll()
        {
            foreach (var actor in _actors)
            {
                Release(actor);
            }
        }
    }
}