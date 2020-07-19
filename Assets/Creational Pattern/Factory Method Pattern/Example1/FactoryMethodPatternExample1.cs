using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPatternExample1
{
    public class FactoryMethodPatternExample1 : MonoBehaviour
    {
        private void Start()
        {
            ProductFactory factory_a = new ProductFactoryA();
            factory_a.CreateProduct();
            ProductFactory factory_b = new ProductFactoryB();
            factory_b.CreateProduct();

            foreach(var p in factory_a.products)
            {
                p.Log();
            }

            foreach (var p in factory_b.products)
            {
                p.Log();
            }
        }
    }

    /// <summary>
    /// Product基类
    /// </summary>
    public abstract class Product
    {
        public abstract void Log();
    }

    /// <summary>
    /// 下列3个都是ConcreteProduct类
    /// </summary>
    public class NullProduct : Product
    {
        public override void Log()
        {
            Debug.Log("This is NullProduct.");
        }
    }

    public class ConcreteProductA : Product
    {
        public override void Log()
        {
            Debug.Log("This is ConcreteProductA.");
        }
    }

    public class ConcreteProductB : Product
    {
        public override void Log()
        {
            Debug.Log("This is ConcreteProductB.");
        }
    }

    public abstract class ProductFactory
    {
        protected List<Product> _products = new List<Product>();

        public List<Product> products
        {
            get { return _products; }
        }

        public abstract void CreateProduct();
    }

    public class ProductFactoryA : ProductFactory
    {
        public override void CreateProduct()
        {
            _products.Add(new ConcreteProductA());
            _products.Add(new ConcreteProductB());
            _products.Add(new NullProduct());
        }
    }

    public class ProductFactoryB : ProductFactory
    {
        public override void CreateProduct()
        {
            _products.Add(new ConcreteProductB());
            _products.Add(new NullProduct());
            _products.Add(new ConcreteProductA());
        }
    }
}

