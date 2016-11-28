using UnityEngine;
using System.Collections.Generic;

public static class AppRootStatic {
    private static List<UILabelController> lLabel = new List<UILabelController>();
    private static List<UIButtonController> lButton = new List<UIButtonController>();
    private static List<UIController> lUI = new List<UIController>();
    private static List<ObjectRotationViewers> lObjectViewer = new List<ObjectRotationViewers>();
    private static List<TaskController> lTask = new List<TaskController>();
    private static AppRoot _AppRoot = null;

    public static void SetAppRoot(AppRoot _ar) {
        if (_AppRoot != null || _ar == null)
        {
            Debug.Log("Approot assigned or geted to empty object");
            return;
        }
        _AppRoot = _ar;
    }
    //Добавление объектов для управления
    public static void AddLabel(UILabelController _label) {//Лейбл
        if (_label.type == TypeLabel.None) return;
        lLabel.Add(_label);
    }
    public static void AddButton(UIButtonController _button) {//кнопка
        if (_button.type == TypeButton.None) return;
        lButton.Add(_button);
    }
    public static void AddUI(UIController _ui) {//UI
        if (_ui.type == TypeUI.None) return;
        lUI.Add(_ui);
    }
    public static void AddObjectViewer(ObjectRotationViewers _orv) { lObjectViewer.Add(_orv); }
    //Активация и Диактивация объектов
    public static void SetActiveLabel(TypeLabel _tl, bool _g) {//лейбл
        for (int i = 0; i < lLabel.Count; i++)
            if (lLabel[i].type == _tl)
            {
                lLabel[i].SetActive(_g);
                return;
            }
        Debug.LogError("Label not found");
    }
    public static void SetActiveButton(TypeButton _tb, bool _g) {//кнопка
        if (_tb == TypeButton.Viewer)
        {
            Debug.LogError("Button:For the object function is not available!");
            return;
        }
        for (int i = 0; i < lButton.Count; i++)
            if (lButton[i].type == _tb)
            {
                lButton[i].SetActive(_g);
                return;
            }
        Debug.LogError("Button not found");
    }
    public static void SetActiveUI(TypeUI _tui, bool _g) {//UI
        for (int i = 0; i < lUI.Count; i++)
            if (lUI[i].type == _tui) {
                lUI[i].SetActive(_g);
                return;
            }
        Debug.LogError("UI not found");
    }
    public static void SetObjectViewer(int _nummodel, bool _g)
    {//ObjectViewer
        bool found = false;
        for (int i = 0; i < lObjectViewer.Count; i++)
        {
            if (lObjectViewer[i].isActive()) lObjectViewer[i].SetActive(false);
            if (lObjectViewer[i].NumberModel == _nummodel && !found)
            {
                lObjectViewer[i].SetActive(_g);
                found = true;
            }
        }
        if (!found) Debug.LogError("ObjectViewer not found");
    }
    //Присвоение текста
    public static void SetLabelText(TypeLabel _tl, string _str)//Лебл
    {
        for (int i = 0; i < lLabel.Count; i++)
            if (lLabel[i].type == _tl)
            {
                lLabel[i].SetText(_str);
                return;
            }
        Debug.LogError("Label not found");
    }
    public static void SetButtonText(TypeButton _tl, string _str)//кнопка
    {
        if (_tl != TypeButton.NextInstr && _tl != TypeButton.PrevInstr)
        {
            Debug.Log("Button:For the object function is not available!");
            return;
        }
        for (int i = 0; i < lButton.Count; i++)
            if (lButton[i].type == _tl)
            {
                lButton[i].SetText(_str);
                return;
            }
        Debug.LogError("Button not found");
    }
    //кликнули на кнопку
    public static void OnButtonClick(TypeButton _tb, int num_but = 0)//нажатие кнопки
    {
        if (_AppRoot == null)
        {
            Debug.Log("Not initialized AppRoot");
            return;
        }
        _AppRoot.OnButtonClick(_tb, num_but);
    }
    //Нормализация кнопок скрытия/задач
    public static void NormalButtonHide()
    {
        for (int i = 0; i < lButton.Count; i++)
            if (lButton[i].type == TypeButton.HideInfo1 || lButton[i].type == TypeButton.HideInfo2 || lButton[i].type == TypeButton.HideHelper)
                lButton[i].Normal();
    }
    public static void NormalButtonTask()
    {
        for (int i = 0; i < lButton.Count; i++)
            if (lButton[i].type == TypeButton.Task)
            {
                lButton[i].Normal();
                return;
            }

    }
    //Проверка на активность хз зачем
    public static bool isActive(TypeLabel _tl)//лейбл
    {
        for (int i = 0; i < lLabel.Count; i++)
            if (lLabel[i].type == _tl)
                return lLabel[i].isActive();
        Debug.LogError("Active:None Label");
        return false;
    }
    public static bool isActive(TypeButton _tb)//кнопка
    {
        for (int i = 0; i < lButton.Count; i++)
            if (lButton[i].type == _tb)
                return lButton[i].isActive();
        Debug.LogError("Active:None Button");
        return false;
    }
    public static bool isActive(TypeUI _tui)//UI
    {
        for (int i = 0; i < lUI.Count; i++)
            if (lUI[i].type == _tui)
                return lUI[i].isActive();
        Debug.Log("Active:None UI");
        return false;
    }
    public static bool isActive(int _nummodel)//ObjectViewer
    {
        for (int i = 0; i < lObjectViewer.Count; i++)
            if (lObjectViewer[i].NumberModel == _nummodel)
                return lObjectViewer[i].isActive();
        Debug.Log("Active:None ObjectViewer");
        return false;
    }
    //управления задачами
    public static void AddTask(TaskController _tc) { lTask.Add(_tc); }

    public static void SetActiveTaskIndecator(int _nt, bool _g)
    {
        for (int i = 0; i < lTask.Count; i++)
            if (lTask[i].GetNumberTask() == _nt)
            {
                lTask[i].SetActiveIndicator(_g);
                return;
            }
    }

    public static int GetCountTask() { return lTask.Count; }

    public static void SetRunedTask() { _AppRoot.SetRunedTask(); }

    public static TypeInstrument GetInstrument() { return _AppRoot.GetInstrument(); }
    public static string GetValueThemperature() { return _AppRoot.GetValueThemperature(); }
    public static string GetValueAnimometr() { return _AppRoot.GetValueAnimometr(); }
    public static string GetValueHygrometrDry() { return _AppRoot.GetValueHygrometrDry(); }
    public static string GetValueHygrometrWet() { return _AppRoot.GetValueHygrometrWet(); }
    private static Instrument instr= null;
    public static void AddInstrument(Instrument inst)
    {
        if (instr != null)
            return;
        instr = inst;
    }
    public static void ActiveInstrument(bool _b)
    {
        instr.Active(_b);
    }
    public static void ConfInstrument()
    {
        instr.Configurate();
    }
}
