using System.Collections;
using UnityEngine;

public class FeverController : MonoBehaviour
{
    public static FeverController instance;

    public int requiredFever = 5;
    
    [HideInInspector] public int currentFever = 0;
    [HideInInspector] public bool isActivated = false;

    private void Awake()
    {
        instance = this;
    }
    
    public void IncreaseFever()
    {
        if (currentFever < requiredFever && !isActivated)
        {
            currentFever++;
            UIController.Instance.UpdateFeverBar(currentFever, requiredFever);
            
            if (currentFever == requiredFever)
            {
                StartCoroutine(ActivateFever());
            }
        }
    }

    public IEnumerator ActivateFever()
    {
        BeforeFeverIsActivated();
        yield return new WaitForSecondsRealtime(3f);
        AfterFeverIsActivated();
    }

    private void BeforeFeverIsActivated()
    {
        isActivated = true;
        CinemachineSwitcher.Instance.SwitchCamera();
    }

    private void AfterFeverIsActivated()
    {
        isActivated = false;
        CinemachineSwitcher.Instance.SwitchCamera();
        
        currentFever = 0;
        UIController.Instance.ResetFeverBar();
    }
}
