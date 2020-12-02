using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 20.0f;

    public float xRange = 10.0f;
    public float zBoundary = 10.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
        ConstrainPlayerPosition();

    }

    void MovePlayer()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Fire the weapon
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(-zBoundary, transform.position.x, transform.position.y);
        }
        if (transform.position.z > zBoundary)
        {
            transform.position = new Vector3(zBoundary, transform.position.x, transform.position.y);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy2"))
            {
                Debug.Log("Player collided with an object");
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
