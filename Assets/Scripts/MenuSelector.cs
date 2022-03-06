using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class MenuSelector : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject ImgSelector;
    [SerializeField] private UnityEvent PointerEnter;
    private AudioSource audioMain;
    private Button button;
    private void Awake(){
        audioMain = GetComponent<AudioSource>();
        button = GetComponent<Button>();
    }
    public void Select(){
        ImgSelector.gameObject.SetActive(true);
        UIAudioPlayer.PlayPositive();
    }
    public void Deselect(){
        ImgSelector.gameObject.SetActive(false);
    }
    public void OnAction(){
        UIAudioPlayer.PlayPositive();
        ImgSelector.gameObject.SetActive(false);
        button.onClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnter?.Invoke();
        Select();
    }
    private void OnDisable()
    {
        Deselect();
    }
}
