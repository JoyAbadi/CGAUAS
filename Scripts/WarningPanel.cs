using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    // Reference to the History Panel
    public GameObject panelHistory;

    // Function to hide the current panel and show the History Panel
    public void ShowHistoryPanel()
    {
        // Deactivate the current panel (Warning Panel)
        gameObject.SetActive(false);

        // Activate the History Panel
        if (panelHistory != null)
        {
            panelHistory.SetActive(true);
        }
        else
        {
            Debug.LogError("Panel History reference is not assigned.");
        }
    }
}
