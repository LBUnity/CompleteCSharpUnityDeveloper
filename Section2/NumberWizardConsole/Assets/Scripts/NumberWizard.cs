using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int m_max;
    private int m_min;
    private int m_guess;
    private int m_numberOfAttempts;
    private bool m_isGameWon;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        m_min = 1;
        m_max = 1000;
        m_guess = (m_min + m_max) / 2;
        m_numberOfAttempts = 1;
        m_isGameWon = false;

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Pick a number.");
        Debug.Log("The highest number is: " + m_max);
        Debug.Log("The lowest number is: " + m_min);
        Debug.Log("Tell if your number is higher or lower than:" + m_guess);
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
        m_max++;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameWon)
        {
            //restart
            CheckRestartGame();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_min = m_guess;
                CalculateGuess();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                m_max = m_guess;
                CalculateGuess();
            }
            else if (Input.GetKeyDown(KeyCode.KeypadEnter) ||
                Input.GetKeyDown(KeyCode.Return))
            {
                //You win message
                CorrectGuess();
                Debug.Log("Would you like to play again? [Y/N]");
            }

        }
    }

    void CalculateGuess()
    {
        m_guess = (m_min + m_max) / 2;
        m_numberOfAttempts++;
        Debug.Log("Is your number Higher or Lower than: " + m_guess);
    }

    void CorrectGuess()
    {
        Debug.Log("Amazing! Your number is: " + m_guess);
        Debug.Log("I guessed it after " + m_numberOfAttempts + " of attempts!");
        m_isGameWon = true;
    }

    void CheckRestartGame()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Stop the game in the editor please...");
            Application.Quit();
        }
    }
}
