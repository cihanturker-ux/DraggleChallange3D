using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    public static CinemachineSwitcher Instance { get; private set; }
    
    private Animator animator;
    private bool isOverworldCamEnabled = true;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void SwitchCamera()
    {
        if (isOverworldCamEnabled)
        {
            animator.Play("VC_Fever");
        }
        else
        {
            animator.Play("VC_Overworld");
        }

        isOverworldCamEnabled = !isOverworldCamEnabled;
    }
}
