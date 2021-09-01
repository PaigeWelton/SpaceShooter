using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBase : MonoBehaviour
{
    [SerializeField] protected Animator dialogAnimator;
    [SerializeField] protected string dialogIntroTrigger = "Intro";
    [SerializeField] protected string dialogOutroTrigger = "Outro";

    private float timeToDestroy = 0.5f;

    public void OpenDialog()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            dialogAnimator = GetComponent<Animator>();
            dialogAnimator.SetTrigger(dialogIntroTrigger);
        }
        else
        {
            dialogAnimator = GetComponent<Animator>();
            dialogAnimator.SetTrigger(dialogIntroTrigger);
        }
    }

    public virtual void CloseDialog()
    {
        dialogAnimator.SetTrigger(dialogOutroTrigger);
        StartCoroutine(DestroyDialog());
    }

    private IEnumerator DestroyDialog()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
