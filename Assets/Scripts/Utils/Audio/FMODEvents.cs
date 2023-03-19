using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player")]
    [field: SerializeField] public EventReference punch { get; private set; }
    [field: SerializeField] public EventReference kick { get; private set; }
    [field: SerializeField] public EventReference hurt { get; private set; }
    [field: SerializeField] public EventReference frenzy { get; private set; }
    [field: SerializeField] public EventReference shieldBreak { get; private set; }

    [field: Header("Brick")]
    [field: SerializeField] public EventReference brickBreak { get; private set; }
    [field: SerializeField] public EventReference bonusBreak { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference gameplayBGM { get; private set; }
    [field: SerializeField] public EventReference mainMenuBGM { get; private set; }

    [field: Header("UI")]
    [field: SerializeField] public EventReference buttonClick { get; private set; }
    [field: SerializeField] public EventReference wrongClick { get; private set; }
    [field: SerializeField] public EventReference shopItemClick { get; private set; }
    [field: SerializeField] public EventReference timeOut { get; private set; }
    [field: SerializeField] public EventReference clockTick { get; private set; }


    [field: Header("Intro")]
    [field: SerializeField] public EventReference introBGM { get; private set; }


    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }


}
