using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    private Animator playerAnim;
    [SerializeField]
    private Player player;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>(); 
    }
    void Update()
    {
        playerAnim.SetBool("IsWalking", player.IsWalking());
    }
}
