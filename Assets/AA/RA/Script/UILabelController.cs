using UnityEngine;
using UnityEngine.UI;

public enum TypeLabel {
   None,//отсутствует
   AppMenuInfo1,//1-ое информационное окно на главной панели
   AppMenuInfo2,//2-ое информационное окно на главной панели
   AppMenuHelp,//окно подсказок на главной панели
   Info,//Информацилнная панель
   Header,//Заголовок
   Viewer,//Режим просмотра
   Task//pflfxb
};
public class UILabelController : MonoBehaviour {
    public TypeLabel type;
    public Text text;
    void Awake(){AppRootStatic.AddLabel(this);}
    public void SetActive(bool _g){gameObject.SetActive(_g); }
	public void SetText(string _str){
        if (text == null || type == TypeLabel.Task)
        {
            Debug.LogError("Label:Component fo text is not added");
            return;
        }
        text.text = _str;
    }
    public bool isActive(){return gameObject.activeInHierarchy;}
}
