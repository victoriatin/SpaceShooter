using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject[] hazards;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;
public ParticleSystem ps;
public float simulationSpeed; 
public AudioSource musicSource;
public AudioClip musicClipOne;
public AudioClip musicClipTwo;


public Text ScoreText;
public Text restartText;
public Text gameOverText;
public Text winText;
private bool gameOver;
private bool restart;

public int score;

void Start()
{

    ps = GetComponent<ParticleSystem>();
gameOver = false;
restart = false;
restartText.text = "";
gameOverText.text = "";
winText.text = "";
score = 0;
UpdateScore();
StartCoroutine(SpawnWaves());
}

void Update ()
{
    if (restart)
    {
        if (Input.GetKeyDown (KeyCode.Z))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    if (Input.GetKey("escape"))
     Application.Quit();

}

IEnumerator SpawnWaves()
{
yield return new WaitForSeconds(startWait);
while (true)
{
for (int i = 0; i < hazardCount; i++)
    {
        GameObject hazard = hazards [Random.Range (0, hazards.Length)];
    Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
    Quaternion spawnRotation = Quaternion.identity;
    Instantiate(hazard, spawnPosition, spawnRotation);
    yield return new WaitForSeconds(spawnWait);
    }
yield return new WaitForSeconds(waveWait);
        if (gameOver)
        {
        restartText.text = "Press 'Z' for Restart";
        restart = true;
        break;
        }
    }
}

public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
}

void UpdateScore()
{
ScoreText.text = "Points: " + score;
  if (score >= 100)
          {
            winText.text = "YOU WIN! GAME CREATED BY VICTORIA TINSLEY";
            musicSource.clip = musicClipOne;
            musicSource.Play ();
              var main = ps.main; //should this be here or in start?
        main.simulationSpeed = 0.2f; //had main.simulationSpeed = simulationSpeed; but did not work
        simulationSpeed = (Mathf.Lerp(0.2f, 1f, Time.deltaTime * 5));
            restart = true;
           }
}

 public void GameOver ()
{
    gameOverText.text = "GAME CREATED BY VICTORIA TINSLEY";
    musicSource.clip = musicClipTwo;
    musicSource.Play ();
    gameOver = true;
}
}