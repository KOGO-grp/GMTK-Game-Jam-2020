﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private bool dead = false;
    private int maxHealth = 100;
    public int health = 100;
    [SerializeField] private GameObject explosion;


    public void TakeDamage(int damage)
    {
        Camera.main.GetComponent<screenShake>().StartShake(0.4f, 0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(DamageIndicator());
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }
    public void Heal(int heart)
    {
        if (health < maxHealth)
            health += heart;
    }
    public void Die()
    {
        if (!dead)
            StartCoroutine(Death());
    }
    private IEnumerator Death()
    {
        Camera.main.GetComponent<screenShake>().StartShake(0.4f, 0.15f);
        Instantiate(explosion, transform.position, transform.rotation);
        // Debug.Log("die");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
    public int getHealth()
    {
        return health;
    }

    private IEnumerator DamageIndicator()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
