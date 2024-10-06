using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public GameObject obstaclesParent;
    [SerializeField] private InitialGameData gameData;

    void Update()
    {
        if (player.isDead == true)
        {
            Time.timeScale = 0f;

            if (Input.GetKeyDown(gameData.jump0))
            {
                Time.timeScale = 1f;
                //obstaclesParent.SetActive(true);
                player.isDead = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
