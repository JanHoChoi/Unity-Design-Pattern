using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPatternExample1
{

    public class CommandPatternExample1 : MonoBehaviour
    {
        CommandInvoker invoker;
        Hero hero;

        private void Start()
        {
            invoker = new CommandInvoker();
            hero = new Hero("Jack");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                invoker.AddCommand(new MoveCommand(hero, new Vector2(0, 1)));
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                invoker.AddCommand(new MoveCommand(hero, new Vector2(-1, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                invoker.AddCommand(new MoveCommand(hero, new Vector2(0, -1)));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                invoker.AddCommand(new MoveCommand(hero, new Vector2(1, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                invoker.AddCommand(new JumpCommand(hero));
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                invoker.RollBack();
            }

            invoker.Invoke();
        }
    }

    public class CommandInvoker
    {
        List<Command> command_list;
        int count;

        public CommandInvoker()
        {
            command_list = new List<Command>();
            count = 0;
        }

        public void AddCommand(Command new_command)
        {
            command_list.Add(new_command);
        }

        public void Invoke()
        {
            if(count < command_list.Count)
            {
                command_list[count].execute();
                count = count + 1;
            }
        }

        public void RollBack()
        {
            if(count > 0)
            {
                count = count - 1;
                command_list[count].undo();
                command_list.RemoveAt(count);
            }
            else
            {
                Debug.Log("无可撤销指令");
            }
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    public interface Command
    {
        void execute();
        void undo();
    }

    /// <summary>
    /// Concrete Command: 角色移动
    /// </summary>
    public class MoveCommand : Command
    {
        private Hero hero;
        private Vector2 pos;
        private Vector2 before_pos;

        public MoveCommand(Hero _hero, Vector2 _pos)
        {
            hero = _hero;
            pos = _pos;
        }

        public void execute()
        {
            before_pos = hero.GetPos();
            hero.Move(pos);
        }

        public void undo()
        {
            hero.Move(before_pos);
        }
    }

    /// <summary>
    /// Concrete Command: 角色跳跃
    /// </summary>
    public class JumpCommand : Command
    {
        private Hero hero;

        public JumpCommand(Hero _hero)
        {
            hero = _hero;
        }

        public void execute()
        {
            hero.Jump();
        }

        public void undo()
        {
            hero.Jump();
        }
    }

    /// <summary>
    /// Receiver: 角色类,负责实际Action
    /// </summary>
    public class Hero
    {
        private string heroName;
        private Vector2 curPos;

        public Hero(string _heroName)
        {
            heroName = _heroName;
        }

        public void Move(Vector2 newPos)
        {
            Debug.Log(heroName + " moves from " + curPos.ToString() + " to " + newPos.ToString());
            curPos = newPos;
        }

        public void Jump()
        {
            Debug.Log(heroName + " jumps");
        }

        public Vector2 GetPos()
        {
            return curPos;
        }
    }

}
