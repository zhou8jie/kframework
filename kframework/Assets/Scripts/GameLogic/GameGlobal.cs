using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingousFramework;
using DG.Tweening;

public class GameGlobal : MonoBehaviour
{
    private GameMode m_Mode = null;
    private Timer m_Timer = new Timer();
    private InputManager m_InputManager = null;
    private SoundManager m_SoundManager = null;

    public InputManager inputMgr
    {
        get { return m_InputManager; }
    }

    public GameMode mode
    {
        get { return m_Mode; }
    }
    public Timer timer
    {
        get { return m_Timer; }
    }
    public SoundManager soundMgr
    {
        get { return m_SoundManager; }
    }

    public static GameGlobal s_Inst = null;
    public static GameGlobal Instance()
    {
        return s_Inst;
    }

    void Awake()
    {
        s_Inst = this;
        DOTween.Init();
    }

    void Start ()
    {
        m_InputManager = GetComponentInChildren<InputManager>();
        m_SoundManager = GetComponentInChildren<SoundManager>();
        m_Mode = new GameMode();
        // m_Mode.ChangeGameState(GameMode.State_Main);
	}
	
	void Update ()
    {
        float dt = Time.deltaTime;
        m_Mode.UpdateGameMode();
        m_Timer.Tick(dt);
	}
}
