using UnityEngine;

public enum TypeUI
{
    None,
    Exit,
    Metodic,
    AppMenu
};

public class UIController : MonoBehaviour {
    public TypeUI type;
    void Awake(){AppRootStatic.AddUI(this);}
    public void SetActive(bool _g){gameObject.SetActive(_g);}
    public bool isActive(){return gameObject.activeInHierarchy;}  
}
