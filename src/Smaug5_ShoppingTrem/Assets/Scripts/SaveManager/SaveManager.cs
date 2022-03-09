using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData activeSave;

    public bool hasLoaded;

    public void Awake()
    {
        instance = this;
        Load();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    //Método para salvar o Save
    public void Save()
    {
        //Application.persistentDataPath é a pasta raiz dos aparelhos Android e IOS
        string dataPath = Application.persistentDataPath;

        //Inicia o XmlSerializer para identificar os tipos de dados definidos na classe SaveData
        var serializer = new XmlSerializer(typeof(SaveData));

        //Inicia a criação do arquivo de save
        var stream = new FileStream(dataPath + "/" + "SaveTrain" + ".save", FileMode.Create);

        //O Serialize irá coletar os dados do jogo, para inserir no arquivo do save
        serializer.Serialize(stream, activeSave);

        //Finaliza a criação do arquivo de save
        stream.Close();

        Debug.Log("Saved");
    }

    //Método para carregar o Save
    public void Load()
    {

        //Application.persistentDataPath é a pasta raiz dos aparelhos Android e IOS
        string dataPath = Application.persistentDataPath;

        //Checar se o arquivo de save existe
        if(System.IO.File.Exists(dataPath + "/" + "SaveTrain" + ".save"))
        {
            //Inicia o XmlSerializer para identificar os tipos de dados definidos na classe SaveData
            var serializer = new XmlSerializer(typeof(SaveData));

            //Inicia a abertura do arquivo
            var stream = new FileStream(dataPath + "/" + "SaveTrain" + ".save", FileMode.Open);

            //O save atual do jogo irá receber os dados do Save, seguindo o formato de SaveData
            activeSave = serializer.Deserialize(stream) as SaveData;

            //Termina a leitura do save
            stream.Close();

            hasLoaded = true;
            Debug.Log("Loaded");
        }
        else
        {
            activeSave.countCandy = 50;
        }
    }
}


//Define os tipos de dados a serem salvos
[System.Serializable]
public class SaveData{

    //Variaveis de gameplay
    public int countMoney;
    public int countCash;
    public int countCandy;
    public int countChoco;
    public int countFone;

    //Variaveis de record
    public int countStepsDistance;
    public int countSoldAmount;
    public int countItemSold;
}