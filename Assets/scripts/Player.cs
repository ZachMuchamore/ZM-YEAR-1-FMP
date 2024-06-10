using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int HP = 100;

    public GameObject bloodyScreen;

    public TextMeshProUGUI playerHealthUI;
    public GameObject gameOverUI;

    public bool isDead;

    private void Start()
    {
        playerHealthUI.text = $"Health: {HP}";
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            print("Player Dead");
            isDead = true;
            PlayerDead();
        }
        else
        {
            print("Player Hit");
            playerHealthUI.text = $"Health: {HP}";

            StartCoroutine(BloodyScreenEffect());

        }
    }

    private void PlayerDead()
    {
        GetComponent<MouseMovement>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;

        playerHealthUI.gameObject.SetActive(false);

        GetComponentInChildren<Animator>().enabled = true;

        GetComponent<ScreenFader>().StartFade();
        StartCoroutine(ShowGameOverUI());
    }

    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForSeconds(3f);
        gameOverUI.gameObject.SetActive(true);

    }

    private IEnumerator BloodyScreenEffect()
    {
         if (bloodyScreen.activeInHierarchy == false)
         {
             bloodyScreen.SetActive(true);
         }

         var image = bloodyScreen.GetComponentInChildren<Image>();

         // Set the initial alpha value to 1 (fully visible).
         Color startColor = image.color;
         startColor.a = 1f;
         image.color = startColor;

         float duration = 2f;
         float elapsedTime = 0f;

         while (elapsedTime < duration)
         {
             // Calculate the new alpha value using Lerp.
             float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

             // Update the color with the new alpha value.
             Color newColor = image.color;
             newColor.a = alpha;
             image.color = newColor;

             // Increment the elapsed time.
             elapsedTime += Time.deltaTime;

             yield return null; ; // Wait for the next frame.
         }

         if (bloodyScreen.activeInHierarchy)
         {
             bloodyScreen.SetActive(false);
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            if (isDead == false)
            {
                TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
            }
            
        }
    }


}
