using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Some Game Loop
        if(other.tag == "Player")
        {
            GameManager.instance.EndGame();
        }
    }
}
