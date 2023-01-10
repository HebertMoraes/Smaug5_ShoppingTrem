using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public static class VariablesSave
    {
        //setar essa variável ao selecionar o produto desejado lá no menu
        public static allProductsToSell currentProductSelectedToSell;
        public static float countMoney = 10;

        //esse countCash provavelmente não será usado pois só tem uma moeda no game até então
        public static int countCash;

        public static bool translate;
    
        public static int countCandy;
        public static int countChoco;
        public static int countFone;

        public static float stepsScoreRecord;
        public static int countOfSalesRecord;

        public static bool claimedSales = false;
        public static bool claimedSteps = false;

        public static float musicVolume = (float)0.7;
        public static float soundsVolume = (float)0.7;
    }