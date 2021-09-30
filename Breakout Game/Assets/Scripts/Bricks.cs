using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{

    public GameObject brickParticles;
    void OnCollisionEnter()
    {
        Instantiate(brickParticles, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}

