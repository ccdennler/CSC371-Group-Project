using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public Camera gameCamera;
    private int lives;

    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    Vector3 originalPosition = new Vector3(-9.8f, 0, -3.2f);

    private void Start()
    {
        lives = PlayerMovement.lives;
        caughtAudio = GetComponent<AudioSource>();
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
        lives--;
        PlayerMovement.lives--;
    }

    void Update ()
    {
        if (m_IsPlayerCaught)
        {
            if (PlayerMovement.lives == 0)
                EndLevel(caughtBackgroundImageCanvasGroup, false, caughtAudio);
            else
                EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                player.transform.position = originalPosition;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                m_IsPlayerCaught = false;
                m_HasAudioPlayed = false;
                m_Timer = 0;
                imageCanvasGroup.alpha = 0f;
            }
            else
            {
                PlayerMovement.lives = 9;
                SceneManager.LoadScene(0);
            }
        }
    }
}
