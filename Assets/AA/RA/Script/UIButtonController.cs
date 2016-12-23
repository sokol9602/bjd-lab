using UnityEngine;
using UnityEngine.UI;

public enum TypeButton
{
    None,//отсутствует
    YesExit,//да в окне поддтверждения выхода
    NoExit,//нет в окне поддтверждения выхода
    CloseApplication,//кнопка выхода на заголовке
    CloseMetodics,//закрыть метод.указания
    Metodics,//кнопка метод.указания на главной панели
    Next,//кнопка далее на главной панели
    Back,//кнопка назад на главной панелиы
    NextInstr,//следующий инструмент
    PrevInstr,//Предыдущий инструмент
    Viewer,//просмотр объектов
    CloseViewr,//закрыть режим просмотра
    //Скрыть/Раскрыть
    HideInfo1,
    HideInfo2,
    HideHelper,
    //______________//
    Task
};

public class UIButtonController : MonoBehaviour {
    public TypeButton type;
    [Range (1,19)]
    public int NumberModel;
    private Text txt;
    private Quaternion Rotation;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
        AppRootStatic.AddButton(this);
        if (type == TypeButton.NextInstr || type == TypeButton.PrevInstr)
            txt = GetComponentInChildren<Text>();
        Rotation = transform.rotation;
    }
    public void SetActive(bool _g){gameObject.SetActive(_g);}
    public void Click(){  
        if (type == TypeButton.HideInfo1 || type == TypeButton.HideInfo2 || type == TypeButton.HideHelper)
        {
            gameObject.transform.Rotate(0, 0, 180);
            switch (type)
            {
                case TypeButton.HideInfo1:
                    AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo1, !AppRootStatic.isActive(TypeLabel.AppMenuInfo1));
                    break;
                case TypeButton.HideInfo2:
                    AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo2, !AppRootStatic.isActive(TypeLabel.AppMenuInfo2));
                    break;
                case TypeButton.HideHelper:
                    AppRootStatic.SetActiveLabel(TypeLabel.AppMenuHelp, !AppRootStatic.isActive(TypeLabel.AppMenuHelp));
                    break;
            }
            return;
        }
        if (type == TypeButton.Task) GetComponentInChildren<RawImage>().transform.Rotate(0, 0, 180);
        AppRootStatic.OnButtonClick(type,type==TypeButton.Viewer ? NumberModel:0);
    }
    public void SetText(string _str)
    {
        if (txt == null)
        {
            Debug.LogError("Button:Component fo text is not added");
            return;
        }
        txt.text = _str;
    }
    public int GetNumberModel(){return NumberModel;}//возможно не нужен!!!!!!!!!!!!!!!!!!!!!!
    public bool isActive(){return gameObject.activeInHierarchy;}
    public void Normal(){
        if (type== TypeButton.Task)
            GetComponentInChildren<RawImage>().transform.rotation=new Quaternion(0, 0, 180, 0);
        else 
            transform.rotation = Rotation;
    }    
}
