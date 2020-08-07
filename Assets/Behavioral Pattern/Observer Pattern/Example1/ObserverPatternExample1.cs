using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ObserverPatternExample1
{
    public delegate void HPChangedCallback(int curHP);

    public class ObserverPatternExample1 : MonoBehaviour
    {
        
        void Start()
        {
            Health hp = new Health();
            Health_UI ui = new Health_UI();
            hp.RegisterObserver(ui.UpdateHP);

            hp.SetHP(50);
            hp.SetHP(100);
        }
    }

    public interface Subject
    {
        void RegisterObserver(HPChangedCallback func);

        void UnregisterObserver(HPChangedCallback func);

        void OnValueChanged();
    }

    public class Health : Subject
    {
        List<HPChangedCallback> m_observers = new List<HPChangedCallback>();

        int m_hp = 0;

        public void RegisterObserver(HPChangedCallback func)
        {
            m_observers.Add(func);
        }

        public void UnregisterObserver(HPChangedCallback func)
        {
            m_observers.Remove(func);
        }

        public void OnValueChanged()
        {
            foreach(var observer in m_observers)
            {
                observer(m_hp);
            }
        }

        public void SetHP(int hp)
        {
            m_hp = hp;
            OnValueChanged();
        }

    }

    public interface HP_Observer
    {
        void UpdateHP(int hp);
    }

    public class Health_UI : HP_Observer
    {
        public void UpdateHP(int hp)
        {
            Debug.Log("当前HP是:" + hp);
        }
    }
}

