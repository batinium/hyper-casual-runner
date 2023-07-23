using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform runnersParent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    { //we will get the runners parent loop through all the runers, get each animator and set current animation to run animation.
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runner = runnersParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Runner>().GetAnimator();
            runnerAnimator.Play("Run");
        }
    }
    public void Idle()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runner = runnersParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Runner>().GetAnimator();
            runnerAnimator.Play("Idle");
        }
    }
}
