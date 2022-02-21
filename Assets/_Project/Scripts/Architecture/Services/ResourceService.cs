using UnityEngine;
using MudioGames.Showcase.GamePlay;

namespace MudioGames.Showcase.Services
{
    public class ResourceService : IService
    { 
        public PoolingService PoolingService { get; private set; }
        private Player _player; 
        private ResourceConfig _resourceConfig;
        
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
            PoolingService = new PoolingService(_resourceConfig.PrizeCount, _resourceConfig.PrizePrefab);
            PoolingService.Init();
        }

        public void CreatePrize()
        {
            var randomValue = Random.insideUnitCircle;
            var positionBounds = _resourceConfig.SpawnPositionBounds;
            var pooledObject = PoolingService.Spawn(new Vector3(randomValue.x * positionBounds.x, _resourceConfig.PlayerSpawnPosition.y, randomValue.y * positionBounds.y), Vector3.zero);
        }

        public void CreatePrizes()
        {
            for (int i = 0; i < _resourceConfig.PrizeCount; i++)
            {
                CreatePrize();
            }
        }

        public void Release(GameObject gameObject)
        {
            if (gameObject is null)
            {
                return;
            }
            PoolingService.Release(gameObject);
        }

        public Player GetPlayer()
        {
            if (_player is null)
            {
                var go = GameObject.Instantiate(_resourceConfig.PlayerPrefab);
                _player = go.GetComponent<Player>();
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

    }
}