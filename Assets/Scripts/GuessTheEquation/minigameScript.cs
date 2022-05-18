using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class minigameScript : MonoBehaviour
{
    public UnityEvent onComplete;

    float m;
    float c;

    // Difficulty accessor.
    bool isHard = true;

    [SerializeField] TMP_InputField xInput;
    [SerializeField] TMP_InputField mInput;
    [SerializeField] TMP_InputField cInput;
    [SerializeField] TMP_Text yValue;

    [SerializeField] private TMP_Text outputMessage;
    private int attempts = 0;

    void Start()
    {
        // Answers
        SetDifficulty(true);

        if (onComplete == null) onComplete = new UnityEvent();
    }

    public void GetX()
    {
        CalculateY(xInput.text);
    }

    public void GetValues()
    {
        attempts++;
        string result = $"Attempt {attempts}: Answer is ";

        float.TryParse(mInput.text, out float mOut);
        float.TryParse(cInput.text, out float cOut);

        if (mOut == m && cOut == c)
        {
            Debug.Log("Correct");
            result += "Correct";
            onComplete.Invoke();
        }
        else
        {
            Debug.Log("Incorrect");
            result += "Incorrect";
        }
        if (outputMessage != null) outputMessage.text = result;
    }

    public void CalculateY(string x)
    {  
        float test;

        if (float.TryParse(x, out test))
        {
            float result = m * test + c;

            yValue.text = result.ToString();
        }  
    }

    // KJ: Code never used?
    /*
    public void QuadraticCalculateY(string x, int pow  = 1)
    {  
        float test;

        if (float.TryParse(x, out test))
        {
            float result = m * Mathf.Pow(test, pow) + c;

            yValue.text = result.ToString();
        }  
    }
    */

    public void SetDifficulty(bool b)
    {
        isHard = b;

        // Update game values for difficulty.
        if (isHard)
        {
            // KJ: Random needs floats otherwise you only get ints outputs
            //     Also rounding due to it being super hard
            m = (float)System.Math.Round(Random.Range(-10f, 10f), 2);
            c = (float)System.Math.Round(Random.Range(-10f, 10f), 2);
        }
        else
        {
            m = Random.Range(-10, 10);
            c = Random.Range(-10, 10);
        }

        Debug.Log($"Guessing Game Cheats: m = {m}, c = {c}");
    }
}
