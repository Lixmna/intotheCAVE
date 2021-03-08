using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Cache;
using System.Reflection;
using System;
using static UnityEngine.Random;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

public class GameScript : MonoBehaviour
{
    public GameObject 일시정지;
    public GameObject 카드뽑기;
    public GameObject 지도;
    public Slider 적1의체력바;
    public Slider 적2의체력바;
    public Slider 적3의체력바;
    public Text gameOverText;
    private bool isGameOver = false;
    private bool 카드1체크 = true;
    private bool 카드2체크 = true;
    private bool 카드3체크 = true;
    private bool 카드4체크 = true;
    private bool 카드5체크 = true;
    public Text 적1체력바;
    public Text 적2체력바;
    public Text 적3체력바;
    public Text 적1공격텍스트;
    public Text 적2공격텍스트;
    public Text 적3공격텍스트;
    public Button 카드1;
    public Button 카드2;
    public Button 카드3;
    public Button 카드4;
    public Button 카드5;
    public Button 뽑기카아드1;
    public Button 뽑기카아드2;
    public Button 뽑기카아드3;

    public Button 적적적적적1;
    public Button 적적적적적2;
    public Button 적적적적적3;

    public Image 적공방표시1;
    public Image 적공방표시2;
    public Image 적공방표시3;

    public int 데미지;

    public Text 덱트레커;

    public Text 내체력바;
    public Slider 나의체력바;

    public GameObject 적1체력바파괴;
    public GameObject 적2체력바파괴;
    public GameObject 적3체력바파괴;
    public GameObject 적1;
    public GameObject 적2;
    public GameObject 적3;
    public GameObject 적1공격파괴;
    public GameObject 적2공격파괴;
    public GameObject 적3공격파괴;
    public GameObject 적1공격;
    public GameObject 적2공격;
    public GameObject 적3공격;

    public GameObject 버1번;
    public GameObject 버2번;
    public GameObject 버3번;
    public GameObject 버4번;
    public GameObject 버5번;
    public GameObject 버6번;
    public GameObject 버7번;
    public GameObject 버8번;
    public GameObject 버9번;
    public GameObject 버10번;
    public GameObject 버11번;

    public GameObject 게임오버;



    public int[] age = new int[100];
    public int[] maindeck = new int[1000];
    public int[] subdeck = new int[1000];
    public int[] 뽑기카드 = new int[100];
    public int[] 적이란 = new int[100];

    public float 적1체력바값=100;
    public float 적2체력바값=100;
    public float 적3체력바값=100;

    private bool subdeck1 = true;
    private bool subdeck2 = true;
    private bool subdeck3 = true;
    private bool subdeck4 = true;
    private bool subdeck5 = true;

    public int maindeckcheck = 0;
    public int alpah = 0;
    public int 회복력 = 0;
    public int 최대체력 = 200;

    public int subdeckcheck = 0;

    public int 블랙홀 = 0;
    public int 블랙홀저장 = 0;

    public GameObject Target;
    public GameObject Target2;
    public GameObject Target3;
    public GameObject Target4;
    public GameObject Target5;

    public int A = 0, B = 0, C = 0;

    public int gameover = 3;

    public int 턴 = 1;

    public int 활성화 = 2;

    public void 맵활성화()
    {
        if(활성화 == 2)
        {
            버2번.SetActive(true);
            버3번.SetActive(true);
        }
        if(활성화 == 3)
        {
            버4번.SetActive(true);
            버5번.SetActive(true);
            버6번.SetActive(true);
        }
        if (활성화 == 4)
        {
            버7번.SetActive(true);
            버8번.SetActive(true);
        }
        if (활성화 == 5)
        {
            버9번.SetActive(true);
            버10번.SetActive(true);
        }

        if (활성화 == 6)
        {
            버11번.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maindeck[0] = UnityEngine.Random.Range(0, 39);
        maindeck[1] = UnityEngine.Random.Range(0, 39);
        maindeck[2] = UnityEngine.Random.Range(0, 39);
        maindeck[3] = UnityEngine.Random.Range(0, 39);
        maindeck[4] = UnityEngine.Random.Range(0, 39);
        maindeckcheck = 5;
        적1체력바값 = 100;
        적2체력바값 = 100;
        적3체력바값 = 100;
        랜덤적();
        deck();
        뽑기뽑기();
    }

    public void 뽑기뽑기()
    {
        뽑기카드[1] = UnityEngine.Random.Range(0, 39);
        뽑기카드[2] = UnityEngine.Random.Range(0, 39);
        뽑기카드[3] = UnityEngine.Random.Range(0, 39);

    }
    // Update is called once per frame
    void Update()
    {
        카드그림체크();
        맵활성화();
        if (!isGameOver)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0, 0); //get input
        }

        적사망();

        if(gameover == 0)
        {
            카드뽑기.SetActive(true);
        }

        블랙홀확인();

