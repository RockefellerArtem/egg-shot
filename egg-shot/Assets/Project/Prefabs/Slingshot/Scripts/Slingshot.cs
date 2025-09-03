using UnityEngine;

namespace Example
{
    public class Slingshot : MonoBehaviour
    {
        #region fields

        [SerializeField] private Transform _leftOrigin;
        [SerializeField] private Transform _rightOrigin;

        [SerializeField] private Transform _leftTarget;
        [SerializeField] private Transform _rightTarget;

        [SerializeField] private LineRenderer _leftRubber;
        [SerializeField] private LineRenderer _rightRubber;

        [SerializeField, Range(1, 20)] private int _segments = 20;
        [SerializeField, Range(0, 10f)] private float _maxSag = 2.14f;
        [SerializeField, Range(0, 10f)] private float _maxDistance = 3.49f;

        #endregion

        #region unity api

        private void Update()
        {
            DrawRubber(_leftRubber, _leftOrigin.position, _leftTarget.position);
            DrawRubber(_rightRubber, _rightOrigin.position, _rightTarget.position);
        }

        #endregion

        #region private api

        private void DrawRubber(LineRenderer line, Vector3 start, Vector3 end)
        {
            var mid = (start + end) / 2f;

            var distance = Vector3.Distance(start, end);

            var sagFactor = 1f - Mathf.Clamp01(distance / _maxDistance);

            mid.y -= _maxSag * sagFactor;

            line.positionCount = _segments;

            for (var index = 0; index < _segments; ++index)
            {
                var t = index / (float)(_segments - 1);

                var point = GetQuadraticBezierPoint(t, start, mid, end);
                
                line.SetPosition(index, point);
            }
        }
        
        /// <summary>
        /// Кривая Безье второго порядка
        /// B(t) = (1 - t)^2 * P0 + 2(1 - t)t * P1 + t^2 * P2
        /// Эта формула "смешивает" три точки и даёт координату промежуточной точки резинки
        /// на позиции t. Повторяем для всех сегментов LineRenderer → получаем плавную дугу.
        /// </summary>
        /// <param name="t">Параметр от 0 до 1 (0 = начало, 1 = конец).</param>
        /// <param name="p0">Начальная точка (origin/anchor)</param>
        /// <param name="p1">Управляющая точка, задаёт изгиб (смещается вниз для провиса)</param>
        /// <param name="p2">Конечная точка (карман/target)</param>
        private static Vector3 GetQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            var oneMinusT = 1f - t;

            return oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
        }

        #endregion
    }
}