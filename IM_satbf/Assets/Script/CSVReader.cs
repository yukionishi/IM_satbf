using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{

    [HideInInspector] public TextAsset _csvFile; // CSVファイル
    [HideInInspector] public List<string[]> _csvRawDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    [HideInInspector] public List<float[]> _csvFloatDatas = new List<float[]>();

    public void Start()
    { 

       // _csvFloatDatas = _csvRawDatas.ConvertAll(_csvRawDatas, float.Parse);

        //_csvFloatDatas = _csvRawDatas.ConvertAll(new Converter<string, float>(StringToFloat));

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReadCsv();

        }

        
    }

    public void ReadCsv()
    {
        _csvFile = Resources.Load("filtered") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            _csvRawDatas.Add(line.Split(',')); // , 区切りでリストに追加

        }

        for (int i = 0; i < _csvRawDatas.Count; i++)
        {
            for (int j = 0; j < _csvRawDatas[i].Length; j++)
            {
                Debug.Log("csvDatas[" + i + "][" + j + "] = " + _csvRawDatas[i][j]);
            }
        }


    }

    public void ConvertStringToFloat()
    {
        foreach (var data in _csvRawDatas)
        {
            _csvFloatDatas.Add(Convert.ToSingle(data));
        }
    }

}
