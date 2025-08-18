using Project.Scripts.Core.Ball;
using Project.Scripts.Core.Factories;
using Project.Scripts.Core.Point;
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
        
        [SerializeField] private PointsView _pointsView;
        
        [Space]
        
        [SerializeField] private BallFactory _ballFactory;
        
        private void Start()
        {
            Instantiate(_ballFactory);
                        
            var pointsEnemyViewInstance = Instantiate(_pointsView, _enemyPoint.position, Quaternion.identity);
            
            var pointsPlayerViewInstance = Instantiate(_pointsView, _playerPoint.position, Quaternion.identity);
            
            for (var i = 0; i < _pointsView.Points.Count; i++)
            {
                _ballFactory.Create(_enemyBall, pointsEnemyViewInstance.Points[i].position);
                
                _ballFactory.Create(_playerBall, pointsPlayerViewInstance.Points[i].position);
            }
        }
    }   
}