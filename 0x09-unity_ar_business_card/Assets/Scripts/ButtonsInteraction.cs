using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsInteraction : MonoBehaviour
{
    [SerializeField] private TMP_Text email;
    private string twitter = "https://twitter.com/EddySZH";
    private string github = "https://github.com/Eddyszh";
    private string linkedin = "https://www.linkedin.com/in/eddyszh/";

    /// <summary>
    /// Open the spicified social media when button is pressed
    /// </summary>
    /// <param name="source"></param>
    public void GetButton(string source)
    {
        switch (source)
        {
            case "email":
                email.enabled = email.enabled == true ? false : true;
                break;
            case "twitter":
                Application.OpenURL(twitter);
                break;
            case "github":
                Application.OpenURL(github);
                break;
            case "linkedin":
                Application.OpenURL(linkedin);
                break;
            default:
                break;
        }
    }
}
