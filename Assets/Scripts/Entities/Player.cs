using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class Player : MonoSingleton<Player>
{
    #region Variables
    [SerializeField] private PlayerSettings playerSettings;

    [SerializeField] private Animator animator;
<<<<<<< HEAD
    private bool canMove = false;
    public bool onFinishPlane = false;
=======
>>>>>>> f52ef9370ef6b2fc22d21754d281590eb14633df

    private float touchPosX;

    private bool canMove = false;
    #endregion

    #region Unity Methods

    private void Start() 
    {
        LevelController.Instance.NextLevel += OnNextLevel;    
        GameManager.Instance.FinishGame += OnFinishGame;
        GameManager.Instance.StartGame += OnStartGame;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameStart && canMove && !onFinishPlane)
        {
            Movement();
            AnimationController();
        }
    }
    #endregion

    #region Methods

    private void Movement()
    {
         
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            touchPosX += touch.deltaPosition.x * playerSettings.swerweSpeed * Time.deltaTime;
        }

        transform.position = new Vector3
        (
            Mathf.Clamp(touchPosX, playerSettings.minXPos, playerSettings.maxXpos),
            transform.position.y,
            transform.position.z + playerSettings.forwardSpeed * Time.deltaTime
        );
    }
    private void AnimationController() 
    {
        animator.SetTrigger("Walk");
    }

    #endregion

    #region Callbacks

    private void OnStartGame()
    {
        canMove = true;
    }

    private void OnNextLevel()
    {
        transform.position = Vector3.zero;
    }

    private void OnFinishGame()
    {
        canMove = false;
    }

    #endregion
}
