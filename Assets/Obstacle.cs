using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 10f;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(-transform.forward * Speed * Time.deltaTime, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dead");
            GameManager.instance.EndGame();
        }
    }
}
