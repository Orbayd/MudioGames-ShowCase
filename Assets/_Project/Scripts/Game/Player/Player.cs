using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using MudioGames.Showcase.Events;
using MudioGames.Showcase.Helpers;
using UnityEngine;

namespace MudioGames.Showcase.GamePlay
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        private CharacterController _controller;

        [SerializeField]
        Transform _bullet;

        float vertical;
        float horizontal;

        private Dictionary<CommandType, IBehaviourCommand> _moveCommands = new Dictionary<CommandType, IBehaviourCommand>();

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _moveCommands.Add(CommandType.Move, new BehaviourCommand(() => Move()));
            _moveCommands.Add(CommandType.Shoot, new BehaviourCommand(() => Shoot()));

        }

        private void FixedUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            vertical = Input.GetAxis("Horizontal");
            horizontal = Input.GetAxis("Vertical");

            _moveCommands[CommandType.Move].Execute();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveCommands[CommandType.Shoot].Execute();
            }
        }

        private void Move()
        {
            _controller.Move(transform.forward * horizontal * _speed);
            transform.Rotate(new Vector3(0, vertical * 3, 0), Space.Self);

        }
        private Tweener _transitionTweener;
        private bool _allowShoot = true;

        private void Shoot()
        {
            if (!_allowShoot)
            {
                return;
            }
            _allowShoot = false;
            _bullet.transform.DOMove(this.transform.position + transform.forward * 4, 0.5f)
                          .SetEase(Ease.Linear)
                          .OnComplete(() =>
                          {
                              _transitionTweener = _bullet.transform.DOMove(BulletPosition(), 0.5f)
                                          .SetEase(Ease.Linear)
                                          .OnComplete(() =>
                                          {
                                              var distance = Vector3.Distance(_bullet.transform.position, BulletPosition());
                                              if (distance > 0.5f)
                                              {
                                                  StepRestart();
                                              }
                                              Debug.Log("Tween Completed");
                                              _allowShoot = true;
                                          })
                                          .SetAutoKill(false);
                          });
        }

        private void StepRestart()
        {
            Debug.Log("Tween Restarted");
            _transitionTweener.ChangeValues(_bullet.transform.position, BulletPosition(), 0.1f);
            _transitionTweener.Restart();
        }

        private Vector3 BulletPosition()
        {
            return transform.position + transform.forward * 1;
        }
    }
}
