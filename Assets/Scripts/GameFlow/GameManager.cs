using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject camera;
    public GameObject[] guiElements;
    public GameObject player;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    public void InitGame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        InitGame();
    }

    public void EndLevel()
    {
        player.GetComponent<MovementController>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        guiElements[0].SetActive(true);
        guiElements[1].SetActive(true);
        camera.GetComponent<AudioSource>().Play();
    }
}
