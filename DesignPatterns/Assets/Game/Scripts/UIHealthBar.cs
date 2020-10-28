using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class UIHealthBar : MonoBehaviour
    {
        private Image hpBar;
        private float maxHP;
        private float currentHP;

        private void Awake()
        {
            hpBar = GetComponent<Image>();
            EnemyBehaviour.SetHp += InitializeEnemy;
            EnemyBehaviour.Damage += ChangeHealth;
            
        }


        public void InitializeEnemy(float hp)
        {
            maxHP = hp;
            currentHP = hp;
        }

        public void ChangeHealth(float damage)
        {
            currentHP -= damage;
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}