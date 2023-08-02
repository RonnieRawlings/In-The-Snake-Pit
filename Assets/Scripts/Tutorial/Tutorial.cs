using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject moveText;
    public GameObject attackText;
    public GameObject dashText;
    public GameObject healthText;
    public GameObject trapText;
    public GameObject completeText;
    public GameObject bowText;
    public GameObject sword;
    public GameObject eventSystem;
    public PlayerBow bow;
    public TopDownMovement trapCheck;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject healthCrystals;
    public GameObject spikeTraps;

    public int tutorialStep = 1;
    public int stepProgress = 0;

    public Text textUI;
    public Text countUI;
    public Text crystalCountUI;
    public Text bowFireCountUI;

    public Animator animator;
    public GameObject movementTrigger;
    public GameObject triggerPanel;


    private void Start()
    {
        tutorialStep = 1;
        Time.timeScale = 1;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonUp("Fire2"))
        {
            if (tutorialStep == 2)
            {
                if (stepProgress == 2)
                {
                    animator.SetTrigger("StepComplete");
                    dashText.SetActive(false);
                    trapText.SetActive(true);
                    tutorialStep += 1;
                    stepProgress = 0;
                    textUI.enabled = false;
                    spikeTraps.SetActive(true);
                }
                else
                {
                    stepProgress += 1;
                }
            }
        }

        if (tutorialStep == 3)
        {
            if (trapCheck.trapsTriggered >=6)
            {
                animator.SetTrigger("StepComplete");
                trapText.SetActive(false);
                bowText.SetActive(true);
                bowFireCountUI.enabled = true;
                tutorialStep += 1;
                stepProgress = 0;
                textUI.enabled = false;
                bowFireCountUI.enabled = true;
                bow.fireCount = 0;
                spikeTraps.SetActive(false);
            }
        }

        if (tutorialStep == 4)
            {
                if (bow.fireCount == 3)
                {
                    animator.SetTrigger("StepComplete");
                    bowText.SetActive(false);
                    attackText.SetActive(true);
                    bowFireCountUI.enabled = false;
                    countUI.enabled = true;
                    tutorialStep += 1;
                    stepProgress = 0;
                    enemy1.SetActive(true);
                    enemy2.SetActive(true);
                    enemy3.SetActive(true);
                }
            }

        if (tutorialStep == 5)
            {
                if (eventSystem.GetComponent<ThumbConditions>().KillCount >= 3)
                {
                    animator.SetTrigger("StepComplete");
                    attackText.SetActive(false);
                    healthText.SetActive(true);
                    countUI.enabled = false;
                    crystalCountUI.enabled = true;
                    tutorialStep += 1;
                    stepProgress = 0;
                    healthCrystals.SetActive(true);
                    eventSystem.GetComponent<ThumbConditions>().KillCount = 0;
                }
            }

        if (tutorialStep == 6)
        {
            if (sword.GetComponent<SwordCombat>().crystalCount == 2)
            {
                animator.SetTrigger("StepComplete");
                healthText.SetActive(false);
                crystalCountUI.enabled = false;
                tutorialStep += 1;
                stepProgress = 0;
                StartCoroutine(TutorialComplete());
            }
        }

        string progressText = stepProgress.ToString() + "/3";
        textUI.text = progressText;

        string bowFireText = bow.fireCount.ToString() + "/3";
        bowFireCountUI.text = bowFireText;

        string killText = eventSystem.GetComponent<ThumbConditions>().KillCount.ToString() + "/3";
        countUI.text = killText;

        string crystalText = sword.GetComponent<SwordCombat>().crystalCount.ToString() + "/2";
        crystalCountUI.text = crystalText;

        IEnumerator TutorialComplete()
        {
            textUI.enabled = false;
            countUI.enabled = false;
            completeText.SetActive(true);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void MovementStep()
    {
        movementTrigger.SetActive(false);
        triggerPanel.SetActive(false);
        animator.SetTrigger("StepComplete");
        moveText.SetActive(false);
        dashText.SetActive(true);
        textUI.enabled = true;
        tutorialStep += 1;
        stepProgress = 0;
    }
}
