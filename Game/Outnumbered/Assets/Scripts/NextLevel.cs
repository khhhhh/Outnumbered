using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    public Animator animator;
    public int ZombiesCount = 7;

    public void killZombie() 
    {
        ZombiesCount--;
        if(ZombiesCount == 0)
        {
           StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
