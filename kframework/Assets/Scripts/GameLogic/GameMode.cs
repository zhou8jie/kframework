using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingousFramework;

public class GameMode
{
    public static string Main_State = "Main_State";
    public string curState
    {
        get;
        protected set;
    }

    FSM m_FSM = new FSM();

    public GameMode()
    {
        m_FSM.addEnterState(Main_State, EnterMainState);
    }

    public void EnterMainState()
    {

    }

    public void ChangeGameState(string state)
    {
        curState = state;
        m_FSM.changeToState(state);
    }

    public void UpdateGameMode()
    {
        m_FSM.updateState();
    }
}
