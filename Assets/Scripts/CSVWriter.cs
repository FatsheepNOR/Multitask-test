using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour {

    public string CSVPath = "/TestData/";


	public void writeLineToCSV (string fileName, string content)
    {
        string filePath = CSVPath + fileName;
        StreamWriter writer = new StreamWriter(filePath);
        writer.WriteLine(content);
        writer.Flush();
        writer.Close();
    }
}

