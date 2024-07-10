using Project.Scripts.Core.LogicBase;
using UnityEngine;

namespace Project.Scripts.Core.Factories
{
    public class BallFactory : MonoBehaviour
    {
        public void Create(BallBase ballBase, Vector3 position)
        {
            Instantiate(ballBase, position, Quaternion.identity);
        }
    }
}