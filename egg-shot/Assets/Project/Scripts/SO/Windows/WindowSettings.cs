using System.Collections.Generic;
using Project.Scripts.Meta;
using UnityEngine;

namespace Project.Scripts.SO.Windows
{
    [CreateAssetMenu(fileName = "WindowSettings", menuName = "SO/WindowSettings")]
    public class WindowSettings : ScriptableObject
    {
        public List<WindowBase> Windows => _windows;
        
        [SerializeField] private List<WindowBase> _windows;
    }
}