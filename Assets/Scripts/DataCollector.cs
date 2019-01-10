using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCollector : MonoBehaviour {

    public InputField NumTries;
    public InputField interval;
    public GameObject[] arrows;
    public CSVWriter cW;
    public Text personNumber; 
    public GameObject gameScreen;
    public GameObject endScreen;

    private int currPerson = 0;
    private int currChoice = 0;
    private bool isTesting = false;
    private bool isChoosing = false;

    private float choiceTime = 0.0f;
    private GameObject correctArrow;

    private float timeStamp = 0.0f;

    string csvTitles = "ArrowType;Result;Time";

	// Use this for initialization
	void Start ()
    {

	}

	// Update is called once per frame
	void Update ()
    {
        if (isChoosing && isTesting)
        {
          choiceTime += Time.deltaTime;
        }
        else if (Time.time >= timeStamp && isTesting)
        {
          NextArrow();
        }

	}

    public void StartTest ()
    {
        cW.writeLineToCSV(currPerson + ".csv", csvTitles);
        timeStamp = Time.time + float.Parse(interval.text);
        currChoice = 0;
        isTesting = true;
    }

    void NextArrow ()
    {
        if (currChoice >= int.Parse(NumTries.text))
        {
            EndTest();
        }

        correctArrow = arrows[Random.Range(0,arrows.Length)];
        correctArrow.SetActive(true);
        choiceTime = 0;
        isChoosing = true;
    }

    public void MakeChoice (string dir)
    {
        if (isChoosing)
        {
            isChoosing = false;
            bool isCorrect = false;
            if (correctArrow.name[0] == dir[0])
            {
                isCorrect = true;
            }
            correctArrow.SetActive(false);
            string resultData = correctArrow.name + ";" + isCorrect + ";" + choiceTime;
            cW.writeLineToCSV(currPerson + ".csv", resultData);
            timeStamp = Time.time + float.Parse(interval.text);
            currChoice++;
        }
    }

    public void EndTest ()
    {
        isTesting = false;
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
    }

    public void NextPerson ()
    {
        currPerson++;
        personNumber.text = "#" + currPerson;
    }

    public void ResetTest()
    {
        currPerson = 0;
        personNumber.text = "#" + currPerson;
    }
}
