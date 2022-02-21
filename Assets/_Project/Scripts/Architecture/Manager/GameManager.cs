using MudioGames.Showcase.Events;
using MudioGames.Showcase.GamePlay;
using MudioGames.Showcase.Helpers;
using MudioGames.Showcase.Services;
using UnityEngine;

namespace MudioGames.Showcase.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Configs")]

        [SerializeField]
        private ResourceConfig _resourceConfig;

        [SerializeField]
        private GameConfig _gameConfig;

        [Header("Managers")]

        [SerializeField]
        private TimerManager _timerManager;
        public TimerManager TimerManager => _timerManager;

        private TimerManager.Timer _mainTimer;

        [SerializeField]
        private UIManager _uiManager;

        private ResourceService _resourceService;

        public static GameManager Singleton {get; private set;}

        private int _level = 1;
        private int _score;
        private int Score { get { return _score; } set { _score = value; OnScoreValueChanged(); } }

        private void Start()
        {
            if(Singleton is null)
            {
                Singleton = this;
                Init();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Init()
        {
            InitServices();
            InitManagers();
            InitCamera();
            AddEvents();
        }

        private void InitServices()
        {
            _resourceService = new ResourceService(_resourceConfig);
        }

        private void InitManagers()
        {
            _resourceService.Init();
            _uiManager.Init();
            _uiManager.Navigate(ViewName.Start);
        }

        private void InitCamera()
        {
            var follow = Camera.main.GetComponent<FollowTarget>();
            follow.SetTarget(_resourceService.GetPlayer().transform);
            follow.SetOffset(_gameConfig.CameraOffset);
        }

        private void GiveReward(GameObject gameObject, int score)
        {
            _resourceService.Release(gameObject);
            Score += score;
            _mainTimer.AddDuration(Random.Range(2,5));

            if(_resourceService.IsAllReleased())
            {
                PrepareNextLevel();
            }

        }

        private void PrepareNextLevel()
        {
            _level++;
            _resourceService.ReleaseAll();
            _resourceService.CreateActors(Mathf.Clamp(_level + 3, 1, 10), _level);
            _mainTimer.SetTimeSpeed(1 + (_level * 0.1f));

            MessageBus.Publish<LevelProgressed>(new LevelProgressed(_level));
        }

        private void GameEnd()
        {
            _uiManager.Navigate(ViewName.GameOver);
        }

        private void GameStart()
        {
            _uiManager.Navigate(ViewName.ScoreBoard);
            Score = 0;
            _level = 0;
            _resourceService.ResetPlayer();
            _resourceService.CreateActors(4,_level);
            MessageBus.Publish<LevelProgressed>(new LevelProgressed(_level));

           _mainTimer = _timerManager.Register(60, () => GameEnd() , () => { OnTimeTick();});
        }

        private void OnScoreValueChanged()
        {
            MessageBus.Publish<GiveRewardEvent>(new GiveRewardEvent(Score));
        }

        private void OnTimeTick()
        {
            MessageBus.Publish<TimeLeftEvent>(new TimeLeftEvent((int)_mainTimer.Duration));
        }

        private void AddEvents()
        {
            MessageBus.Subscribe<GameStartEvent>((x) => GameStart());
            MessageBus.Subscribe<PrepareRewardEvent>((x) => GiveReward(x.Actor, (int)x.Score));
        }

        private void RemoveEvents()
        {
            MessageBus.UnSubscribe<GameStartEvent>();
            MessageBus.UnSubscribe<PrepareRewardEvent>();
        }
    }
}

