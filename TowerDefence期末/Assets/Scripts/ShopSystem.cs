using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class ShopSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Sprite Section
    public SpriteRenderer cursorSpr;
    private Sprite currentSprite;
    public Sprite sliperSprite;
    public Sprite insecticideSprite;
    public Sprite mouseDrugSprite;
    public Sprite swatterSprite;

    GameManager buildManager;
    public static float TotalMoney;
    public Text TotalMoneyText;
    Animator ani;

    public float slipperPrice;
    public float insecticidePrice;
    public float mouseDrugPrice;
    public float swatterPrice;
    public static float priceToReduce;
    Vector2 mousePos;


    // Price Text UI
    public TextMeshProUGUI slipperText;
    public TextMeshProUGUI insecticideText;
    public TextMeshProUGUI swatterText;
    public TextMeshProUGUI mouseDrugTetxt;

    void Awake()
    {
        currentSprite = cursorSpr.sprite;
    }

    void Start()
    {
        TotalMoney = 0f;
        buildManager = GameManager.Instance;
        ani = GetComponent<Animator>();

        cursorSpr.color = new Color(255, 255, 255, 0.3f);
    }

    void Update()
    {
        // increasing money
        TotalMoney += Time.deltaTime;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorSpr.GetComponent<Transform>().position = mousePos;
        UI();

        // back cursor sprite to empty if doesn't choose anything
        if (buildManager.toolToBuild == null)
        {
            cursorSpr.sprite = currentSprite;
        }
    }

    public void PurchaseSlipperTool()
    {
        buildManager.SetToolToBuild(GameManager.Instance.sliperPre);
        priceToReduce = slipperPrice;
        cursorSpr.sprite = sliperSprite;
    }

    public void PurchaseInsecticideTool()
    {
        buildManager.SetToolToBuild(GameManager.Instance.insecticidePre);
        priceToReduce = insecticidePrice;
        cursorSpr.sprite = insecticideSprite;
    }

    public void PurchaseMouseDrugTool()
    {
        buildManager.SetToolToBuild(GameManager.Instance.mouseDrugPre);
        priceToReduce = mouseDrugPrice;
        cursorSpr.sprite = mouseDrugSprite;
    }

    public void PurchaseSwatterTood()
    {
        buildManager.SetToolToBuild(GameManager.Instance.swatterPre);
        priceToReduce = swatterPrice;
        cursorSpr.sprite = swatterSprite;
    }

    public static bool CanBuild()
    {
        if (TotalMoney >= priceToReduce)
        {
            return true;
        }
        return false;
    }

    void UI()
    {
        // Money Text UI
        TotalMoneyText.text = TotalMoney.ToString("0.00");

        slipperText.text = slipperPrice.ToString();
        swatterText.text = swatterPrice.ToString();
        insecticideText.text = insecticidePrice.ToString();
        mouseDrugTetxt.text = mouseDrugPrice.ToString();
    }

    // UI Animation
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Play(Sound.OpenPageSound);
        ani.SetBool("open", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AudioManager.Play(Sound.ClosePageSound);
        ani.SetBool("open", false);
    }
}
