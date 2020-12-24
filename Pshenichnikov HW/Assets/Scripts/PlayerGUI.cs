using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public int HP = 9;

    public Texture2D icon;

    //private string textFieldValue = "Hello world";
    //private bool toggleBool = true;
    //private int toolbarInt = 0;
    //private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };
    //private int selectionGridInt = 0;
    //private string[] selectionStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };

    ////void OnGUI()
    ////{
    ////    GUI.Box(new Rect(10, 10, 200, 140), "Main Menu");
    ////    if (GUI.RepeatButton(new Rect(20, 40, 180, 30), "Open")) //разновидность обычной кнопки. Событие происходит каждый кадр, пока кнопка нажата.
    ////        message = "Open";
    ////    if (GUI.Button(new Rect(20, 75, 180, 30), "Save"))  //кнопка, обычный интерактивный элемент. Событие происходит один раз в момент отпускания кнопки;
    ////        message = "Save";
    ////    if (GUI.Button(new Rect(20, 110, 180, 30), "Load"))
    ////        message = "Load";
    ////    GUI.Label(new Rect(45, 15, 30, 30), message); // неинтерактивный элемент, использующийся только для отображения информации;
    ////    textFieldValue = GUI.TextField(new Rect(25, 25, 100, 30), textFieldValue); //интерактивное однострочное текстовое поле:
    ////    textAreaValue = GUI.TextArea(new Rect(25, 25, 100, 30), textAreaValue); //интерактивное многострочное текстовое поле (область):
    ////    toggleBool = GUI.Toggle(new Rect(25, 25, 100, 30), toggleBool, "Toggle"); аналог элемента checkbox:
    ////    toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, toolbarStrings); //представляет собой набор кнопок, где только одна может быть активна в конкретный момент времени. Это некий аналог панели, не предполагающей одновременное использование нескольких инструментов:
    ////    selectionGridInt = GUI.SelectionGrid(new Rect(25, 25, 300, 60), selectionGridInt, selectionStrings, 2); //представляет собой многострочный Toolbar:
    ////    GUI.Box(new Rect(10, 10, 30, 30), icon);

    ////    message = "10";

    ////    GUI.BeginGroup(new Rect(0, 0, 200, 200));
    ////    GUI.Box(new Rect(10, 10, 50, 40), new GUIContent(message, icon));
    ////    GUI.EndGroup();

    ////}





    ////////////////////////////////////////////////////////////

    public Color myColor;
    public MeshRenderer hat;
    void OnGUI()
    {
        myColor = RGBSlider(new Rect(10, 70, 200, 20), myColor);
        hat.material.color = myColor;


        GUI.BeginGroup(new Rect(0, 0, 200, 200));
        
        GUI.Box(new Rect(10, 10, 50, 40), new GUIContent(HP.ToString(), icon));
        GUI.EndGroup();
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        GUI.Label(new Rect(45, 75, 200, 100), "Настройка шляпы");
        screenRect.y += 20;
        rgb.r = LabelSlider(screenRect, rgb.r, 0f, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0f, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0f, 1.0f, "Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0f, 1.0f, "Alpha");
        return rgb;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }

    private void Update()
    {
        //var main = hat.GetComponent<ParticleSystem>().main.startColor;
       // main = myColor;
    }
}
