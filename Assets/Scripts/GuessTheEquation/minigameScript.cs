using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class minigameScript : MonoBehaviour
{
    float m;
    float c;

    // Difficulty accessor.
    bool isHard;

    [SerializeField] TMP_InputField xInput;
    [SerializeField] TMP_InputField mInput;
    [SerializeField] TMP_InputField cInput;
    [SerializeField] TMP_Text yValue;

    // Start is called before the first frame update
    void Start()
    {
        // Answers
        m = Random.Range(-10, 10);
        c = Random.Range(-10, 10);

        Debug.Log(m.ToString());
        Debug.Log(c.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetX()
    {
        CalculateY(xInput.text);
    }

    public void GetValues()
    {

        if (float.Parse((mInput.text)) == m && float.Parse(cInput.text) == c)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Incorrect");
        }
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

    
    public void QuadraticCalculateY(string x, int pow  = 1)
    {  
        float test;

        if (float.TryParse(x, out test))
        {
            float result = m * Mathf.Pow(test, pow) + c;

            yValue.text = result.ToString();
        }  
    }

    public void SetDifficulty(bool b)
    {
        isHard = b;

        //Update game values for difficulty.
        if (isHard)
        {
            m = Random.Range(-10, 10);
            c = Random.Range(-10, 10);
        }
        else
        {
            m = (int)Random.Range(-10, 10);
            c = (int)Random.Range(-10, 10);
        }
    }
}
