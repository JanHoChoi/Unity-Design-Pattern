using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryPatternExample1
{
    public class AbstractFactoryPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            ConcreteFactory1 f1 = new ConcreteFactory1();
            ConcreteFactory2 f2 = new ConcreteFactory2();

            Client c1 = new Client(f1);
            c1.LogAll();

            Client c2 = new Client(f2);
            c2.LogAll();
        }
    }

    public class Client
    {
        private ProductA pa;
        private ProductB pb;

        public Client(AbstractFactory f)
        {
            pa = f.CreateProdutA();
            pb = f.CreateProdutB();
        }

        public void LogAll()
        {
            pa.Log();
            pb.Log();
        }
    }

    /// <summary>
    /// Factory基类,定义了创建产品A和产品B两个函数
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract ProductA CreateProdutA();
        public abstract ProductB CreateProdutB();
    }

    /// <summary>
    /// ConcreteFactory类
    /// </summary>
    public class ConcreteFactory1 : AbstractFactory
    {
        public override ProductA CreateProdutA()
        {
            return new ProductA1();
        }

        public override ProductB CreateProdutB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override ProductA CreateProdutA()
        {
            return new ProductA2();
        }

        public override ProductB CreateProdutB()
        {
            return new ProductB2();
        }
    }

    public abstract class ProductA
    {
        public abstract void Log();
    }

    class ProductA1 : ProductA
    {
        public override void Log()
        {
            Debug.Log("ProductA1");
        }
    }

    class ProductA2 : ProductA
    {
        public override void Log()
        {
            Debug.Log("ProductA2");
        }
    }

    public abstract class ProductB
    {
        public abstract void Log();
    }

    class ProductB1 : ProductB
    {
        public override void Log()
        {
            Debug.Log("ProductB1");
        }
    }

    class ProductB2 : ProductB
    {
        public override void Log()
        {
            Debug.Log("ProductB2");
        }
    }
}

