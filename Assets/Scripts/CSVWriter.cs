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
    Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("nb-NO");
    string filePath = Application.dataPath + CSVPath + fileName;
        /*
        FileStream file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamWriter writer = new StreamWriter(file);
        writer.WriteLine(content);
        file.Flush();
        file.Close();
        writer.Flush();
        writer.Close();
        */
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
