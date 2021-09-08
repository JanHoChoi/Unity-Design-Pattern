using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePatternExample1
{
    public class StatePatternExample1 : MonoBehaviour
    {
        private HeroStandingState standingState;
        private HeroWalkingState walkingState;
        private HeroJumpingState jumpingState;

        private HeroBaseState curState;

        void Start()
        {
            standingState = new HeroStandingState(this);
            walkingState = new HeroWalkingState(this);
            jumpingState = new HeroJumpingState(this);
            curState = standingState;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                curState.HandleInput("W");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                curState.HandleInput("A");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                curState.HandleInput("S");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                curState.HandleInput("D");
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                curState.HandleInput("Space");
            }
            else
            {
                curState.HandleInput("Null");
            }
            curState.Update();
        }
    
        public void SwitchState(string stateName)
        {
            curState.Leave();
            switch(stateName)
            {
                case "StandingState":
                    curState = standingState;
                    break;
                case "WalkingState":
                    curState = walkingState;
                    break;
                case "JumpingState":
                    curState = jumpingState;
                    break;
            }
            curState.Enter();
        }
    }

    public abstract class HeroBaseState
    {
        public abstract void HandleInput(string op);
        public abstract void Update();
        public abstract void Enter();
        public abstract void Leave();
    }

    public class HeroStandingState : HeroBaseState
    {
        private StatePatternExample1 context;
        public HeroStandingState(StatePatternExample1 context)
        {
            this.context = context;
        }
        public override void HandleInput(string op)
        {
            switch(op)
            {
                case "W":
                case "A":
                case "S":
                case "D":
                    this.context.SwitchState("WalkingState");
                    break;
                case "Space":
                    this.context.SwitchState("JumpingState");
                    break;
                case "Null":
                    break;
            }
        }

        public override void Enter()
        {         
        }

        public override void Leave()
        {
        }

        public override void Update()
        {
            Debug.Log("Player is standing!");
        }
    }

    public class HeroWalkingState : HeroBaseState
    {
        private StatePatternExample1 context;
        private string direction = "Null";
        private float speed = 1.0f;
        public HeroWalkingState(StatePatternExample1 context)
        {
            this.context = context;
        }
        public override void HandleInput(string op)
        {
            switch(op)
            {
                case "W":
                    direction = "North";
                    speed = 1.0f;
                    break;
                case "A":
                    direction = "West";
                    speed = 1.0f;
                    break;
                case "S":
                    direction = "South";
                    speed = 1.0f;
                    break;
                case "D":
                    direction = "East";
                    speed = 1.0f;
                    break;
                case "Space":
                    this.context.SwitchState("JumpingState");
                    break;
                case "Null":
                    speed -= 0.1f;
                    break;
            }
            if (speed <= 0f)
                this.context.SwitchState("StandingState");
        }

        public override void Enter()
        {
            speed = 1.0f;
            direction = "Null";
        }

        public override void Leave()
        {
        }

        public override void Update()
        {
            Debug.Log("Player is walking toward " + direction + " and speed = " + speed.ToString());
        }
    }

    public class HeroJumpingState : HeroBaseState
    {
        private StatePatternExample1 context;
        private float height = 1.0f;
        public HeroJumpingState(StatePatternExample1 context)
        {
            this.context = context;
        }

        public override void HandleInput(string op)
        {
        }

        public override void Enter()
        {
            height = 1.0f;
        }

        public override void Leave()
        {
        }

        public override void Update()
        {
            height -= 0.02f;
            if (height < 0)
                this.context.SwitchState("StandingState");
            Debug.Log("Player is on air !" + " And height = " + height.ToString());
        }
    }
}