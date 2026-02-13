using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject Frog;

    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public TextMeshProUGUI missedFrogs;


    public int TotalScore;
    public int MissedFrogs;

        

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawningFrog());
        TotalScore = 0;
        MissedFrogs = 0;
    }
    // Update is called once per frame
    void Update()
    {
        TotalScore = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + TotalScore.ToString();

        MissedFrogs = PlayerPrefs.GetInt("Missed", 0);
        missedFrogs.text = "Missed: " + MissedFrogs.ToString();
    }

    IEnumerator spawningFrog()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            //Generate a random number between 0 & screen's height
            float posY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            //Generate a random number between 0 & screen's width
            float posX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            //The X & Y coordinate for the position
            Vector2 spawnPosition = new Vector2(posX, posY);
            //Instantiate the frog in that generated position
            Instantiate(Frog, spawnPosition, Quaternion.identity);
        }
    }
}