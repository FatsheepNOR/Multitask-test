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
    string filePath = Application.dataPath + CSVPath + fileName;

    StreamWriter sr;
    if (File.Exists(filePath))
    {
      sr = new StreamWriter(filePath, true);
    }
    else
    {
      sr = File.CreateText(filePath);
    }
    sr.WriteLine(content);
    sr.Close();
  }
}
