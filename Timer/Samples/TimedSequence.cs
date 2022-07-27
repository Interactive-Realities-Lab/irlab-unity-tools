/* Example on how to use the timer class
 * It shows two possible ways on how to use the class. 
 * Press space to start the countdown timer. After the time select it will execute a function with a parameter
 * In the Update we can get the elapsed time and display it as a countdown (for example in the UI) 
 * Add this script to a GameObject
 * 
*/

using IRLab.Tools.Timer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSequence : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] private int delayExecution;

    Timer countDown = null;
    int prevValue;

    void ExecuteSomething(int arg)
    {
        Debug.Log("Executing something after " + arg + " seconds");
        //Simple way to execute something after some time
        Timer.Create(() => Debug.Log("Timed execution after executing something"), 2f);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && countDown == null)
            StartCountdown();

        //Wait until the timer is started
        if (countDown == null) return;
        
        //Display the countdown if the timer was started        
        CountdownDisplay();

    }

    private void StartCountdown()
    {
        countDown = Timer.Create(() => ExecuteSomething(delayExecution), delayExecution);
        prevValue = (int)countDown.ElapsedTime;
    }

    private void CountdownDisplay()
    {
        if (countDown == null) return;

        int value = (int)countDown.ElapsedTime;

        if (value == prevValue) return;

        if (value % 1 != 0) return;

        Debug.Log(value);

        if (value == 0)
            countDown = null;

        prevValue = value;
    }
}
