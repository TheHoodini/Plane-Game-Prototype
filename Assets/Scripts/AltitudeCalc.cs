using TMPro;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this for the Slider

public class AltitudeCalc : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI altitudeText;
    public Slider altitudeSlider; // Reference to the Slider

    public int minY = -40;
    public int maxY = 40;

    void Start()
    {
        // Set the slider's minimum and maximum values based on your altitude range
        altitudeSlider.minValue = 1000f; // Minimum altitude
        altitudeSlider.maxValue = 41000f; // Maximum altitude
    }

    void Update()
    {
        float playerY = player.position.y;

        // Calculate altitude based on Y position
        float altitude;

        if (playerY < minY)
        {
            altitude = 1000f; // If Y is less than -40, set altitude to 1000
        }
        else if (playerY > maxY)
        {
            altitude = 41000f; // If Y is greater than 40, set altitude to 41000
        }
        else
        {
            // Linear interpolation between the two points
            altitude = Mathf.Lerp(1000f, 41000f, (playerY + Mathf.Abs(minY)) / (Mathf.Abs(minY) + maxY));
        }

        // Convert altitude to an integer
        int altitudeInt = Mathf.RoundToInt(altitude);

        // Update the UI text
        altitudeText.text = "ALTITUDE\n" + altitudeInt + "ft";

        // Update the slider's value
        altitudeSlider.value = altitude;
    }
}
