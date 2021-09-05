# Singleton Pattern 单例模式

## Usage 用途

我们希望某些类在整个系统中是只有唯一实例的，比如Logger类、某种对象的对象池；

## Definition 定义

确保某个类只有一个实例，类中自行实例化，并且提供一个全局接口以供外部访问。

## Element 要素

### Singleton 单例

定义了类方法getInstance，允许使用者访问唯一实例；

负责初始化这个唯一实例。

## Extension 引申

- 优点：

	对比全局变量：

		1. 全局变量在一开始就需要创建好，而单例可以延迟初始化，不使用就不会被创建；
	 	2. 全局变量不能保证实例唯一；
	 	3. 可以继承，比如某些单例类在getInstance()方法中，可以根据平台不同初始化不同的子类；

- 缺点：

	1. 在getInstance()时判断唯一实例是否为空时，不是线程安全的，但是Unity可以理解成单线程引擎，基本不用担心。

		但是有一种情况，比如用Monobehaviour时，切场景会destroy掉某些对象，这可以通过DontDestroy解决，但是返回原场景之后又会导致单例出现两个。

		通用的写法：

		```
		public class Singleton<T> : MonoBehaviour where T : Singleton<T>
		{
		    public static T Instance { get; private set; }
		 
		    protected void Awake()
		    {
		        if (Instance == null)
		        {
		            Instance = (T) this;
		            DontDestroyOnLoad(gameObject);	// 防止切场景把单例删了
		        }
		        else
		        {
		            Destroy(gameObject);	// 回原场景时把多余的go删掉
		        }
		    }
		}
		```

		```
		public class GameManager : Singleton<GameManager>
		{
		    ...
		}
		```

	2. 单例既提供了全局访问性，又保证了唯一实例。这两个需求被捆绑在一起。比如Logger类，我们需要全局访问，但是我们不一定需要唯一实例（不同系统各实例化一个Logger也可以）。但是写好的单例，做这种修改很难，必须在每个调用点去修改；

	3. 延迟初始化不好控制。初始化不可避免的需要消耗性能，而延迟初始化的时机可能让游戏变卡。解决方法是用静态实例，或者显式初始化。

