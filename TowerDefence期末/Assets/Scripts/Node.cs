using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public GameObject spawnEffect;
    ShopSystem notEnoughMoneyText;
    Shake shake;
    public SpriteRenderer spr;
    private Color currentColor;
    public Color targetColor;

    private GameObject currentObject;

    // check player dead or not
    public LayerMask playerLayer;
    public float playerLayerRange;
    private bool canBeBuild = true;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Shake>();
        spr = GetComponent<SpriteRenderer>();
        currentColor = spr.color;
        currentObject = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // cancel build 
        {
            GameManager.Instance.toolToBuild = null;
        }

        CheckNodeIsCanBuildAfterEnemyDead();
    }

    private void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !canBeBuild)
        {
            return;
        }

        if (GameManager.Instance.toolToBuild != null && currentObject == null)
        {
            spr.color = targetColor;

            // build
            if (Input.GetMouseButtonDown(0))
            {
                if (ShopSystem.CanBuild())
                {
                    PlaceTool();
                }
                else
                {
                    shake.CameraShake();
                    // Show not enought money UI
                    shake.ShowNotEnoughMoney();
                    // sound
                    AudioManager.Play(Sound.MoneyNotEnoughSound);
                }
            }
            else
            {
                return;
            }
        }
        return;

    }

    private void OnMouseExit()
    {
        spr.color = currentColor;
    }

    private void PlaceTool()
    {
        canBeBuild = false;
        ShopSystem.TotalMoney -= ShopSystem.priceToReduce;
        // Spawn Effect
        Instantiate(spawnEffect, new Vector3(transform.position.x, transform.position.y, -10f), Quaternion.identity);
        // Sound Effect
        AudioManager.Play(Sound.PlaceToolSound);
        Instantiate(GameManager.Instance.GetToolToBuild(), transform.position, Quaternion.identity);
    }

    private void CheckNodeIsCanBuildAfterEnemyDead()
    {
        /*
        if (currentObject.GetComponent<IPlayer>().HP <= 0)
        {
            currentObject = null;
            collider.enabled = true;
        }
        */
        Collider2D player = Physics2D.OverlapCircle(transform.position, playerLayerRange, playerLayer);
        if (player == null)
        {
            canBeBuild = true;
        }
        else if (player != null)
        {
            Debug.Log(player.name);
            canBeBuild = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerLayerRange);
    }
}
