using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class Button_Event : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector3 defaultposition;//드롭하면 다시 원위치로 보내기위한 변수 

    Vector3 scale = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)//드래그시작할 때
    {

        defaultposition = this.transform.position;
    }
    float distance = 10.0f;

    void IDragHandler.OnDrag(PointerEventData eventData)//드래그중일 때 
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, distance);
        transform.position = mousePosition;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)//드래그 끝났을 때
    {
        Vector3 help = new Vector3(0, 400, distance);
        Vector3 currentPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y, distance);
        this.transform.position = currentPos;
        if (currentPos.y >= help.y)
        {
            this.gameObject.SetActive(false);
//            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = defaultposition;
        }
        else
        {
  //          Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = defaultposition;
        }
    }

    public void 삭제()
    {
        this.gameObject.SetActive(false);
    }

    public void hello()
    {
        scale.x = 1;
        scale.y = 1;
        scale.z = 1;
        transform.localScale = scale;
    }

    public void okok()
    {
        scale.x = 2;
        scale.y = 2;
        scale.z = 2;
        transform.localScale = scale;
    }

    

    public void Back_to_the_Cave()
    {
        SceneManager.LoadSceneAsync("02 메인게임");
    }

    public void 상점()
    {
        SceneManager.LoadSceneAsync("04 상점");
    }

}

