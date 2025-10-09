using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMove playerMove;
    private void Awake()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        var playerMoves = FindObjectsOfType<PlayerMove>();
        var index = playerInput.playerIndex;
        playerMove = playerMoves.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }
    public void OnMove(CallbackContext context)
    {
        if(playerMove != null)
        {
            playerMove.Moving(context.ReadValue<Vector2>());
        }
    }
    public void OnHighAttack(CallbackContext context)
    {
        if(playerMove != null)
        {
            if(playerMove.IsBusy() == false)
            {
                playerMove.AttackHigh();              
            }            
        }
    }
    public void OnLowAttack(CallbackContext context)
    {
        if(playerMove != null)
        {
            if(playerMove.IsBusy() == false)
            {
                playerMove.AttackLow();
            }
        }
    }
    public void OnHighBlock(CallbackContext context)
    {
        if(playerMove != null)
        {
            if(playerMove.IsBusy() == false)
            {
                playerMove.BlockHigh();
            }
        }
    }
    public void OnLowBlock(CallbackContext context)
    {
        if(playerMove != null)
        {
            if(playerMove.IsBusy() == false)
            {
                playerMove.BlockLow();
            }
        }
    }
    public void OnPause(CallbackContext context)
    {
        if(playerMove != null)
        {
            playerMove.Pauser();            
        }
    }
}
