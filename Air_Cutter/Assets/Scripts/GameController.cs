using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefabs;
    [SerializeField] Player player;
    [SerializeField] TextMesh infoText;
    [SerializeField] float horizontalArea = 5f;
    [SerializeField] float spawnDuration = 5f;
    [SerializeField] float gameTimer = 30f;
    [SerializeField] float resetTimer = 7f;

    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnDuration;
    }

    // Update is called once per frame
    void Update()
    {   
        if(gameTimer > 0) {
            gameTimer -= Time.deltaTime;

            spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0f) 
        {
            spawnTimer = spawnDuration;

            for (int i = 0; i < 3; i++) {
            GameObject fruit = Instantiate (fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
            fruit.transform.position = new Vector3 (
            Random.Range(-horizontalArea, horizontalArea),
            0.5f,
            0
        );
            }


        }

            infoText.text = "Destroy the Food Supply!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;
        } else {
            infoText.text = "FINISHED!\nScore: " + player.score;

            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f) {
                SceneManager.LoadScene (SceneManager.GetActiveScene().name);
            }
        }
    }
}
