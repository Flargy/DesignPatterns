using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private GameObject textPrefab;
        [SerializeField] private float floatTime = 1.0f;

        private static DamageText instance = null;
        private List<GameObject> pool = new List<GameObject>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public static void SpawnText(Vector3 location, float damage)
        {
            GameObject spawnObject = null;
            if (instance.pool.Count > 0)
            {
                spawnObject = instance.pool[0];
                instance.pool.Remove(spawnObject);
            }
            else
            {
                spawnObject = Instantiate(instance.textPrefab);
            }

            spawnObject.GetComponent<TextMeshPro>().text = damage.ToString();
            spawnObject.transform.position = location;
            spawnObject.SetActive(true);
            instance.StartCoroutine(instance.MoveText(spawnObject));
        }

        private static void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            instance.pool.Add(obj);
        }

        private IEnumerator MoveText(GameObject obj)
        {
            float timer = 0;
            while (timer < floatTime)
            {
                yield return null;
                timer += Time.deltaTime;
                obj.transform.position += Vector3.up * Time.deltaTime;
            }
            
            ReturnToPool(obj);
        }
    }
}