using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int maxHP;
    int currentHP;
    [SerializeField] TextMeshPro hpText;

    void Start(){
        currentHP = maxHP;
        UpdateHPView();
    }

    public void takeDamage(int damage){
        currentHP = Mathf.Max(currentHP - damage, 0);
        UpdateHPView();
    }

    void UpdateHPView(){
        hpText.text = "HP: " + currentHP.ToString();

        Color textColor = Color.green;

        float percentage = (float)currentHP / maxHP;
        if (percentage <= 0.5f)
        {
            textColor = Color.Lerp(Color.yellow, Color.red, (0.5f - percentage) * 2);
        }

        hpText.color = textColor;
    }
}
