using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageProgress : MonoBehaviour
{
    public static int enemyDeathCount = 0;
    public static int bossDeathCount = 0;
    public int enemyDeafeatingCondition = 20;
    public int bossDeafeatingCondition = 0;

    [SerializeField] TMP_Text gameConditionText;

    void Awake()
    {
        enemyDeathCount = 0;
        bossDeathCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bossDeafeatingCondition == 0)
        {
            gameConditionText.text = "Enemies deafeated Count: " + enemyDeathCount + "/" + enemyDeafeatingCondition;
        }
        else
        {
            gameConditionText.text = "Boss deafeated Count: " + bossDeathCount + "/" + bossDeafeatingCondition;
        }
        
    }
}
