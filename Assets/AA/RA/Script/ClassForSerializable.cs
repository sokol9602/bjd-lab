[System.Serializable]
public class Report
{
    public Workplace[] _place;
}
[System.Serializable]
public class Workplace
{
    public string Workplace_Number;
    public string TypeVentilation;
    public string Season;
    public string TypeHeating;
    public string CatigoriaGravityWorks;
    public string ValueTemperature;
    public string ValueHumidity;
    public string ValueAirVelocity;
    public string ConditionTemperature;
    public string[] RecomendationTemperature;
    public string ConditionHumidity;
    public string[] RecomendationHumidity;
    public string ConditionWind;
    public string[] RecomendationWind;
}
[System.Serializable]
public class Room
{
    public string NumberRoom;
    public string TypeBuilding;
    public string TypeRoom;
    public string OptionsRoom;
    public string TypeVentilation;
    public string Season;
    public string TypeHeating;
    public string ValueThermometr;
    public string ValueAnimometr;
    public string TypeHygrometer;
    public string ValueHygrometeDry;
    public string ValueHygrometeWet;

}
[System.Serializable]
public class Variant_Work
{
    public string NumberVariant;
    public Room[] Rooms;
}
[System.Serializable]
public class Variants
{
    public Variant_Work[] Variants_Work;
}
[System.Serializable]
public class List_Headers
{
    public string[] Header;
}

[System.Serializable]
public class List_Helpers
{
    public string[] Helper;
}

[System.Serializable]
public class List_Info1
{
    public string[] Info;
}