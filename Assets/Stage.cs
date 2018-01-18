using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Stage : MonoBehaviour
{
    private enum StageState
    {
        //Normal running
        Update,
        //Slow down time and do pause thing
        DoingHit,
        //Move characters
        HitDone,
        Reset
    }


	public static Fighter[] players;
	public static Position[] positions;
	public GameObject PlayerOne;
	public GameObject PlayerTwo;
	public Fighter PlayerOneStats;
	public Fighter PlayerTwoStats;
	GameObject ComboCounter;
	GameObject PositionSlider;
    private StageState state;
    private Fighter pusher;
    float hitStart = 0;
    float pauseTime = 5f;
    // Use this for initialization
    void Start ()
	{

		ComboCounter = GameObject.Find("ComboCounter");
		PositionSlider = GameObject.Find("Position Slider");
		if(Game.stage==null){
			Game.stage = new StageInfo("City");
		}
		//stage info setup
		Debug.Log("Stages/Background/"+Game.stage.name);
	
		GameObject.Instantiate(Resources.Load("Stages/"+Game.stage.name) as GameObject);
	
		GameObject.Find(Game.stage.name + "(Clone)").GetComponent<Canvas>().worldCamera = Camera.main;
		if(Game.Char1==null ){
			Game.Char1 = "Biff";
		}
		if(Game.Char2 == null ){
			Game.Char2 = "Zap";
		}

		PlayerOne = GameObject.Instantiate(Resources.Load("Characters/"+Game.Char1+"/prefab")) as GameObject;
		PlayerOneStats = PlayerOne.GetComponentInChildren<Fighter>();
		PlayerOneStats.init(Game.Char1,true);

		PlayerTwo = GameObject.Instantiate(Resources.Load("Characters/"+Game.Char2+"/prefab")) as GameObject;
		PlayerTwoStats = PlayerTwo.GetComponentInChildren<Fighter>();
		PlayerTwoStats.init(Game.Char2,false);

		GameObject.Find("Char1Name").GetComponent<Text>().text = PlayerOneStats.Charname;
		GameObject.Find("Char2Name").GetComponent<Text>().text = PlayerTwoStats.Charname;
		GameObject.Find("Char1Wins").GetComponent<Text>().text = "0";
		GameObject.Find("Char2Wins").GetComponent<Text>().text = "0";
		positions = new Position[Game.stage.size];


		for(int i = 0; i < Game.stage.size; i++)
		{
			positions[i] = GameObject.Find("Position ("+i+")").GetComponent<Position>();
		}
	
		PlayerOneStats.pos = 2;

		PlayerTwoStats.pos = 3;

		PlayerOneStats.updatePosition();
		PlayerTwoStats.updatePosition();

        state = StageState.Update;
        //Time.timeScale = .1f;
    }

    // Update is called once per frame
    void Update ()
	{
        /*
		if(PlayerTwoStats.state == Fighter.State.Special){
			(positions[PlayerTwoStats.pos]).setSpecial(PlayerTwoStats);
		}

		if(PlayerOneStats.state == Fighter.State.Special){
			(positions[PlayerOneStats.pos]).setSpecial(PlayerOneStats);
		}
        */

        if (state == StageState.Update)
        {

            if (shouldPush(PlayerOneStats, PlayerTwoStats))
            {
                state = doHit(PlayerOneStats);

            }
            if (shouldPush(PlayerTwoStats, PlayerOneStats))
            {

                state = doHit(PlayerTwoStats);
            }

            if (GameObject.Find("Char1Wins").GetComponent<Text>().text == "5")
            {
                Game.end = Game.Ending.PlayerOneWin;
            }
            else if (GameObject.Find("Char2Wins").GetComponent<Text>().text == "5")
            {
                Game.end = Game.Ending.PlayerTwoWin;
            }
            
            PositionSlider.GetComponent<Slider>().value = (PlayerOneStats.pos + 1.0f) / Game.stage.size * 1.0f;

            if (Game.end != Game.Ending.None)
            {
                PlayerOneStats = null;
                PlayerTwoStats = null;
                SceneManager.LoadScene("OutcomeScreen", LoadSceneMode.Single);
            }
           
        }
        else  if(state == StageState.DoingHit) { 
            if (hitStart + pauseTime <= Time.realtimeSinceStartup)//pusher.comboLength == Fighter.ComboLength.Second ||
            {
                Time.timeScale = .1f;
                pusher.comboLength = Fighter.ComboLength.Zero;
                state = StageState.HitDone;
            }
            else //if (hitStart + pauseTime < Time.realtimeSinceStartup)
            {
                Time.timeScale = .1f;
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.J))
                {
                    if (pusher == PlayerOneStats)
                    {
                        shouldPush(pusher, PlayerTwoStats);
                    }
                    else if (pusher == PlayerTwoStats)
                    {
                        shouldPush(pusher, PlayerOneStats);
                    }


                    pusher.comboLength++;
                }
            }
        }
        else if(state == StageState.HitDone)
        {
            //move pushed to correct area
            //during pushed is moved, allow pusher to choose action
            if (pusher == PlayerTwoStats)
            {
                PlayerOneStats.anim.SetBool("hit", true);
                //PlayerOneStats.changeState(Fighter.State.Hit, PlayerOneStats.getHeight());
             
                if (PlayerOneStats.CanMove())
                {
                    PlayerOneStats.pos--;
                    PlayerTwoStats.pos--;
                }
                else
                {
                    PlayerOneStats.roundWin();

                    PlayerOneStats.pos = 2;
                    PlayerTwoStats.pos = 3;
                    state = StageState.Reset;
                }
            }
            if (pusher == PlayerOneStats)
            {
                PlayerTwoStats.anim.SetBool("hit", true);
                //PlayerTwoStats.changeState(Fighter.State.Hit, PlayerTwoStats.getHeight());
                if (PlayerTwoStats.CanMove())
                {
                    PlayerOneStats.pos++;
                    PlayerTwoStats.pos++;
                }
                else
                {
                    PlayerTwoStats.roundWin();

                    PlayerOneStats.pos = 2;
                    PlayerTwoStats.pos = 3;
                    state = StageState.Reset;
                }
            }
        
            pusher = null;

            state = StageState.Update;
        }else if(state == StageState.Reset)
        {
            PlayerOneStats.resetPunch();

            PlayerTwoStats.resetPunch();
            state = StageState.Update;
        }
	}

    public bool shouldPush(Fighter pusher, Fighter pushed) {
        if (pusher.getHitting()) {
            if (!pushed.GetComponentInChildren<Animator>().GetBool("hit")) {
                if (pusher.getState() == State.Input.Attack && (pushed.getState() == State.Input.Neutral || pushed.getState() == State.Input.Special)) {
                    this.pusher = pusher;
                    hitStart = Time.realtimeSinceStartup;
                    return true;
                }

                if (pusher.getState() == State.Input.Attack && pushed.getState() == State.Input.Defend) {
                    if (pushed.getHeight() != pusher.getHeight()) {
                        if (positions[pusher.pos].shouldPush(pushed) && positions[pushed.pos].shouldPush(pusher))
                        {
                            this.pusher = pusher;
                            hitStart = Time.realtimeSinceStartup;
                            return true;
                        }
                    }
                }
            }
        }
		return false;
	}

    private StageState doHit(Fighter pusher)
    {
      
        ComboCounter.GetComponent<Text>().text = pusher.comboLength+"";
      

        ((TimeBarScript)GameObject.Find("TimeBar").GetComponent<TimeBarScript>()).Reset(pauseTime);
        return StageState.DoingHit;
    }
}

