using System;
using UnityEngine;

namespace Player
{
    public class Behaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("HI");
            if (col.CompareTag("Enemy"))
            {
                Debug.Log(col.gameObject.name);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("HI COL");
            if (col.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(col.gameObject.name);
            }
        }
    }
}