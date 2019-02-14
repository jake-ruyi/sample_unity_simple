using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    RuyiNet ruyiNet;
    Menu currentMenu;
    Ruyi.SDK.InputManager.RuyiGamePadInput input;

    IMenu inputMenu;

    void Start()
    {
        ruyiNet = GetComponent<RuyiNet>();
        ruyiNet.mSDK.Subscriber.AddMessageHandler<Ruyi.SDK.InputManager.RuyiGamePadInput>((_, msg) =>
        {
            input = msg;
        });
        ruyiNet.mSDK.Subscriber.Subscribe(Ruyi.Layer0.ServiceHelper.PubChannelID(Ruyi.Layer0.ServiceIDs.INPUTMANAGER_INTERNAL));
        currentMenu = Menu.Input;
        inputMenu = new InputMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    enum Menu
    {
        Input
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        var menuoptions = Enum.GetNames(typeof(Menu)).ToArray();
        currentMenu = (Menu)GUILayout.SelectionGrid((int)currentMenu, menuoptions, 1);
        GUILayout.EndVertical();

        switch (currentMenu)
        {
            case Menu.Input:
                inputMenu.OnGUI(input);
                break;
        }
        
        GUILayout.EndHorizontal();
    }
}