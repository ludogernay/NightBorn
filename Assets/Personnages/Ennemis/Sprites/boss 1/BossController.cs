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

        Color textColor = Color.red;

        float percentage = currentHP / maxHP;
        if (percentage <= 0.5f)
        {
            textColor = Color.Lerp(Color.red, Color.yellow, (0.5f - percentage) * 2);
        }

        hpText.color = textColor;
    }
}
