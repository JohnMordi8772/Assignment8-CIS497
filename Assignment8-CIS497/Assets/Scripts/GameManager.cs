/** John Mordi
 * Assignment #8
 * Manages game functions such as spawning, ui, and gameovers
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;

    private int score;

    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            //pick a random index out of the available prefabs
            int index = Random.Range(0, targets.Count);
            //spawn the prefab at the randomly selected index
            Instantiate(targets[index]);

            //testing
            //UpdateScore(5);
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
