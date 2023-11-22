using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistiques
{
    public enum StatistiqueType
    //Statistiques de base
    {
        HP,
        Damage,
        Duration,
        HitRate,
        Stunnable,
        Speed
    }

    public StatistiqueType maStatistiques {get; set;}

    // Autres méthodes et membres de la classe, si nécessaire
}