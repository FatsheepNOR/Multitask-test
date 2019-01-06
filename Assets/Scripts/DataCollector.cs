using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCollector : MonoBehaviour {

    public int NumTries = 20;
    public float interval = 1.0f;
    public GameObject[] arrows;
    public CSVWriter cW;
    public Text personNumber;

    private int currPerson = 0;
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
        timeStamp = Time.time + interval;
        isTesting = true;
    }

    void NextArrow ()
    {
      correctArrow = arrows[Random.Range(0,arrows.Length)];
      correctArrow.SetActive(true);
      choiceTime = 0;
      isChoosing = true;
    }

    public void MakeChoice (string dir)
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
      timeStamp = Time.time + interval;
    }

    public void NextPerson ()
    {
        currPerson++;
        personNumber.text = "#" + currPerson;
    }
}
