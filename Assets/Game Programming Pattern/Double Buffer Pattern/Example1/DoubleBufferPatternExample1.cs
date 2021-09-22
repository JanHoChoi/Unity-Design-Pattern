using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBufferPatternExample1 : MonoBehaviour
{
    List<Player> actors;
    void Start()
    {
        Player Ame = new Player("Ame");
        Player Topson = new Player("Topson");
        Player Sumail = new Player("Sumail");

        Ame.Face(Topson);
        Topson.Face(Sumail);
        Sumail.Face(Ame);

        Ame.Hit();

        actors = new List<Player>{Ame, Topson, Sumail};
    }

    void Update()
    {
        for (int i = 0; i < actors.Count; i++)
        {
            actors[i].Update();
        }
        for (int i = 0; i < actors.Count; i++)
        {
            actors[i].Swap();
        }
    }
}

public class Player
{
    private bool[] isHit = new bool[2]{false, false};
    private int cur;
    private string name;
    private Player target;

    public Player(string name)
    {
        this.name = name;
        this.cur = 0;
    }

    public void Face(Player other)
    {
        target = other;
    }

    public void Hit()
    {
        this.isHit[1 - cur] = true;
    }

    public void Update()
    {
        Debug.Log(string.Format("{0}.isHit = {1}", this.name, this.isHit[cur]));
        if (this.isHit[cur])
        {
            target.Hit();
        }
    }

    public void Swap()
    {
        cur = 1 - cur;
        isHit[1 - cur] = false;
    }
}
