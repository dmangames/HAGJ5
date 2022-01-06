using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvidenceHand : MonoBehaviour
{
    public string evidenceResult;
    public TextMeshProUGUI tmpText;

    // Start is called before the first frame update
    void Start()
    {
        tmpText.text = evidenceResult;

        if (!GameEngine.Instance.trailHasBeenCalcAlready)
        {
            GameEngine.Instance.CalcTrialResult();
            evidenceResult = GameEngine.Instance.GetTrialResult();
            tmpText.text = evidenceResult;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
