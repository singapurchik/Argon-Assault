using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }
    private void ProcessHit()
    {
        var vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(vfx, 3f);
        hitPoints--;
    }
    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(fx, 3f);
        Destroy(gameObject);
    }
}
