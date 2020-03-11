using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public Camera gameCamera;
    public Vector3 startPos;

    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    private void Start()
    {
        caughtAudio = GetComponent<AudioSource>();
        startPos = player.transform.position;
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
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
                player.transform.position = startPos;
                //player.transform.rotation = Quaternion.Euler(0, 0, 0);
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
