using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }
    public GameObject GameOverScreen;

    private void Start()
    {
        instance = this;
    }

    public void EndGame()
    {
        // Display some kind of end game screen
        GameOverScreen.SetActive(true);
    }
}
