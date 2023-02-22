using UnityEngine;
using UnityEngine.UI;

public class DifficultyLevelFactor : MonoBehaviour
{
    public float dlf = 5.0f;

    public Text dlfText;

    // Update is called once per frame
    void Update()
    {
        dlfText.text =dlf.ToString();
    }
}
