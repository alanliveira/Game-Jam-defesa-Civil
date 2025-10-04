using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public WaterRise waterObject;
    public Scrollbar panicBar;

    public TextMeshProUGUI infoText;

    void Update()
    {
        var porcentPanic = waterObject.GetWaterRisePercent();
        panicBar.size = 1 - porcentPanic;

        infoText.text = $"{porcentPanic * 100:F0}%";

    }
}
