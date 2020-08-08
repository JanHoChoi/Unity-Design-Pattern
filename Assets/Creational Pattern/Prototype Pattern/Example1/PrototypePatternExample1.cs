using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace PrototypePatternExample1
{
    public class PrototypePatternExample1 : MonoBehaviour
    {
        void Start()
        {
            MonsterSaber a = new MonsterSaber();
            Debug.Log(a.m_name);
            MonsterSaber b = a.Clone() as MonsterSaber;
            Debug.Log(b.m_name);
        }
    }

    /// <summary>
    /// 原型
    /// </summary>
    public abstract class Monster
    {
        public abstract Monster Clone();
    }

    /// <summary>
    /// 具体原型
    /// </summary>
    public class MonsterSaber : Monster
    {
        public string m_name;

        public MonsterSaber()
        {
            m_name = "Saber";
        }

        public override Monster Clone()
        {
            return this.MemberwiseClone() as Monster;   // 浅拷贝
        }
    }
}


