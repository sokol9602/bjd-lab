using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum TypeInstrument {
    None,
    Thermometr,
    Animometr,
    Hygrometr
};

public class Instrument : MonoBehaviour {

    public Text TextValue1,TextValue2,TextValueIzmer1,TextValueIzmer2;
    public Button Izmer;

    void Awake()
    {
        AppRootStatic.AddInstrument(this);
    }

    public void Active(bool _b)
    {
        gameObject.SetActive(_b);
    } 

    public void onClickButton()
    {
        Configurate();
        switch (AppRootStatic.GetInstrument())
        {
            case TypeInstrument.Thermometr:
                TextValueIzmer1.text = AppRootStatic.GetValueThemperature();
                break;
            case TypeInstrument.Animometr:
                TextValueIzmer1.text = AppRootStatic.GetValueAnimometr();
                break;
            case TypeInstrument.Hygrometr:
                TextValueIzmer1.text = AppRootStatic.GetValueHygrometrDry();
                TextValueIzmer2.text = AppRootStatic.GetValueHygrometrWet();
                break;
        }
        AppRootStatic.SetRunedTask();

    }

    public void Configurate() {
        switch (AppRootStatic.GetInstrument())
        {
            case TypeInstrument.Thermometr:
                TextValue1.gameObject.SetActive(true);
                TextValueIzmer1.gameObject.SetActive(true);
                Izmer.gameObject.SetActive(true);
                TextValue1.text = "Температура:";
                TextValueIzmer1.text = "";
                TextValue2.gameObject.SetActive(false);
                TextValueIzmer2.gameObject.SetActive(false);
                break;
            case TypeInstrument.Animometr:
                TextValue1.gameObject.SetActive(true);
                TextValueIzmer1.gameObject.SetActive(true);
                Izmer.gameObject.SetActive(true);
                TextValue1.text = "Скорость движения воздуха:";
                TextValueIzmer1.text = "";
                TextValue2.gameObject.SetActive(false);
                TextValueIzmer2.gameObject.SetActive(false);
                break;
            case TypeInstrument.Hygrometr:
                TextValue1.gameObject.SetActive(true);
                TextValueIzmer1.gameObject.SetActive(true);
                Izmer.gameObject.SetActive(true);
                TextValue1.text = "Температура сухого воздуха:";
                TextValueIzmer1.text = "";
                TextValue2.gameObject.SetActive(true);
                TextValueIzmer2.gameObject.SetActive(true);
                TextValue2.text = "Температура влажного воздуха:";
                TextValueIzmer2.text = "";
                break;
        }
    }
}
