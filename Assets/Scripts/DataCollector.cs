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

    private 
    private float choiceTime = 0.0f;

    private float timeStamp = 0.0f;

    string csvTitles = "ArrowType,Result,Time";

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (isChoosing)
        {
            choiceTime += Time.deltaTime;
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


    }

    public void NextPerson ()
    {
        currPerson++;
        personNumber.text = "#" + currPerson;
    }
}
