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

    public int startingRollerLife = 3;
    public int rollerLife;

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

    void FixedUpdate()
    {
        if (rollerLife <= 0)
            GameOver("Vos rollers se sont brisés");
    }

    public void InitGame()
    {
        Debug.Log("Initializing game...");
        player = GameObject.FindGameObjectWithTag("Player");

        collectibles = GetComponent<LevelParameters>().collectibles;

        rollerLife = startingRollerLife;
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

    public void GameOver(string text = "Vos rollers se sont brisés")
    {
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.enabled = false;
            //Refactoriser les classes de mouvement en créant une classe mère abstraite
            if (enemy.gameObject.GetComponent<Moto>() != null)
            {
                enemy.gameObject.GetComponent<Moto>().StopMovement();
                enemy.gameObject.GetComponent<Moto>().enabled = false;
            }

            if (enemy.gameObject.GetComponent<Drone>() != null)
            {
                enemy.gameObject.GetComponent<Drone>().StopMovement();
                enemy.gameObject.GetComponent<Drone>().enabled = false;
            }
        }

        player.GetComponent<MovementController>().StopMovement();
        player.GetComponent<MovementController>().enabled = false;

        gameOverText.gameObject.SetActive(true);
        gameOverText.text = text;
        restartButton.gameObject.SetActive(true);
        //camera.GetComponent<AudioSource>().Play();
    }

    public void CollectItem()
    {
        if(collectibles.Count > 0)
            collectibles.RemoveAt(0);
    }

    public void LoseLife(int lifeLosed = 1)
    {
        rollerLife -= lifeLosed;
    }
}
