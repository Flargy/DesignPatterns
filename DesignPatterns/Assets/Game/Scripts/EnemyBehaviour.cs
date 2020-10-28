using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public static Action<float> Damage = delegate(float i) { };
        public static Action<float> SetHp = delegate(float i) { };

        [SerializeField] private int health = 10;

        private void Awake()
        {
        }

        void Start()
        {
            SetHp(health);
        }

        public void TakeDamage(float damage)
        {
            Damage(damage);
        }
}
}