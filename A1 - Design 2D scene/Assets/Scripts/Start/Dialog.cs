using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    
    private int index;
    private AudioSource source;

    public GameObject continueButton;

    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Type());    
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }    
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index == sentences.Length - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        source.Play();
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            source.Stop();
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
