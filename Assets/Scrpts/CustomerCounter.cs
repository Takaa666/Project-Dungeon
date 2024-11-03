using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerCounter : MonoBehaviour
{
    public static CustomerCounter Instance { get; private set; }

    private int successfulOrderCount = 0;
    private int failedOrderCount = 0;
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementOrderCount()
    {
        successfulOrderCount++;
    }

    public void IncrementOrderfailed()
    {
        failedOrderCount++;
    }

    public void DisplayFinalResult()
    {
        if (resultText != null)
        {
            resultText.text = "Total Successful Orders: " + successfulOrderCount;
        }
    }
}
