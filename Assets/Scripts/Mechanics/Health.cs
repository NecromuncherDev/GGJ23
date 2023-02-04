using System;
using System.Collections;
using GGJ.Core;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        private int currentHP;
        [SerializeField]
        private FloatVariable HEALTH;

        private SpriteRenderer cachedSpriteRenderer;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
            HEALTH.SetValue((float)currentHP / maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            StartCoroutine(DamageFlicker());

            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            HEALTH.SetValue((float)currentHP / maxHP);
            if (currentHP == 0)
            {
                State.LoseLevel();
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        private void Awake()
        {
            currentHP = maxHP;
            HEALTH.SetValue((float)currentHP / maxHP);

            cachedSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        // Coroutine for damage flicker
        private IEnumerator DamageFlicker()
        {
            cachedSpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            cachedSpriteRenderer.color = Color.white;
        }
    }
}
