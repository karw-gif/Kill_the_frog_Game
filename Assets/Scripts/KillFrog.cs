using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;


public class KillFrog : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    GameObject SmokeEffect;
    [SerializeField]
    GameObject WaterEffect;

    public int TotalScore;
    public int MissedFrogs;

    //[SerializeField]
    //public GameOverScreen GameOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TotalScore = 0;
        MissedFrogs = 0;
    }

    // Update is called once per frame

    void Update()
    {
      
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        TotalScore = PlayerPrefs.GetInt("Score", 0);
        TotalScore++;
        PlayerPrefs.SetInt("Score", TotalScore);
        PlayerPrefs.Save();
        Debug.Log("Score: " + TotalScore.ToString());
        
        Destroy(gameObject);
        Instantiate(SmokeEffect, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lake")

        {
            MissedFrogs = PlayerPrefs.GetInt("Missed", 0);
            MissedFrogs++;
            PlayerPrefs.SetInt("Missed", MissedFrogs);
            PlayerPrefs.Save();
            Debug.Log("Missed : " + MissedFrogs.ToString());

            Destroy(gameObject);
            Instantiate(WaterEffect, transform.position, Quaternion.identity);

            if (MissedFrogs > 5)
            {
                //GameOverScreen.Setup(TotalScore, MissedFrogs);
            }

        }
    }

    /*public void GameOver()
    {
   
        //gameOverScreenObject.Setup(TotalScore, MissedFrogs);
        gameOverScreenObject.GetComponent<gameOverScreen>().Setup(TotalScore, MissedFrogs);

    } */



}
