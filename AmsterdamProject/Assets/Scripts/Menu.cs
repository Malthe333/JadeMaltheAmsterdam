using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.UI;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Image image;

    public GameObject imageblack;
    public float fadeTime = 2f;

    // Update is called once per frame
    void Update()
    {
        // Grab the current color
        Color c = image.color;

        // Lerp from current to transparent
        c = Color.Lerp(c, Color.clear, Time.deltaTime / fadeTime);

        // Assign the new color back
        image.color = c;
        
        if (c.a <= 0.2f)
        {
            // Just set the color to clear and disable this script
            imageblack.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        
    }
}
