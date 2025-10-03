using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointHUD : MonoBehaviour {
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI winText;

    int points = 0;

    private void Start() {
        winText.gameObject.SetActive(false);
    }

    private void Awake() {
        UpdateHUD();
    }

    private void Update() {
        if (points >= 5) {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public int Points {
        get {
            return points;
        }

        set {
            points = value;
            UpdateHUD();
        }
    }

    private void UpdateHUD() {
        pointText.text = points.ToString();

    }

}
