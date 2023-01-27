using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

        public List<Enemy> EnemiesGet { get => _enemies; set => _enemies = value; }

        private void Update()
        {
            _enemies = FindObjectsOfType<Enemy>().ToList();
        }
    }
}