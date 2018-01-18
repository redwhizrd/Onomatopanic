using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
public class Fighter : MonoBehaviour {

    public Dictionary<float, State> bufferedInput;
    public enum ComboLength
    {
        Zero,
        First,
        Second,
        Third
    };


    public string Charname;
    private Effect special;
    public int pos;
    public bool first;
    public bool combonow;
    public float start;
    public State.Input state;
    public State.Height height;
    public ComboLength comboLength = ComboLength.Zero;

    public Animator anim;
    float lastAttack;
    internal static float waitTime = 1f;
    private bool hitting = false;

    public Fighter(){

    }
	public void init(string name,bool playerOne){
        bufferedInput = new Dictionary<float, State>();
        Debug.Log(name);
        anim = GetComponentInChildren<Animator>();
        Charname = name;
        first = playerOne;
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = !first;

        special = gameObject.GetComponent<Effect>();//new Defense();
        comboLength = ComboLength.Zero;
        state = State.Input.Neutral;
        height = State.Height.Middle;
    }

    void Update() {
        if (first)
        {

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {

                //Attack
                if (Input.GetKeyDown(KeyCode.A))
                {
                    changeState(State.Input.Attack, State.Height.High);
                    anim.SetInteger("punchHeight", 3);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    changeState(State.Input.Attack, State.Height.Middle);
                    anim.SetInteger("punchHeight", 2);
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    changeState(State.Input.Attack, State.Height.Low);
                    anim.SetInteger("punchHeight", 1);
                }
            }

            //Defense
            if (Input.GetKeyDown(KeyCode.Z))
            {
                changeState(State.Input.Defend, State.Height.High);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                changeState(State.Input.Defend, State.Height.Middle);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                changeState(State.Input.Defend, State.Height.Low);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                changeState(State.Input.Special, State.Height.High);
            }
        }

        if (!first)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                //Attack
                if (Input.GetKeyDown(KeyCode.J))
                {
                    changeState(State.Input.Attack, State.Height.High);
                    anim.SetInteger("punchHeight", 3);
                }

                if (Input.GetKeyDown(KeyCode.K))
                {
                    changeState(State.Input.Attack, State.Height.Middle);
                    anim.SetInteger("punchHeight", 2);
                }

                if (Input.GetKeyDown(KeyCode.L))
                {
                    changeState(State.Input.Attack, State.Height.Low);
                    anim.SetInteger("punchHeight", 1);
                }
            }
            //Defense
            if (Input.GetKeyDown(KeyCode.M))
            {
                changeState(State.Input.Defend, State.Height.High);
            }

            if (Input.GetKeyDown(KeyCode.Comma))
            {
                changeState(State.Input.Defend, State.Height.Middle);

            }

            if (Input.GetKeyDown(KeyCode.Period))
            {
                changeState(State.Input.Defend, State.Height.Low);
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                changeState(State.Input.Special, State.Height.High);
            }
        }

      /*  if (!Input.anyKeyDown || !Input.anyKey)
        {
            changeState(State.Neutral, Height.Middle);
        }
        */
        updatePosition();
    }

    public Effect getSpecial(){
		special.reset();
		return special;
	}
    public void isHitting()
    {
        this.hitting = true;
    }
    public void notHitting()
    {
        this.hitting = false;
    }
	public State.Height getHeight(){
		return height;
	}
    public State.Input getState()
    {
        if (bufferedInput.Count > 0) { 
            float f = bufferedInput.Keys.Last();
            if (f > Time.time - .1f)
            {
                return bufferedInput[f].getInput();
            }
            else
            {
                bufferedInput.Clear();
                return State.Input.Neutral;

            }
        }
        else
        {
            return State.Input.Neutral;
        }
    }
    public void changeState(State.Input s, State.Height h)
    {
        if (s == State.Input.Neutral)
        {
            return;
        }
 
        bufferedInput.Add(Time.time, new State(h, s));
    }



	public void setPos(Vector3 newpos){
		transform.parent.GetComponentInParent<Transform>().position = Vector3.Lerp(transform.parent.GetComponentInParent<Transform>().position, newpos, .10f);
        
	}

	public bool CanMove(){
        if (first)
        {
            if (pos> 0)
            {
                return true;
            }
        }
        else
        {
			if(pos<5){
				return true;
			}
		}
		return false;
	}

	public void updatePosition(){
		Vector3 newPos= new Vector3();
		newPos = Stage.positions[pos].getPosition();
		newPos.y += Stage.positions[pos].gameObject.GetComponent<SpriteRenderer>().bounds.size.y+(gameObject.GetComponent<SpriteRenderer>().bounds.size.y/2);
		setPos(newPos); 
	}

    public bool getHitting()
    {
        return hitting;
    }
    public void resetPunch()
    {
        anim.SetInteger("punchHeight", 0);
        changeState(State.Input.Neutral, State.Height.Middle);
    }

    public void roundWin()
    {
        if (first)
        {
            //Player One wins
            int wins = Int32.Parse(GameObject.Find("Char1Wins").GetComponent<Text>().text);
            wins++;
            GameObject.Find("Char1Wins").GetComponent<Text>().text = wins.ToString();

        }
        else
        {
            //Player Two wins
            int wins = Int32.Parse(GameObject.Find("Char2Wins").GetComponent<Text>().text);
            wins++;
            GameObject.Find("Char2Wins").GetComponent<Text>().text = wins.ToString();

        }

}

}