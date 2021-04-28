using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEsys : MonoBehaviour
{
    PlayerMovement playerMovement;

    public GameObject DisplayBox;
    public GameObject PassBox;
    public GameObject WinGameUI;
    public GameObject LoseGameUI;

    bool gameHasEnded = false;

    

    
 

    public int QTEGen; 
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    public int winScore;
    public int loseScore;

    private void Awake()
    {
        WinGameUI.SetActive(false);
        LoseGameUI.SetActive(false);
    }

    private void Update()
    {

        if(WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 4);
            CountingDown = 1;
            StartCoroutine(CountDown());

            if(QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[E]";
            }

            if(QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[R]";
            }

            if(QTEGen == 3)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[T]";
            }
        }

        if(QTEGen == 1)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetButtonDown("EKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());

                }
            }
        }

         if(QTEGen == 2)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetButtonDown("RKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());

                }
            }
        }

         if(QTEGen == 3)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetButtonDown("TKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());

                }
            }
        }

        if(winScore == 3)
        {
            WinGame();
        }
        if(loseScore == 3)
        {
            LoseGame();
        }

        
    }

    IEnumerator KeyPressing()
    {
        QTEGen = 4;

        if(CorrectKey == 1)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "PASS!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            winScore += 1;
        
        }

        if(CorrectKey == 2)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            loseScore += 1;
     
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);
        if(CountingDown == 1)
        {
            QTEGen =4;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            loseScore += 1;
        }
    }

    public void WinGame()
    {
        WinGameUI.SetActive(true);
    }
    public void LoseGame()
    {
        LoseGameUI.SetActive(true);
    }

}
