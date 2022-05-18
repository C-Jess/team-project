using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ComboKeypadLock : MonoBehaviour
{
    public UnityEvent onComplete;
    [SerializeField] private string passcode = "111";
    [SerializeField] private List<TMP_Text> digits = new List<TMP_Text>();
    private List<int> currentCode = new List<int>();

    private void Start()
    {
        if (onComplete == null) onComplete = new UnityEvent();

        for (int i = 0; i < digits.Count; i++)
        {
            currentCode.Add(0);
        }
    }

    public void ChangeDigit(int index, bool isUp = true)
    {
        if (digits.Count > index && index >= 0)
        {
            int direction = isUp ? 1 : -1;
            int x = currentCode[index] + direction;
            // Stop -1
            if (x < 0)
            {
                x = 9;
            }
            // Return to 0
            x %= 10;
            // Remove -0, just in case
            currentCode[index] = Mathf.Abs(x);
            digits[index].text = x.ToString();
            CheckCode();
        }
    }

    public void CheckCode()
    {
        string code = "";
        foreach (int i in currentCode)
        {
            code += $"{i}";
        }

        Debug.Log($"Current code is {code}");

        if (code == passcode)
        {
            onComplete.Invoke();
        }
    }

    public void DigitUp(int index) => ChangeDigit(index);
    public void DigitDown(int index) => ChangeDigit(index, false);
}