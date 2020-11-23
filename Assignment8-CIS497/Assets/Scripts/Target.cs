/** John Mordi
 * Assignment #8
 * Manages how the player interacts with the prefabs and 
 * how the prefabs interact with the world
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public Rigidbody targetRb;
    
    private float minSpeed = 12, maxSpeed = 16,
                    maxTorque = 10, xRange = 4,
                    ySpawnPos = -6;

    private GameManager gameManager;

    public int pntValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //add a force upwards multiplied by a randomized speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add a torque (rotational force) with randomized xyz value
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //set the position with a randomized x value
        transform.position = RandomSpawnPos();

        //set reference to gamemanager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pntValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
