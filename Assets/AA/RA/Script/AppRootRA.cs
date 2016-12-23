using UnityEngine;
using System.Collections.Generic;

public class AppRootRA : MonoBehaviour
{

    private int Instrument = 0;
    private int NumberRoom;
    private List_Headers Head;
    private List_Helpers Help;
    private List_Info1 Info1;
    private Variant_Work Variants;
    private bool oWindows = true;
    public RenderTexture Texture;
    private bool[] Task;
    void Awake()
    {
        AppRootStatic.SetAppRoot(this);
    }
    // Use this for initialization
    void Start()
    {
        StartLab(/*сюда передать вариант*/);

    }

    public void OnButtonClick(TypeButton _tb, int num_but = 0)
    {
        switch (_tb)
        {
            case TypeButton.Next:
                if (NumberRoom != 0 && NumberRoom != 5)
                {
                    AppRootStatic.NextRoomNavigation();

                }
                NumberRoom++;
                ViewerActivWindow();
                break;
            case TypeButton.Back:
                if (NumberRoom != 6 && NumberRoom != 1)
                {
                    AppRootStatic.PrevRoomNavigation();

                }
                NumberRoom--;
                ViewerActivWindow();
                break;
            case TypeButton.Metodics:
                AppRootStatic.SetActiveUI(TypeUI.AppMenu, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Header, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Info, false);
                AppRootStatic.SetActiveUI(TypeUI.Metodic, true);
                oWindows = false;
                break;
            case TypeButton.CloseMetodics:
                AppRootStatic.SetActiveUI(TypeUI.Metodic, false);
                ViewerActivWindow();
                break;
            case TypeButton.CloseApplication:
                AppRootStatic.SetActiveUI(TypeUI.AppMenu, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Header, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Info, false);
                AppRootStatic.SetActiveUI(TypeUI.Exit, true);
                oWindows = false;
                break;
            case TypeButton.YesExit:
                Application.Quit();
                break;
            case TypeButton.NoExit:
                AppRootStatic.SetActiveUI(TypeUI.Exit, false);
                ViewerActivWindow();
                break;
            case TypeButton.NextInstr:
                if (Instrument % 3 != 0) return;
                Instrument = (Instrument + 1) % 3;
                ButtonInstrument();
                AppRootStatic.NextTool();
                break;
            case TypeButton.PrevInstr:
                if (Instrument % 3 != 1) return;
                Instrument = (Instrument - 1) % 3;
                AppRootStatic.PrevuTool();
                ButtonInstrument();
                break;
            case TypeButton.Viewer:
                AppRootStatic.SetActiveUI(TypeUI.Metodic, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Viewer, true);
                AppRootStatic.SetObjectViewer(num_but, true);
                ///просотр объектов!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                break;
            case TypeButton.CloseViewr:
                AppRootStatic.SetActiveUI(TypeUI.Metodic, true);
                AppRootStatic.SetActiveLabel(TypeLabel.Viewer, false);
                break;
            case TypeButton.Task:
                AppRootStatic.SetActiveLabel(TypeLabel.Task, !AppRootStatic.isActive(TypeLabel.Task));
                ///задачи
                break;
        }
    }

    public int StartLab(int var = 1)
    {
        NumberRoom = 0;
        //Загрузка из ресурсов(json)
        string jsontmp = ((TextAsset)Resources.Load("Headers", typeof(TextAsset))).text;
        Head = JsonUtility.FromJson<List_Headers>(jsontmp);
        jsontmp = ((TextAsset)Resources.Load("Helpers", typeof(TextAsset))).text;
        Help = JsonUtility.FromJson<List_Helpers>(jsontmp);
        jsontmp = ((TextAsset)Resources.Load("Info1", typeof(TextAsset))).text;
        Info1 = JsonUtility.FromJson<List_Info1>(jsontmp);
        jsontmp = ((TextAsset)Resources.Load("Variants", typeof(TextAsset))).text;
        Variants variant = JsonUtility.FromJson<Variants>(jsontmp);
        Variants = variant.Variants_Work[var];//подгрузка варианта
        ViewerActivWindow();//Start LABS
        Task = new bool[AppRootStatic.GetCountTask()];
        for (int i = 0; i < Task.Length; i++)
            Task[i] = false;
        LoadTask();
        return 0;
    }

