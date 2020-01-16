using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject camera;
    public GameObject player;
    public List<Collectible> collectibles;

    public Text gameOverText;
    public Button restartButton;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);

        InitGame();
        
    }

    public void InitGame()
    {
        Debug.Log("Initializing game...");
        player = GameObject.FindGameObjectWithTag("Player");

        collectibles = GetComponent<LevelParameters>().collectibles;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndLevel()
    {
        player.GetComponent<MovementController>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        camera.GetComponent<AudioSource>().Play();
    }

    public void CollectItem()
    {
        if(collectibles.Count > 0)
            collectibles.RemoveAt(0);
    }   
}
