using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class CSVLoader : MonoBehaviour
{

    [HideInInspector] public List<string[]> _rawCsvData = new List<string[]>();
    [HideInInspector] public TextAsset _csvFile;


    public void ReadCsv()
    {
        _csvFile = Resources.Load("filtered") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);


        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            _rawCsvData.Add(line.Split(','));
        }
    }
}