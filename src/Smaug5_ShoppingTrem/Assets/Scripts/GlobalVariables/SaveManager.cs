using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    //public static SaveManager instance;
    //public SaveData activeSave;
    //public bool hasLoaded;
    private Inventory playerInventory;
    private ScoreCount playerScoreCount;
    //private LoseSystem lose;

    public void Awake()
    {
        //instance = this;
        //Load();

        //setar as variáveis de acordo com o produto escolhido na variável GlobalVariables.currentProductSelectedToSell
        //NewLoad();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerScoreCount = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCount>();

        NewLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Load();
        }
    }

    public void NewSave() {

        //salvando record steps
        if (playerScoreCount.currentScoreSteps > VariablesSave.stepsScoreRecord) {

            VariablesSave.stepsScoreRecord = playerScoreCount.currentScoreSteps;
        }

        //salvando record de vendas
        if (playerInventory.totalItemSale > VariablesSave.countOfSalesRecord) {

            VariablesSave.countOfSalesRecord = playerInventory.totalItemSale;
        }

        //salvando dinheiro
        VariablesSave.countMoney += playerInventory.moneyEarned;

        //salvando o estoque de acordo com o produto escolhido na partida
        if (playerInventory.currentTypeOfProductInInventory == allProductsToSell.Candy) {
            VariablesSave.countCandy -= playerInventory.currentProductsInInventory;
        }
        if (playerInventory.currentTypeOfProductInInventory == allProductsToSell.Choco) {
            VariablesSave.countChoco -= playerInventory.currentProductsInInventory;
        }
        if (playerInventory.currentTypeOfProductInInventory == allProductsToSell.Fone) {
            VariablesSave.countFone -= playerInventory.currentProductsInInventory;
        }
    }

    public void NewLoad() {
              
        switch (playerInventory.currentTypeOfProductInInventory)
        {
            case allProductsToSell.Candy:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyCandy;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceCandy;
                playerInventory.currentProductsInInventory = VariablesSave.countCandy;
                break;
            case allProductsToSell.Choco:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyChoco;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceChoco;
                playerInventory.currentProductsInInventory = VariablesSave.countChoco;
                break;
            case allProductsToSell.Fone:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyFone;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceFone;
                playerInventory.currentProductsInInventory = VariablesSave.countFone;
                break;
            default:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyCandy;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceCandy;
                break;
        }
    }

    /*
    //M�todo para salvar o Save
    public void Save()
    {
        //Application.persistentDataPath � a pasta raiz dos aparelhos Android e IOS
        string dataPath = Application.persistentDataPath;

        //Inicia o XmlSerializer para identificar os tipos de dados definidos na classe SaveData
        var serializer = new XmlSerializer(typeof(SaveData));

        //Inicia a cria��o do arquivo de save
        var stream = new FileStream(dataPath + "/" + "SaveTrain" + ".save", FileMode.Create);

        //O Serialize ir� coletar os dados do jogo, para inserir no arquivo do save
        serializer.Serialize(stream, activeSave);

        //Finaliza a cria��o do arquivo de save
        stream.Close();

        Debug.Log("Saved");
    }

    //M�todo para carregar o Save
    public void Load()
    {

        //Application.persistentDataPath � a pasta raiz dos aparelhos Android e IOS
        string dataPath = Application.persistentDataPath;

        //Checar se o arquivo de save existe
        if(System.IO.File.Exists(dataPath + "/" + "SaveTrain" + ".save"))
        {
            //Inicia o XmlSerializer para identificar os tipos de dados definidos na classe SaveData
            var serializer = new XmlSerializer(typeof(SaveData));

            //Inicia a abertura do arquivo
            var stream = new FileStream(dataPath + "/" + "SaveTrain" + ".save", FileMode.Open);

            //O save atual do jogo ir� receber os dados do Save, seguindo o formato de SaveData
            activeSave = serializer.Deserialize(stream) as SaveData;

            //Termina a leitura do save
            stream.Close();

            hasLoaded = true;
            Debug.Log("Loaded");
        }
        else
        {
            SaveManager.instance.activeSave.countCandy = 50;
        }
    }
    */
    /*
    #region SelectCrate
    public void CandySelectedCrate()
    {
        //activeSave.currentCrate = "Candy";
        Debug.Log("O produto selecionado foi: Candy");
        //Save();
    }

    public void ChocoSelectedCrate()
    {
        //activeSave.currentCrate = "Choco";
        Debug.Log("O produto selecionado foi: Choco");
        //Save();
    }
    public void FoneSelectedCrate()
    {
        //activeSave.currentCrate = "Fone";
        Debug.Log("O produto selecionado foi: Fone");
        //Save();
    }
    #endregion
    */
    /*
    #region BuyCrates
    public void BuyCandy()
    {
        if(activeSave.countMoney >= 50)
        {
            activeSave.countCandy += 50;
            activeSave.countMoney -= 50;
            Debug.Log("Compra efetuada com sucesso!");
            //Save();
        }
        else
        {
            Debug.Log("Voc� n�o tem dinheiro para comprar mais produtos! Jogue para conseguir mais.");
        }
    }

    public void BuyChoco()
    {
        if (activeSave.countCash >= 50)
        {
            activeSave.countChoco += 50;
            activeSave.countCash -= 50;
            Debug.Log("Compra efetuada com sucesso!");
            //Save();
        }
        else
        {
            Debug.Log("Voc� n�o tem dinheiro para comprar mais produtos! Jogue para conseguir mais.");
        }
    }

    public void BuyFone()
    {
        if (activeSave.countCash >= 75)
        {
            activeSave.countFone += 50;
            activeSave.countCash -= 75;
            Debug.Log("Compra efetuada com sucesso!");
            //Save();
        }
        else
        {
            Debug.Log("Voc� n�o tem dinheiro para comprar mais produtos! Jogue para conseguir mais.");
        }
    }
    #endregion
    */

    /*
    #region MissionReward
    public void ClaimMetragem()
    {
        activeSave.countCash += 25;
        activeSave.haveClaimedRewardMetragem = true;
        //Save();
    }
    public void ClaimItemSold()
    {
        activeSave.countCash += 50;
        activeSave.haveClaimedRewardItemSold = true;
        //Save();
    }
    public void ClaimSalesAmount()
    {
        activeSave.countCash += 75;
        activeSave.haveClaimedRewardSalesAmount = true;
        //Save();
    }
    #endregion
    */
    /*
    #region Records
    public void IncrementScore()
    {
        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");
        playerInventory = playerCharacter.GetComponent<Inventory>();
        playerScoreCount = playerCharacter.GetComponent<ScoreCount>();
        activeSave.countStepsDistance += playerScoreCount.currentScoreSteps;
        activeSave.countSalesAmount += playerInventory.moneyEarned;
        activeSave.countItemSold += playerInventory.currentProductsMerchandise;
        //Save();
    }
    #endregion
    */
}

/*
//Define os tipos de dados a serem salvos
[System.Serializable]
public class SaveData{

    //Variaveis de gameplay
    public int countMoney;
    public int countCash;
    public int countCandy;
    public int countChoco;
    public int countFone;
    public string currentCrate;

    //Variaveis de record
    public float countStepsDistance;
    public float countSalesAmount;
    public int countItemSold;

    //Habilitam as miss�es
    public bool haveClaimedRewardMetragem = false;
    public bool haveClaimedRewardSalesAmount = false;
    public bool haveClaimedRewardItemSold = false;

}*/