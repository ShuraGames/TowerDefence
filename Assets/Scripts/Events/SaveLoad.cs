using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class TowerObjects
{
    public float[,] vextor3indexer;
    public float[,] towerQuaternionIndex;
    public string[] nameTower;
}

public class SaveLoad : MonoBehaviour
{
    

    [SerializeField] private GameObject towerOne;
    [SerializeField] private GameObject towerTwo;
    private string path = "/Logs/save.td";

    public void Save()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Tower"); 
        TowerObjects towerObjects = new TowerObjects();
        towerObjects.vextor3indexer = new float[allObjects.Length, 3];
        towerObjects.towerQuaternionIndex = new float[allObjects.Length, 3];
        towerObjects.nameTower = new string[allObjects.Length];

        for (int i = 0; i < allObjects.Length; i++)
        {
            if(towerObjects.vextor3indexer != null && towerObjects.towerQuaternionIndex != null)
            {
                towerObjects.vextor3indexer[i, 0] = allObjects[i].transform.position.x;
                towerObjects.vextor3indexer[i, 1] = allObjects[i].transform.position.y;
                towerObjects.vextor3indexer[i, 2] = allObjects[i].transform.position.z;

                towerObjects.towerQuaternionIndex[i, 0] = allObjects[i].transform.eulerAngles.x;
                towerObjects.towerQuaternionIndex[i, 1] = allObjects[i].transform.eulerAngles.y;
                towerObjects.towerQuaternionIndex[i, 2] = allObjects[i].transform.eulerAngles.z;

                towerObjects.nameTower[i] = allObjects[i].name;
                
            }
        }

        foreach(var item in towerObjects.nameTower)
            Debug.Log(item);
        
        if(!Directory.Exists(Application.dataPath + "/Logs"))
            Directory.CreateDirectory(Application.dataPath + "/Logs");

        using(FileStream fileStream = new FileStream(Application.dataPath + path, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, towerObjects);
        }      
    }

    public void Load()
    {


        if(File.Exists(Application.dataPath + path))
        {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Tower"); 

            for(var i = 0; i < allObjects.Length; i++)
            {
                Destroy(allObjects[i]);
            }

            using(FileStream fileStream = new FileStream(Application.dataPath + path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Debug.Log("1");
                try
                {
                    TowerObjects TowerObjectsVector3 = (TowerObjects)formatter.Deserialize(fileStream);
                    Debug.Log("2");
                    for (int i = 0; i < TowerObjectsVector3.vextor3indexer.GetLength(0); i++)
                    {
                        if(TowerObjectsVector3.nameTower[i] == "TowerOne(Clone)")
                        {
                            Instantiate(towerOne, new Vector3(TowerObjectsVector3.vextor3indexer[i, 0],
                                                          TowerObjectsVector3.vextor3indexer[i, 1],
                                                          TowerObjectsVector3.vextor3indexer[i, 2]), 
                                                          Quaternion.Euler(TowerObjectsVector3.towerQuaternionIndex[i, 0],
                                                                           TowerObjectsVector3.towerQuaternionIndex[i, 1],
                                                                           TowerObjectsVector3.towerQuaternionIndex[i, 2]));
                        }
                        else if(TowerObjectsVector3.nameTower[i] == "TowerTwo(Clone)")
                        {
                            Instantiate(towerTwo, new Vector3(TowerObjectsVector3.vextor3indexer[i, 0],
                                                          TowerObjectsVector3.vextor3indexer[i, 1],
                                                          TowerObjectsVector3.vextor3indexer[i, 2]), 
                                                          Quaternion.Euler(TowerObjectsVector3.towerQuaternionIndex[i, 0],
                                                                           TowerObjectsVector3.towerQuaternionIndex[i, 1],
                                                                           TowerObjectsVector3.towerQuaternionIndex[i, 2]));
                        }
                                                                           
                        Debug.Log(TowerObjectsVector3.towerQuaternionIndex[0,0]);
                        Debug.Log(TowerObjectsVector3.towerQuaternionIndex[0,1]);
                        Debug.Log(TowerObjectsVector3.towerQuaternionIndex[0,2]);
                    }
                    Debug.Log("3");
                }
                catch
                {
                    Debug.Log("Ты обосрался, штаны сними");
                }
            }
        }
    }
}
