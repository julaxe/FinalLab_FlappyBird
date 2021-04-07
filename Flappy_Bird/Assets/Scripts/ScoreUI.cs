using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI textPro;
    // Start is called before the first frame update
    void Start()
    {
        textPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textPro.text = "SCORE: " + ScoreManager.Score;
    }
}
