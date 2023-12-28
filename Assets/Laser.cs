using UnityEngine;

public class Laser : MonoBehaviour
{
    public float Duration;
    public float RepeatingTime;
    public float Speed = 1f;
    float t = 0f;
    bool isActive = false;
    public GameObject LaserThingy;

    private void Start()
    {
        InvokeRepeating(nameof(ShootLaser), RepeatingTime, RepeatingTime);
    }

    private void Update()
    {
        if (isActive)
        {
            t += Time.deltaTime * Speed;
        }
        if(t >= Duration)
        {
            isActive = false;
            LaserThingy.SetActive(false);
        }
    }

    public void ShootLaser()
    {
        isActive = true;
        LaserThingy.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.EndGame();
        }
    }
}
