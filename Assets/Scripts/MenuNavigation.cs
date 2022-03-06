using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    private List<MenuSelector> menuOptions;
    private MenuSelector lastMenuOption;
    private int indexNavigation;
    private bool canNavigate;
    private void Awake(){
        menuOptions = new List<MenuSelector>();
        foreach (Transform item in transform){
            MenuSelector opt = item.GetComponent<MenuSelector>();
            if (opt)
                menuOptions.Add(opt);
        }
        canNavigate = false;
    }
    public void ResetNavigation(){
        canNavigate = true;
        if (lastMenuOption)
            lastMenuOption.Deselect();
        indexNavigation = 0;
        menuOptions[indexNavigation].Select();
        lastMenuOption = menuOptions[indexNavigation];
    }
    public void ExitNavigation() => canNavigate = false;
    public void SetCurrentIndex(int current){
        if (lastMenuOption)
            lastMenuOption.Deselect();
        indexNavigation = current;
        lastMenuOption = menuOptions[current];
    }
    private void Update(){
        if (!canNavigate) return;
        if (NewInputs.instace.NavigationUp)
            OnMoveUp();
        else if (NewInputs.instace.NavigationDown)
            OnMoveDown();
        else if (NewInputs.instace.Action) {
            menuOptions[indexNavigation].OnAction();
            menuOptions[indexNavigation].Deselect();
        }
    }
    private void OnMoveUp(){
        indexNavigation--;
        if (indexNavigation < 0)
            indexNavigation = menuOptions.Count - 1;
        if (lastMenuOption)
            lastMenuOption.Deselect();
        menuOptions[indexNavigation].Select();
        lastMenuOption = menuOptions[indexNavigation];
    }
    private void OnMoveDown(){
        indexNavigation++;
        if (indexNavigation > menuOptions.Count - 1)
            indexNavigation = 0;
        if (lastMenuOption)
            lastMenuOption.Deselect();
        menuOptions[indexNavigation].Select();
        lastMenuOption = menuOptions[indexNavigation];
    }
}
