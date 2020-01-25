using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite lifeIconLost;

    public static GameManager instance = null;

    public GameObject camera;
    public GameObject player;
    public List<Collectible> collectibles;

    public const string LOSE_ROLLER = "roller"; 
    public const string LOSE_POLICE = "police"; 
    public const string WIN_COLLECTIBLE = "collectible";

    private bool isGameOver = false;

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
        if (rollerLife <= 0 && !isGameOver)
        {
            GameOver(LOSE_ROLLER);
        }
    }

    public void InitGame()
    {
        Debug.Log("Initializing game...");
        player = GameObject.FindGameObjectWithTag("Player");

        collectibles = new List<Collectible>(GetComponent<LevelParameters>().collectibles);

        rollerLife = startingRollerLife;
        isGameOver = false;
    }

    public void RestartLevel()
    {
        AkSoundEngine.StopAll();
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

    public void GameOver(string endState)
    {
        string endText = "";

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

        switch(endState)
        {
            case LOSE_ROLLER:
                endText = "Vos rollers se sont brisés...";
                AkSoundEngine.PostEvent("Roller_destroyed_event", GameManager.instance.gameObject);
                break;
            case LOSE_POLICE:
                endText = "Vous avez été arrêté par la police...";
                AkSoundEngine.PostEvent("Arrested_event", GameManager.instance.gameObject);
                break;
            case WIN_COLLECTIBLE:
                endText = "Vous avez récupéré les différents composants du Cutter Laser! \n Vous réussissez à vous échapper!";
                AkSoundEngine.PostEvent("", GameManager.instance.gameObject);
                break;
        }

        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = endText;
        restartButton.gameObject.SetActive(true);
        //camera.GetComponent<AudioSource>().Play();
    }

    public void CollectItem()
    {
        if (collectibles.Count > 0)
        {
            AkSoundEngine.PostEvent("Pick_collectible", this.gameObject);
            GameObject.Find("Collectible " + collectibles.Count).GetComponent<SpriteRenderer>().enabled = true;
            collectibles.RemoveAt(0);
            if(collectibles.Count <= 0)
                GameOver(WIN_COLLECTIBLE);

        }
    }

    public void LoseLife(int lifeLosed = 1)
    {
        rollerLife -= lifeLosed;
        GameObject.Find("Life " + rollerLife).GetComponent<SpriteRenderer>().sprite = lifeIconLost;
    }
}
