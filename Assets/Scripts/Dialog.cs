using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject windowDialog;
    public TextMeshProUGUI textDialog;
    public string[] message;
    public int numberDialog = 0;
    public Button button;

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
            audioSource.clip = audioClips[numberDialog];
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
        numberDialog = 0;
        button.onClick.RemoveAllListeners();
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        audioSource.clip = audioClips[numberDialog];       
        audioSource.Play();
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
        }
    }
}
