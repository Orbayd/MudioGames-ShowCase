using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MudioGames.Showcase.GamePlay
{
    public class FollowTarget : MonoBehaviour
    {
        private Transform _target;
        private Vector2 _offset;

        void Update()
        {
            Follow();
        }

        private void Follow()
        {
            if (_target is null)
            {
                return;
            }

            transform.position = _target.position + new Vector3(0, _offset.x, _offset.y * -1);
            transform.LookAt(_target, Vector3.up);

        }

        public void SetTarget(Transform transform)
        {
            _target = transform;
        }

        public void SetOffset(Vector2 offset)
        {
            _offset = offset;
        }
    }
}