        if (나의체력바.value <= 0)
        {
            GameOver();
        }
    }

    public void 일시정지_메뉴()
    {
        일시정지.SetActive(true);
    }

    public void 재시작()
    {
        일시정지.SetActive(false);
    }

    public void 메인메뉴_재시작()
    {
        SceneManager.LoadSceneAsync("01 메인메뉴");
    }

    public void 적사망()
    {
        if (적1체력바값 <= 0 && GameObject.Find("적1") != null)
        {
            적1체력바파괴.SetActive(false);
            적1.SetActive(false);
            적1공격파괴.SetActive(false);
            적1공격.SetActive(false);
            gameover--;
        }
        if (적2체력바값 <= 0 && GameObject.Find("적2") != null)
        {
            적2체력바파괴.SetActive(false);
            적2.SetActive(false);
            적2공격파괴.SetActive(false);
            적2공격.SetActive(false);
            gameover--;

        }
        if (적3체력바값 <= 0 && GameObject.Find("적3") != null)
        {
            적3체력바파괴.SetActive(false);
            적3.SetActive(false);
            적3공격파괴.SetActive(false);
            적3공격.SetActive(false);

            gameover--;
        }
    }

    public void PlayerHPbar()   
    {
    }

    public void 카드체크()
    {
        if(카드1체크 == false && subdeck1 == true)
        {
            subdeck[subdeckcheck] = age[0];
            subdeckcheck++;
            subdeck1 = false;
        }
        if (카드2체크 == false && subdeck2 == true)
        {
            subdeck[subdeckcheck] = age[1];
            subdeckcheck++;
            subdeck2 = false;
        }
        if (카드3체크 == false && subdeck3 == true)
        {
            subdeck[subdeckcheck] = age[2];
            subdeckcheck++;
            subdeck3 = false;
        }
        if (카드4체크 == false && subdeck4 == true)
        {
            subdeck[subdeckcheck] = age[3];
            subdeckcheck++;
            subdeck4 = false;
        }
        if (카드5체크 == false && subdeck5 == true)
        {
            subdeck[subdeckcheck] = age[4];
            subdeckcheck++;
            subdeck5 = false;
        }
    }

    public void 카드그림체크()
    {
        switch(age[0])
        {
            case 1:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                카드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }
        switch (age[1])
        {
            case 1:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                카드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }
        switch (age[2])
        { 
                    case 1:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
            break;
        case 2:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
            break;
        case 3:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
            break;
        case 4:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
            break;
        case 5:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
            break;
        case 6:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
            break;
        case 7:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
            break;
        case 8:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
            break;
        case 9:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
            break;
        case 10:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
            break;
        case 11:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
            break;
        case 12:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
            break;
        case 13:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
            break;
        case 14:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
            break;
        case 15:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
            break;
        case 16:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
            break;
        case 17:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
            break;
        case 18:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
            break;
        case 19:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
            break;
        case 20:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
            break;
        case 21:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
            break;
        case 22:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
            break;
        case 23:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
            break;
        case 24:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
            break;
        case 25:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
            break;
        case 26:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
            break;
        case 27:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
            break;
        case 28:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
            break;
        case 29:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
            break;
        case 30:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
            break;
        case 31:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
            break;
        case 32:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
            break;
        case 33:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
            break;
        case 34:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
            break;
        case 35:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
            break;
        case 36:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
            break;
        case 37:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
            break;
        case 38:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
            break;
        case 39:
            카드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
            break;
        }
        switch (age[3])
        {
            case 1:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                카드4.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }
        switch (age[4])
        {
            case 1:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                카드5.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }
        switch (뽑기카드[1])
        {
            case 1:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                뽑기카아드1.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }
        switch (뽑기카드[2])
        {
            case 1:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                뽑기카아드2.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }
        switch (뽑기카드[3])
        {
            case 1:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법9", typeof(Sprite)) as Sprite;
                break;
            case 7:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법10", typeof(Sprite)) as Sprite;
                break;
            case 8:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법11", typeof(Sprite)) as Sprite;
                break;
            case 9:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법12", typeof(Sprite)) as Sprite;
                break;
            case 10:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법14", typeof(Sprite)) as Sprite;
                break;
            case 11:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법15", typeof(Sprite)) as Sprite;
                break;
            case 12:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법16", typeof(Sprite)) as Sprite;
                break;
            case 13:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법17", typeof(Sprite)) as Sprite;
                break;
            case 14:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법18", typeof(Sprite)) as Sprite;
                break;
            case 15:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법19", typeof(Sprite)) as Sprite;
                break;
            case 16:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법20", typeof(Sprite)) as Sprite;
                break;
            case 17:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/마법22", typeof(Sprite)) as Sprite;
                break;
            case 18:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리1", typeof(Sprite)) as Sprite;
                break;
            case 19:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리2", typeof(Sprite)) as Sprite;
                break;
            case 20:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리4", typeof(Sprite)) as Sprite;
                break;
            case 21:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리5", typeof(Sprite)) as Sprite;
                break;
            case 22:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리6", typeof(Sprite)) as Sprite;
                break;
            case 23:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리7", typeof(Sprite)) as Sprite;
                break;
            case 24:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리8", typeof(Sprite)) as Sprite;
                break;
            case 25:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리9", typeof(Sprite)) as Sprite;
                break;
            case 26:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/물리10", typeof(Sprite)) as Sprite;
                break;
            case 27:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복1", typeof(Sprite)) as Sprite;
                break;
            case 28:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복2", typeof(Sprite)) as Sprite;
                break;
            case 29:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복3", typeof(Sprite)) as Sprite;
                break;
            case 30:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복4", typeof(Sprite)) as Sprite;
                break;
            case 31:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복5", typeof(Sprite)) as Sprite;
                break;
            case 32:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복6", typeof(Sprite)) as Sprite;
                break;
            case 33:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복7", typeof(Sprite)) as Sprite;
                break;
            case 34:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복8", typeof(Sprite)) as Sprite;
                break;
            case 35:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복9", typeof(Sprite)) as Sprite;
                break;
            case 36:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복10", typeof(Sprite)) as Sprite;
                break;
            case 37:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복11", typeof(Sprite)) as Sprite;
                break;
            case 38:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복12", typeof(Sprite)) as Sprite;
                break;
            case 39:
                뽑기카아드3.GetComponent<Image>().sprite = Resources.Load("images/카드/회복14", typeof(Sprite)) as Sprite;
                break;
        }

    }

    public void 카드확인()
    {
        int k = 3;
        if(GameObject.Find("카드1") == null)
        {
            k--;
        }
        if (GameObject.Find("카드2") == null)
        {
            k--;
        }
        if (GameObject.Find("카드3") == null)
        {
            k--;
        }
        if (GameObject.Find("카드4") == null)
        {
            k--;
        }
        if (GameObject.Find("카드5") == null)
        {
            k--;
        }
        if(k<=0)
        {
            카드1체크 = false;
            카드2체크 = false;
            카드3체크 = false;
            카드4체크 = false;
            카드5체크 = false;
            카드체크();
            deck();
        }
    }


    public void 블랙홀확인()
    {
        if(블랙홀 == 0)
        {
            if(블랙홀저장 == 1)
            {
                적1체력바파괴.SetActive(true);
                적1.SetActive(true);
                적1공격파괴.SetActive(true);
                적1공격.SetActive(true);
            }
            if (블랙홀저장 == 2)
            {
                적2체력바파괴.SetActive(true);
                적2.SetActive(true);
                적2공격파괴.SetActive(true);
                적2공격.SetActive(true);
            }
            if (블랙홀저장 == 3)
            {
                적3체력바파괴.SetActive(true);
                적3.SetActive(true);
                적3공격파괴.SetActive(true);
                적3공격.SetActive(true);
            }
            블랙홀 = 100;
        }
    }

    public void 카드능력(int 능력,int 적순서)
    {
        float Z, X, Y;
        Z = 적1의체력바.value;
        X = 적2의체력바.value;
        Y = 적3의체력바.value;

        switch (능력)
        {
            case 1:
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 35 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 35 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 35 + alpah;
                }
                alpah = 0;
                break;
            case 2:
                alpah = 35;
                break;
            case 3:
                if(적순서 == 1)
                {
                    블랙홀 = 3;
                    블랙홀저장 = 1;
                    적1체력바파괴.SetActive(false);
                    적1.SetActive(false);
                    적1공격파괴.SetActive(false);
                    적1공격.SetActive(false);
                }
                if(적순서 == 2)
                {
                    블랙홀 = 3;
                    블랙홀저장 = 2;
                    적2체력바파괴.SetActive(false);
                    적2.SetActive(false);
                    적2공격파괴.SetActive(false);
                    적2공격.SetActive(false);

                }
                if (적순서 == 3)
                {
                    블랙홀 = 3;
                    블랙홀저장 = 3;
                    적3체력바파괴.SetActive(false);
                    적3.SetActive(false);
                    적3공격파괴.SetActive(false);
                    적3공격.SetActive(false);

                }
                alpah = 0;
                break;
            case 4:
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 40 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 40 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 40 + alpah;
                }
                alpah = 0;
                break;
            case 5:
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 25 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 25 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 25 + alpah;
                }
                alpah = 0;
                break;
            case 6:
                // 마법 9 블리자드
                break;
            case 7:
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 50 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 50 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 50 + alpah;
                }
                alpah = 0;
                break;
            case 8: 
                if (적순서 == 1)
                {
                    적1의체력바.value = 0;
                }
                if (적순서 == 2)
                {
                    적2의체력바.value = 0;
                }
                if (적순서 == 3)
                {
                    적3의체력바.value = 0;
                }
                alpah = 0;
                break;
            case 9: // 약화 1턴
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 20 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 20 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 20 + alpah;
                }
                alpah = 0;
                break;
            case 10: //마법 14 약화 2턴
                break;
            case 11:
                적순서 = UnityEngine.Random.Range(1, 3);
                if (적순서 == 1)
                {
                    적1의체력바.value = 0;
                }
                if (적순서 == 2)
                {
                    적2의체력바.value = 0;
                }
                if (적순서 == 3)
                {
                    적3의체력바.value = 0;
                }
                break;
            case 12: //상대공격 무효화
                break;
            case 13:
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 60 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 60 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 60 + alpah;
                }
                alpah = 0;
                break;
            case 14:
                if (GameObject.Find("적1") != null)
                {
                    적1의체력바.value -= 20 + alpah;
                }
                if (GameObject.Find("적2") != null)
                {
                    적2의체력바.value -= 20 + alpah;
                }
                if (GameObject.Find("적3") != null)
                {
                    적3의체력바.value -= 20 + alpah;
                }
                alpah = 0;
                break;
            case 15: // 모든몬스터 공격 제한
                A = 0;
                B = 0;
                C = 0;
                데미지 = 0;
                break;
            case 16: // 매지컬 부스터
                alpah = 0;
                break;
            case 17: // 마법 22 상대 데미지 10감소
                break;
            case 18: // 출혈뎀 20
                if (적순서 == 1)
                {
                    적1의체력바.value -= 40 + alpah;
                }
                if (적순서 == 2)
                {
                    적2의체력바.value -= 40 + alpah;
                }
                if (적순서 == 3)
                {
                    적3의체력바.value -= 40 + alpah;
                }
                alpah = 0;
                break;
            case 19:
                if (적순서 == 1)
                {
                    적1의체력바.value -= 60 + alpah;
                    적2의체력바.value -= 30 + alpah;
                    적3의체력바.value -= 30 + alpah;
                }
                if (적순서 == 2)
                {
                    적1의체력바.value -= 30 + alpah;
                    적2의체력바.value -= 60 + alpah;
                    적3의체력바.value -= 30 + alpah;
                }
                if (적순서 == 3)
                {
                    적1의체력바.value -= 30 + alpah;
                    적2의체력바.value -= 30 + alpah;
                    적3의체력바.value -= 60 + alpah;
                }
                alpah = 0;
                break;

            case 20: // 2턴 출혈 30 약화
                if (적순서 == 1)
                {
                    적1의체력바.value -= 50 + alpah;
                }
                if (적순서 == 2)
                {
                    적2의체력바.value -= 50 + alpah;
                }
                if (적순서 == 3)
                {
                    적3의체력바.value -= 50 + alpah;
                }
                alpah = 0;
                break;
            case 21: // 빙결
                if (적순서 == 1)
                {
                    적1의체력바.value -= 50 + alpah;
                }
                if (적순서 == 2)
                {
                    적2의체력바.value -= 50 + alpah;
                }
                if (적순서 == 3)
                {
                    적3의체력바.value -= 50 + alpah;
                }
                alpah = 0;
                break;
            case 22: // 데미지두배 근데 단일공격카드 없죠? ㅋㅋ
                break;
            case 23: 
                if (적순서 == 1)
                {
                    적1의체력바.value -= 60 + alpah;
                }
                if (적순서 == 2)
                {
                    적2의체력바.value -= 60 + alpah;
                }
                if (적순서 == 3)
                {
                    적3의체력바.value -= 60   + alpah;
                }
                alpah = 0;
                break;
            case 24: // 단일공격 + 20
                alpah = 20;
                break;
            case 25: // 방어막 + 10
                alpah = 0;
                데미지 -= 10;
                break;
            case 26: 

                적1의체력바.value -= 70 + alpah;
                int k;
                k = UnityEngine.Random.Range(1, 2);
                if (k == 1)
                {
                    적2의체력바.value -= 70 + alpah;
                }
                if (k == 2)
                {
                    적3의체력바.value -= 70 + alpah;
                }
                alpah = 0;
                break;
            case 27: // 회복력 20 증가
                회복력 = 20;
                break;
            case 28: 
                    나의체력바.maxValue += 10;
                    최대체력 += 10;
                break;
            case 29: 
                    나의체력바.maxValue += 30;
                    최대체력 += 30;
                break;
            case 30: // 매턴체력증가
                    나의체력바.maxValue += 15;
                    최대체력 += 15;
                break;
            case 31:
                회복력 = 30;
                break;
            case 32: // 체력 0 되도 한번안죽는 얼방
                break;
            case 33:
                나의체력바.maxValue += 40;
                최대체력 += 40;
                break;
            case 34: // 매턴 힐
                나의체력바.value += 15 + 회복력;
                회복력 = 0;
                break;
            case 35:  // 담턴 데미지 반감
                나의체력바.value += 10 + 회복력;
                회복력 = 0;
                break;
            case 36:
                if(나의체력바.value <= 10)
                {
                    나의체력바.value += 100 + 회복력;
                    회복력 = 0;
                }
                break;
            case 37:
                나의체력바.maxValue += 45;
                최대체력 += 45;
                break;
            case 38:
                나의체력바.maxValue += 50;
                최대체력 += 50;
                break;
            case 39:
                나의체력바.value += 40 + 회복력;
                회복력 = 0;
                break;
        }
