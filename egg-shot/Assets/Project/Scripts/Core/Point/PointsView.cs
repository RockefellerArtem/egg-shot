using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core.Point
{
    public class PointsView : MonoBehaviour
    {
        public List<Transform> Points => _points;
        
        [SerializeField] private List<Transform> _points;
    }
}