using System;
using Project.Scripts.Core.Ball;
using Project.Scripts.Core.Factories;
using UnityEngine;

namespace Scripts.App.EnterPoint
{
    public class EnterPoint : MonoBehaviour
    {
        [SerializeField] private Transform _enemyPoint;
        [SerializeField] private Transform _playerPoint;

        [Space]
        
        [SerializeField] private Ball _enemyBall;
        [SerializeField] private Ball _playerBall;

        [Space]
        
        [SerializeField] private BallFactory _ballFactory;

        private void Start()
        {
            Instantiate(_ballFactory);
            
            _ballFactory.Create(_enemyBall, _enemyPoint.position);
            _ballFactory.Create(_playerBall, _playerPoint.position);
        }
    }   
}