/*
        if(A < 0)
        {
            if (Z != 적1의체력바.value)
            {
                적1의체력바.value += (-A);
            }
        }
        if (B < 0)
        {
            if (X != 적1의체력바.value)
            {
                적1의체력바.value += (-B);
            }
        }
        if (C < 0)
        {
            if (Y != 적1의체력바.value)
            {
                적1의체력바.value += (-C);
            }
        }*/
        float HP = 적1의체력바.value;
        적1체력바.text = string.Format("{0} / 100", HP);
        적1체력바값 = 적1의체력바.value;
        float HP2 = 적2의체력바.value;
        적2체력바.text = string.Format("{0} / 100", HP2);
        적2체력바값 = 적2의체력바.value;
        float HP3 = 적3의체력바.value;
        적3체력바.text = string.Format("{0} / 100", HP3);
        적3체력바값 = 적3의체력바.value;
        float HP4 = 나의체력바.value;
        내체력바.text = HP4.ToString() + " / " + 최대체력.ToString();

        카드확인();
    }

    public void 적1카드()
    {
        if (GameObject.Find("카드1") == null && 카드1체크 == true && GameObject.Find("적1") != null)
        {
            카드능력(age[0],1);
            카드1체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드2") == null && 카드2체크 == true && GameObject.Find("적1") != null)
        {
            카드능력(age[1], 1);
            카드2체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드3") == null && 카드3체크 == true && GameObject.Find("적1") != null)
        {
            카드능력(age[2], 1);
            카드3체크 = false;
            카드체크();

        }
        if (GameObject.Find("카드4") == null && 카드4체크 == true && GameObject.Find("적1") != null)
        {
            카드능력(age[3], 1);
            카드4체크 = false; 
            카드체크();

        }
        if (GameObject.Find("카드5") == null && 카드5체크 == true && GameObject.Find("적1") != null)
        {
            카드능력(age[4], 1);
            카드5체크 = false;
            카드체크();
        }
    }

    public void 적2카드()
    {
        if (GameObject.Find("카드1") == null && 카드1체크 == true && GameObject.Find("적2") != null)
        {
            카드능력(age[0], 2);
            카드1체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드2") == null && 카드2체크 == true && GameObject.Find("적2") != null)
        {
            카드능력(age[1], 2);
            카드2체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드3") == null && 카드3체크 == true && GameObject.Find("적2") != null)
        {
            카드능력(age[2], 2);
            카드3체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드4") == null && 카드4체크 == true && GameObject.Find("적2") != null)
        {
            카드능력(age[3], 2);
            카드4체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드5") == null && 카드5체크 == true && GameObject.Find("적2") != null)
        {
            카드능력(age[4], 2);
            카드5체크 = false;
            카드체크();
        }
    }

    public void 적3카드()
    {
        if (GameObject.Find("카드1") == null && 카드1체크 == true && GameObject.Find("적3") != null)
        {
            카드능력(age[0], 3);
            카드1체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드2") == null && 카드2체크 == true && GameObject.Find("적3") != null)
        {
            카드능력(age[1], 3);
            카드2체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드3") == null && 카드3체크 == true && GameObject.Find("적3") != null)
        {
            카드능력(age[2], 3);
            카드3체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드4") == null && 카드4체크 == true && GameObject.Find("적3") != null)
        {
            카드능력(age[3], 4);
            카드4체크 = false;
            카드체크();
        }
        if (GameObject.Find("카드5") == null && 카드5체크 == true && GameObject.Find("적3") != null)
        {
            카드능력(age[4], 5);
            카드5체크 = false;
            카드체크();
        }
    }

    public void deck()
    {
        int moly;
        카드1체크 = true;
        카드2체크 = true;
        카드3체크 = true;
        카드4체크 = true;
        카드5체크 = true;

        for (int i=0; i<5; i++)
        {
            if (maindeckcheck == 0)
            {
                maindeck = subdeck;
                maindeckcheck = subdeckcheck;
                subdeckcheck = 0;
                subdeck.Initialize();
            }
            moly = UnityEngine.Random.Range(0, maindeckcheck);
            age[i] = maindeck[moly];
            for(int j=moly;j<maindeckcheck;j++)
            {
                maindeck[j] = maindeck[j + 1];
            }
            maindeckcheck--;
        }
        덱트레커.text = string.Format("{0}", maindeckcheck);
        Target.SetActive(true);
        Target2.SetActive(true);
        Target3.SetActive(true);
        Target4.SetActive(true);
        Target5.SetActive(true);

        subdeck1 = true;
        subdeck2 = true;
        subdeck3 = true;
        subdeck4 = true;
        subdeck5 = true;

        alpah = 0;
        블랙홀--;
        적공격();
        턴++;

    }

    public void 랜덤적()
    {
        int 랜능크;
        랜능크 = UnityEngine.Random.Range(1, 15);
        switch (랜능크)
        {
            case 1:
                적이란[1] = 1;
                적이란[2] = 1;
                적이란[3] = 1;
                break;
            case 2:
                적이란[1] = 2;
                적이란[2] = 3;
                적이란[3] = 4;
                break;
            case 3:
                적이란[1] = 2;
                적이란[2] = 1;
                적이란[3] = 1;
                break;
            case 4:
                적이란[1] = 4;
                적이란[2] = 5;
                적이란[3] = 5;
                break;
            case 5:
                적이란[1] = 4;
                적이란[2] = 4;
                적이란[3] = 4;
                break;
            case 6:
                적이란[1] = 5;
                적이란[2] = 5;
                적이란[3] = 6;
                break;
            case 7:
                적이란[1] = 7;
                적이란[2] = 8;
                적이란[3] = 9;
                break;
            case 8:
                적이란[1] = 9;
                적이란[2] = 9;
                적이란[3] = 9;
                break;
            case 9:
                적이란[1] = 10;
                적이란[2] = 11;
                적이란[3] = 11;
                break;
            case 10:
                적이란[1] = 11;
                적이란[2] = 11;
                적이란[3] = 11;
                break;
            case 11:
                적이란[1] = 10;
                적이란[2] = 1;
                적이란[3] = 5;
                break;
            case 12:
                적이란[1] = 6;
                적이란[2] = 7;
                적이란[3] = 10;
                break;
            case 13:
                적이란[1] = 11;
                적이란[2] = 4;
                적이란[3] = 4;
                break;
            case 14:
                적이란[1] = 8;
                적이란[2] = 7;
                적이란[3] = 7;
                break;
            case 15:
                적이란[1] = 8;
                적이란[2] = 9;
                적이란[3] = 9;
                break;
        }

        switch (적이란[1])
        {
            case 1:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터6", typeof(Sprite)) as Sprite;
                break;
            case 7:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터7", typeof(Sprite)) as Sprite;
                break;
            case 8:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터8", typeof(Sprite)) as Sprite;
                break;
            case 9:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터9", typeof(Sprite)) as Sprite;
                break;
            case 10:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터10", typeof(Sprite)) as Sprite;
                break;
            case 11:
                적적적적적1.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터11", typeof(Sprite)) as Sprite;
                break;
        }
        switch (적이란[2])
        {
            case 1:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터6", typeof(Sprite)) as Sprite;
                break;
            case 7:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터7", typeof(Sprite)) as Sprite;
                break;
            case 8:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터8", typeof(Sprite)) as Sprite;
                break;
            case 9:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터9", typeof(Sprite)) as Sprite;
                break;
            case 10:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터10", typeof(Sprite)) as Sprite;
                break;
            case 11:
                적적적적적2.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터11", typeof(Sprite)) as Sprite;
                break;
        }
        switch (적이란[3])
        {
            case 1:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터6", typeof(Sprite)) as Sprite;
                break;
            case 7:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터7", typeof(Sprite)) as Sprite;
                break;
            case 8:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터8", typeof(Sprite)) as Sprite;
                break;
            case 9:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터9", typeof(Sprite)) as Sprite;
                break;
            case 10:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터10", typeof(Sprite)) as Sprite;
                break;
            case 11:
                적적적적적3.GetComponent<Image>().sprite = Resources.Load("images/몬스터/몬스터11", typeof(Sprite)) as Sprite;
                break;
        }
    }

    public void 적공격()
    {
        데미지 = 0;
        if (GameObject.Find("적1") != null)
        {
            if (A <= 0)
            {
                적공방표시1.GetComponent<Image>().sprite = Resources.Load("images/방어상태", typeof(Sprite)) as Sprite;
            }
            else
            {
                적공방표시1.GetComponent<Image>().sprite = Resources.Load("images/공격표시", typeof(Sprite)) as Sprite;
                데미지 += A;
            }
        }
        if (GameObject.Find("적2") != null)
        {
            if (B <= 0)
            {
                적공방표시2.GetComponent<Image>().sprite = Resources.Load("images/방어상태", typeof(Sprite)) as Sprite;
            }
            else
            {
                적공방표시2.GetComponent<Image>().sprite = Resources.Load("images/공격표시", typeof(Sprite)) as Sprite;
                데미지 += B;
            }
        }
        if (GameObject.Find("적3") != null)
        {
            if (C <= 0)
            {
                적공방표시3.GetComponent<Image>().sprite = Resources.Load("images/방어상태", typeof(Sprite)) as Sprite;
            }
            else
            {
                적공방표시3.GetComponent<Image>().sprite = Resources.Load("images/공격표시", typeof(Sprite)) as Sprite;
                데미지 += C;
            }
        }
        나의체력바.value -= 데미지;
        float HP3 = 나의체력바.value;
        내체력바.text = HP3.ToString() + " / " + 최대체력.ToString();

        if (턴 == 1)
        {
            switch (적이란[1])
            {
                case 1:
                    A = 10;
                    break;
                case 2:
                    A = 5;
                    break;
                case 3:
                    A = 5;
                    break;
                case 4:
                    A = 8;
                    break;
                case 5:
                    A = 10;
                    break;
                case 6:
                    A = 40;
                    break;
                case 7:
                    A = -20;
                    break;
                case 8:
                    A = -5;
                    break;
                case 9:
                    A = 20;
                    break;
                case 10:
                    A = 30;
                    break;
                case 11:
                    A = 10;
                    break;
            }
            switch (적이란[2])
            {
                case 1:
                    B = 10;
                    break;
                case 2:
                    B = 5;
                    break;
                case 3:
                    B = 5;
                    break;
                case 4:
                    B = 8;
                    break;
                case 5:
                    B = 10;
                    break;
                case 6:
                    B = 40;
                    break;
                case 7:
                    B = -20;
                    break;
                case 8:
                    B = -5;
                    break;
                case 9:
                    B = 20;
                    break;
                case 10:
                    B = 30;
                    break;
                case 11:
                    B = 10;
                    break;
            }
            switch (적이란[3])
            {
                case 1:
                    C = 10;
                    break;
                case 2:
                    C = 5;
                    break;
                case 3:
                    C = 5;
                    break;
                case 4:
                    C = 8;
                    break;
                case 5:
                    C = 10;
                    break;
                case 6:
                    C = 40;
                    break;
                case 7:
                    C = -20;
                    break;
                case 8:
                    C = -5;
                    break;
                case 9:
                    C = 20;
                    break;
                case 10:
                    C = 30;
                    break;
                case 11:
                    C = 10;
                    break;
            }
        }
        if (턴 == 2)
        {
            switch(적이란[1])
            {
                case 1:
                    A = 30;
                    break;
                case 2:
                    A = 30;
                    break;
                case 3:
                    A = 50;
                    break;
                case 4:
                    A = 40;
                    break;
                case 5:
                    A = -20;
                    break;
                case 6:
                    A = -20;
                    break;
                case 7:
                    A = -30;
                    break;
                case 8:
                    A = -20;
                    break;
                case 9:
                    A = 60;
                    break;
                case 10:
                    A = 70;
                    break;
                case 11:
                    A = 70;
                    break;
            }
            switch (적이란[2])
            {
                case 1:
                    B = 30;
                    break;
                case 2:
                    B = 30;
                    break;
                case 3:
                    B = 50;
                    break;
                case 4:
                    B = 40;
                    break;
                case 5:
                    B = -20;
                    break;
                case 6:
                    B = -20;
                    break;
                case 7:
                    B = -30;
                    break;
                case 8:
                    B = -20;
                    break;
                case 9:
                    B = 60;
                    break;
                case 10:
                    B = 70;
                    break;
                case 11:
                    B = 70;
                    break;
            }
            switch (적이란[3])
            {
                case 1:
                    C = 30;
                    break;
                case 2:
                    C = 30;
                    break;
                case 3:
                    C = 50;
                    break;
                case 4:
                    C = 40;
                    break;
                case 5:
                    C = -20;
                    break;
                case 6:
                    C = -20;
                    break;
                case 7:
                    C = -30;
                    break;
                case 8:
                    C = -20;
                    break;
                case 9:
                    C = 60;
                    break;
                case 10:
                    C = 70;
                    break;
                case 11:
                    C = 70;
                    break;
            }
        }
        if(턴 == 3)
        {
            switch (적이란[1])
            {
                case 1:
                    A = 20;
                    break;
                case 2:
                    A = 20;
                    break;
                case 3:
                    A = 20;
                    break;
                case 4:
                    A = 30;
                    break;
                case 5:
                    A = -20;
                    break;
                case 6:
                    A = -20;
                    break;
                case 7:
                    A = 30;
                    break;
                case 8:
                    A = 50;
                    break;
                case 9:
                    A = -10;
                    break;
                case 10:
                    A = -10;
                    break;
                case 11:
                    A = -10;
                    break;
            }
            switch (적이란[2])
            {
                case 1:
                    B = 20;
                    break;
                case 2:
                    B = 20;
                    break;
                case 3:
                    B = 20;
                    break;
                case 4:
                    B = 30;
                    break;
                case 5:
                    B = -20;
                    break;
                case 6:
                    B = -20;
                    break;
                case 7:
                    B = 30;
                    break;
                case 8:
                    B = 50;
                    break;
                case 9:
                    B = -10;
                    break;
                case 10:
                    B = -10;
                    break;
                case 11:
                    B = -10;
                    break;
            }
            switch (적이란[3])
            {
                case 1:
                    C = 20;
                    break;
                case 2:
                    C = 20;
                    break;
                case 3:
                    C = 20;
                    break;
                case 4:
                    C = 30;
                    break;
                case 5:
                    C = -20;
                    break;
                case 6:
                    C = -20;
                    break;
                case 7:
                    C = 30;
                    break;
                case 8:
                    C = 50;
                    break;
                case 9:
                    C = -10;
                    break;
                case 10:
                    C = -10;
                    break;
                case 11:
                    C = -10;
                    break;
            }
        }
        if (턴 == 4)
        {
            switch (적이란[1])
            {
                case 1:
                    A = 30;
                    break;
                case 2:
                    A = 30;
                    break;
                case 3:
                    A = 10;
                    break;
                case 4:
                    A = 10;
                    break;
                case 5:
                    A = 10;
                    break;
                case 6:
                    A = 100;
                    break;
                case 7:
                    A = 50;
                    break;
                case 8:
                    A = 20;
                    break;
                case 9:
                    A = 30;
                    break;
                case 10:
                    A = 70;
                    break;
                case 11:
                    A = 70;
                    break;
            }
            switch (적이란[2])
            {
                case 1:
                    B = 30;
                    break;
                case 2:
                    B = 30;
                    break;
                case 3:
                    B = 10;
                    break;
                case 4:
                    B = 10;
                    break;
                case 5:
                    B = 10;
                    break;
                case 6:
                    B = 100;
                    break;
                case 7:
                    B = 50;
                    break;
                case 8:
                    B = 20;
                    break;
                case 9:
                    B = 30;
                    break;
                case 10:
                    B = 70;
                    break;
                case 11:
                    B = 70;
                    break;
            }
            switch (적이란[3])
            {
                case 1:
                    C = 30;
                    break;
                case 2:
                    C = 30;
                    break;
                case 3:
                    C = 10;
                    break;
                case 4:
                    C = 10;
                    break;
                case 5:
                    C = 10;
                    break;
                case 6:
                    C = 100;
                    break;
                case 7:
                    C = 50;
                    break;
                case 8:
                    C = 20;
                    break;
                case 9:
                    C = 30;
                    break;
                case 10:
                    C = 70;
                    break;
                case 11:
                    C = 70;
                    break;
            }
        }
        if (턴 == 5)
        {
            switch (적이란[1])
            {
                case 1:
                    A = 10;
                    break;
                case 2:
                    A = 10;
                    break;
                case 3:
                    A = 10;
                    break;
                case 4:
                    A = 50;
                    break;
                case 5:
                    A = 10;
                    break;
                case 6:
                    A = 10;
                    break;
                case 7:
                    A = 10;
                    break;
                case 8:
                    A = 20;
                    break;
                case 9:
                    A = 20;
                    break;
                case 10:
                    A = 30;
                    break;
                case 11:
                    A = 500;
                    break;
            }
            switch (적이란[2])
            {
                case 1:
                    B = 10;
                    break;
                case 2:
                    B = 10;
                    break;
                case 3:
                    B = 10;
                    break;
                case 4:
                    B = 50;
                    break;
                case 5:
                    B = 10;
                    break;
                case 6:
                    B = 10;
                    break;
                case 7:
                    B = 10;
                    break;
                case 8:
                    B = 20;
                    break;
                case 9:
                    B = 20;
                    break;
                case 10:
                    B = 30;
                    break;
                case 11:
                    B = 500;
                    break;
            }
            switch (적이란[3])
            {
                case 1:
                    C = 10;
                    break;
                case 2:
                    C = 10;
                    break;
                case 3:
                    C = 10;
                    break;
                case 4:
                    C = 50;
                    break;
                case 5:
                    C = 10;
                    break;
                case 6:
                    C = 10;
                    break;
                case 7:
                    C = 10;
                    break;
                case 8:
                    C = 20;
                    break;
                case 9:
                    C = 20;
                    break;
                case 10:
                    C = 30;
                    break;
                case 11:
                    C = 500;
                    break;
            }
        }
        if(턴 == 5)
        {
            턴 = 1;
        }


        적1공격텍스트.text = string.Format("{0}", A);
        적2공격텍스트.text = string.Format("{0}", B);
        적3공격텍스트.text = string.Format("{0}", C);
        데미지 = 0;
        if (GameObject.Find("적1") != null)
        {
            if (A <= 0)
            {
                적공방표시1.GetComponent<Image>().sprite = Resources.Load("images/방어상태", typeof(Sprite)) as Sprite;
            }
            else
            {
                적공방표시1.GetComponent<Image>().sprite = Resources.Load("images/공격표시", typeof(Sprite)) as Sprite;
                데미지 += A;
            }
        }
        if (GameObject.Find("적2") != null)
        {
            if (B <= 0)
            {
                적공방표시2.GetComponent<Image>().sprite = Resources.Load("images/방어상태", typeof(Sprite)) as Sprite;
            }
            else
            {
                적공방표시2.GetComponent<Image>().sprite = Resources.Load("images/공격표시", typeof(Sprite)) as Sprite;
                데미지 += B;
            }
        }
        if (GameObject.Find("적3") != null)
        {
            if (C <= 0)
            {
                적공방표시3.GetComponent<Image>().sprite = Resources.Load("images/방어상태", typeof(Sprite)) as Sprite;
            }
            else
            {
                적공방표시3.GetComponent<Image>().sprite = Resources.Load("images/공격표시", typeof(Sprite)) as Sprite;
                데미지 += C;
            }
        }
    }

    public void GameOver()
    {
        게임오버.SetActive(true);
    }

    public void 게임오버게임오버()
    {
        SceneManager.LoadSceneAsync("01 메인메뉴");
    }

    public void 뽑기1()
    {
        subdeck[subdeckcheck] = 뽑기카드[1];
        subdeckcheck++;
        plus_card();
    }

    public void 뽑기2()
    {
        subdeck[subdeckcheck] = 뽑기카드[2];
        subdeckcheck++;
        plus_card();
    }

    public void 뽑기3()
    {
        subdeck[subdeckcheck] = 뽑기카드[3];
        subdeckcheck++;
        plus_card();
    }

    public void 건너뛰기()
    {
        plus_card();
    }

    public void plus_card()
    {
        if(활성화 == 7)
        {
            SceneManager.LoadSceneAsync("04 상점");

        }
        지도.SetActive(true);

        카드1체크 = false;
        카드2체크 = false;
        카드3체크 = false;
        카드4체크 = false;
        카드5체크 = false;
        카드체크();
        deck();
    }

    public void Back_to_the_Cave()
    {
        뽑기뽑기();
        랜덤적();
        지도.SetActive(false);
        적1체력바파괴.SetActive(true);
        적1.SetActive(true);
        적2체력바파괴.SetActive(true);
        적2.SetActive(true);
        적3체력바파괴.SetActive(true);
        적3.SetActive(true);
        적1공격파괴.SetActive(true);
        적1공격.SetActive(true);
        적2공격파괴.SetActive(true);
        적2공격.SetActive(true);
        적3공격파괴.SetActive(true);
        적3공격.SetActive(true);

        적1체력바값 = 100;
        적2체력바값 = 100;
        적3체력바값 = 100;
        적1의체력바.value = 100;
        적2의체력바.value = 100;
        적3의체력바.value = 100;
        카드뽑기.SetActive(false);
        gameover = 3;
        턴 = 1;
        float HP = 적1의체력바.value;
        적1체력바.text = string.Format("{0} / 100", HP);
        적1체력바값 = 적1의체력바.value;
        float HP2 = 적2의체력바.value;
        적2체력바.text = string.Format("{0} / 100", HP2);
        적2체력바값 = 적2의체력바.value;
        float HP3 = 적3의체력바.value;
        적3체력바.text = string.Format("{0} / 100", HP3);
        적3체력바값 = 적3의체력바.value;
        활성화++;
    }

    public void 힐()
    {
        나의체력바.maxValue = 300;
        나의체력바.value = 300;
        if(최대체력 <= 300)
        {
            최대체력 = 300;
        }
        float HP3 = 나의체력바.value;
        내체력바.text = HP3.ToString() + " / " + 최대체력.ToString();
        활성화++;
    }
}