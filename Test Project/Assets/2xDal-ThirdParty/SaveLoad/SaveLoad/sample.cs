using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class sample : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dataPath = null;
    [SerializeField]
    TextMeshProUGUI classdata = null;
    [SerializeField]
    TextMeshProUGUI click = null;

    public TestData savedata;

    public enum eTest
    {
        No0,
        No1,
        No2,
    }

    [System.Serializable]
    public class TestData
    {
        public int      ID;
        public string   Message;
        public bool     Flag;
        public eTest    Test;
        public int[]    Stage;
        public List<ASD> asdasd;
    }

    const string filename = "savedata";

    void Awake()
    {
        dataPath.SetText(Path.Combine(Application.persistentDataPath, filename));

        // clear
        classdata.SetText("");
    }

    public void ClickButtonSave()
    {
        click.SetText("* SAVE *");
        classdata.SetText("");


        jsonSaveLoad.Save(filename, savedata);
    }

    public void ClickButtonLoad()
    {
        classdata.SetText("");

        savedata = jsonSaveLoad.Load<TestData>(filename);

        // display load data
        if (savedata == null)
        {
            click.SetText("* LOAD ERROR *");
        }
        else
        {
            click.SetText("* LOAD *");
            classdata.SetText(
                $"ID = {savedata.ID}{Environment.NewLine}" +
                $"Message = '{savedata.Message}'{Environment.NewLine}" +
                $"Flag = {savedata.Flag}{Environment.NewLine}" +
                $"Test = {savedata.Test}{Environment.NewLine}"
            );
        }
    }

    public void ClickButtonDelete()
    {
        click.SetText("* DELETE *");
        classdata.SetText("");

        jsonSaveLoad.Delete(filename);
    }
}

[System.Serializable]
public class ASD
{
    public string aaa;
    public Vector3 bbb;
}