    private void ViewerActivWindow()
    {
        switch (NumberRoom)
        {
            case 0:
                AppRootStatic.SetActiveLabel(TypeLabel.Info, true);
                AppRootStatic.SetActiveLabel(TypeLabel.Header, true);
                AppRootStatic.SetActiveUI(TypeUI.AppMenu, true);
                AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo1, false);
                AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo2, false);
                AppRootStatic.SetActiveLabel(TypeLabel.AppMenuHelp, false);
                AppRootStatic.SetActiveButton(TypeButton.Back, false);
                AppRootStatic.SetActiveButton(TypeButton.NextInstr, false);
                AppRootStatic.SetActiveButton(TypeButton.PrevInstr, false);
                AppRootStatic.SetActiveButton(TypeButton.HideInfo1, false);
                AppRootStatic.SetActiveButton(TypeButton.HideInfo2, false);
                AppRootStatic.SetActiveButton(TypeButton.HideHelper, false);
                AppRootStatic.SetActiveUI(TypeUI.Metodic, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Viewer, false);
                AppRootStatic.SetActiveUI(TypeUI.Exit, false);
                AppRootStatic.SetLabelText(TypeLabel.Header, Head.Header[NumberRoom]);
                AppRootStatic.SetActiveLabel(TypeLabel.Task, false);
                AppRootStatic.SetActiveButton(TypeButton.Task, false);
                oWindows = true;
                AppRootStatic.isMoviment = false;
                return;
            case 6:
                AppRootStatic.SetActiveLabel(TypeLabel.Info, true);
                AppRootStatic.SetActiveLabel(TypeLabel.Header, true);
                AppRootStatic.SetActiveUI(TypeUI.AppMenu, true);
                AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo1, false);
                AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo2, false);
                AppRootStatic.SetActiveLabel(TypeLabel.AppMenuHelp, false);
                AppRootStatic.SetActiveButton(TypeButton.Next, false);
                AppRootStatic.SetActiveButton(TypeButton.NextInstr, false);
                AppRootStatic.SetActiveButton(TypeButton.PrevInstr, false);
                AppRootStatic.SetActiveButton(TypeButton.HideInfo1, false);
                AppRootStatic.SetActiveButton(TypeButton.HideInfo2, false);
                AppRootStatic.SetActiveButton(TypeButton.HideHelper, false);
                AppRootStatic.SetLabelText(TypeLabel.Header, Head.Header[NumberRoom]);
                AppRootStatic.SetActiveLabel(TypeLabel.Task, false);
                AppRootStatic.SetActiveButton(TypeButton.Task, false);
                oWindows = true;
                AppRootStatic.isMoviment = false;
                return;
            default:
                AppRootStatic.SetActiveLabel(TypeLabel.Header, true);
                AppRootStatic.SetActiveUI(TypeUI.AppMenu, true);
                if (oWindows)
                {
                    AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo1, true);
                    AppRootStatic.SetActiveLabel(TypeLabel.AppMenuInfo2, true);
                    AppRootStatic.SetActiveLabel(TypeLabel.AppMenuHelp, true);
                    AppRootStatic.SetActiveButton(TypeButton.Back, true);
                    AppRootStatic.SetActiveButton(TypeButton.Next, true);
                    AppRootStatic.SetActiveButton(TypeButton.NextInstr, true);
                    AppRootStatic.SetActiveButton(TypeButton.PrevInstr, true);
                    AppRootStatic.SetActiveButton(TypeButton.HideInfo1, true);
                    AppRootStatic.SetActiveButton(TypeButton.HideInfo2, true);
                    AppRootStatic.SetActiveButton(TypeButton.HideHelper, true);
                    AppRootStatic.SetActiveButton(TypeButton.Task, true);
                    AppRootStatic.NormalButtonHide();
                    oWindows = false;
                }
                AppRootStatic.SetLabelText(TypeLabel.Header, Head.Header[NumberRoom]);
                AppRootStatic.SetLabelText(TypeLabel.AppMenuInfo1, Info1.Info[NumberRoom - 1]);
                AppRootStatic.SetLabelText(TypeLabel.AppMenuInfo2, GetStrinInfo2(Variants.Rooms[NumberRoom - 1]));
                AppRootStatic.SetValues(System.Convert.ToSingle(Variants.Rooms[NumberRoom - 1].ValueThermometr),
                        System.Convert.ToSingle(Variants.Rooms[NumberRoom - 1].ValueAnimometr) / 10,
                        System.Convert.ToSingle(Variants.Rooms[NumberRoom - 1].ValueHygrometeDry),
                        System.Convert.ToSingle(Variants.Rooms[NumberRoom - 1].ValueHygrometeWet));
                AppRootStatic.SwitchToolOff();
                AppRootStatic.SetLabelText(TypeLabel.AppMenuHelp, Help.Helper[NumberRoom == 6 ? 1 : 0]);
                AppRootStatic.SetActiveLabel(TypeLabel.Info, false);
                AppRootStatic.SetActiveLabel(TypeLabel.Task, false);
                AppRootStatic.NormalButtonTask();
                ButtonInstrument();
                AppRootStatic.isMoviment = true;
                break;

        }
    }

    private void ButtonInstrument()
    {
        if (AppRootStatic.isActive(TypeButton.PrevInstr) && AppRootStatic.isActive(TypeButton.NextInstr))
            switch (UnityEngine.Mathf.Abs(Instrument))
            {
                case 0:
                    AppRootStatic.SetButtonText(TypeButton.NextInstr, "Анемометр");
                    AppRootStatic.SetButtonText(TypeButton.PrevInstr, "Гигрометр");
                    break;
                case 1:
                    AppRootStatic.SetButtonText(TypeButton.NextInstr, "Гигрометр");
                    AppRootStatic.SetButtonText(TypeButton.PrevInstr, "Термометр");
                    break;
                case 2:
                    AppRootStatic.SetButtonText(TypeButton.NextInstr, "Термометр");
                    AppRootStatic.SetButtonText(TypeButton.PrevInstr, "Анемометр");
                    break;
            }
    }

    private string GetStrinInfo2(Room _r)
    {
        string str = "";
        if (_r.TypeBuilding != "-")
            str += "Тип здания: " + _r.TypeBuilding;
        if (_r.TypeRoom != "-")
            str += "\nТип помещения: " + _r.TypeRoom;
        if (_r.OptionsRoom != "-")
            str += "\nПараметры помещения: " + _r.OptionsRoom;
        if (_r.TypeVentilation != "-")
            str += "\nТип вентиляции: " + _r.TypeVentilation;
        if (_r.Season != "-")
            str += "\nПериод года: " + _r.Season;
        if (_r.TypeHeating != "-")
            str += "\nТип отопления: " + _r.TypeHeating;
        return str;
    }

    private void LoadTask()
    {
        for (int i = 0; i < Task.Length; i++)
            AppRootStatic.SetActiveTaskIndecator(i + 1, Task[i]);

    }

    public void SetRunedTask()
    {
        AppRootStatic.SetActiveTaskIndecator((NumberRoom - 1) * 3 + (Instrument + 1), true);

    }
}

