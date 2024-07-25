using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float temp = playerCurrentHealth.initialValue / 2;
        Debug.Log("temp: " + temp);
        System.Console.WriteLine("Testing");
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            Debug.Log("i: " + i);
            Debug.Log("heartContainers.initialValue: " + heartContainers.initialValue);
            if (i <= temp - 1)
            {
                // Full Heart
                hearts[i].sprite = fullHeart;
            } else if (i >= temp)
            {
                // Empty Heart
                hearts[i].sprite = emptyHeart;
            } else
            {
                // Half Heart
                hearts[i].sprite = halfHeart;
            }
        }
    }
}
