/* {{{ */
const

	const int 		a = 3;
	const double    b = 3.14;
	const string    c = "abcdef";
/* }}} */
/* {{{ */
var (type inference)

var a = 3; // int 
var b = "hello"; // string

/* }}} */
/* {{{ */
foreach 

int[] arr = new int[] {1, 2, 3};
foreach (var e in arr) { 
	Debug.Log(e); 
}
/* }}} */
/* {{{ */
enum 

enum DialogResult { YES, NO };
void Start() {
	DialogResult result = DialogResult.YES;
	Debug.Log(result);
}

/* }}} */
/* {{{ */
casting

// upcasting
JValue jv1 = new JString("jstr1");

// downcasting

// JString jstr1 = jv1; // compile error
JString jstr2 = (JString) jv1; // downcastring OK
JString jstr3 = jv1 as JString; // downcastring OK
/* }}} */
/* {{{ */
is operator

JValue = jv1 = new JString("jstr1");

if(jv1 is JString) 
	WriteLine("jv1 is JString");
else 
	WriteLine("jv1 is not JString");
/* }}} */
/* {{{ */
delegates

	함수주소에 대한 레퍼런스를 리스트로 저장한다.
	
	리스트를 저장하고 있어서 멀티캐스트처럼 해당 리스트의 모든 메소드를 호출한다.
		
	호출순서는 +, +=  연산자를 이용하여 추가된 순서, 즉 리스트에 저장된 순서 이다.
		
	delegate 타입의 함수가 반환값이 있는경우 가장 마지막 함수의 반환값을 반환한다.
		
기본 사용법
	
	    TestDelegate testDelegate = null;
	
	    void Test() {
	        testDelegate += Func1;
	        if(testDelegate != null) {
	            testDelegate();
	        }
	    } 
	
	    void Func1() {
	        Print("Func1()");
	    }

delegate 기본

	대리자 형식을 선언하고 그와 일치하는 서명이 있는 메서드를 선언합니다.

	delegate void NotifyCallback(string str);

	static void Notify(string name) {
		Console.WriteLine("Notification received for: " + name);
	}

	NotifyCallback del1 = new NotifyCallback(Notify);

	대리자 형식에 메서드 그룹을 할당합니다.

	NotifyCallback del2 = Notify;

	익명메서드를 선언합니다.

	NotifyCallback del3 = delegate(string name) {
		Console.WriteLine("Notification received for: " + name);
	}

	NotifyCallback del4 = name => { Console.WriteLine("Notification received for: " + name ); };


multicast delegate

	using System;

	// Define a custom delegate that has a string parameter and returns void.
	delegate void CustomCallback(string s);

	class TestClass
	{
		// Define two methods that have the same signature as CustomCallback.
		static void Hello(string s)
		{
			Console.WriteLine($" Hello, {s}!");
		}

		static void Goodbye(string s)
		{
			Console.WriteLine($" Goodbye, {s}!");
		}

		static void Main()
		{
			// Declare instances of the custom delegate.
			CustomCallback hiDel, byeDel, multiDel, multiMinusHiDel;

			// In this example, you can omit the custom delegate if you
			// want to and use Action<string> instead.
			//Action<string> hiDel, byeDel, multiDel, multiMinusHiDel;

			// Initialize the delegate object hiDel that references the
			// method Hello.
			hiDel = Hello;

			// Initialize the delegate object byeDel that references the
			// method Goodbye.
			byeDel = Goodbye;

			// The two delegates, hiDel and byeDel, are combined to
			// form multiDel.
			multiDel = hiDel + byeDel;

			// Remove hiDel from the multicast delegate, leaving byeDel,
			// which calls only the method Goodbye.
			multiMinusHiDel = multiDel - hiDel;

			Console.WriteLine("Invoking delegate hiDel:");
			hiDel("A");
			Console.WriteLine("Invoking delegate byeDel:");
			byeDel("B");
			Console.WriteLine("Invoking delegate multiDel:");
			multiDel("C");
			Console.WriteLine("Invoking delegate multiMinusHiDel:");
			multiMinusHiDel("D");
		}
	}
	/* Output:
	Invoking delegate hiDel:
	 Hello, A!
	Invoking delegate byeDel:
	 Goodbye, B!
	Invoking delegate multiDel:
	 Hello, C!
	 Goodbye, C!
	Invoking delegate multiMinusHiDel:
	 Goodbye, D!
	*/
/* }}} */
/* {{{ */
Func

Func 는 제네릭버전으로 정의한 delegate 이다.

    delegate TResult Func<out TResult>                  () ;
    delegate TResult Func<in T, out TResult>            (T arg) ;
    delegate TResult Func<in T1, in T2, out TResult>    (T1 arg1, T2 arg2) ;

	ex. 첫번째 파라미터가 string,  반환타입이 int

        Func<string s, int> func = null;

한개의 함수를 저장후 호출

	Func<string, string> myUpper = (str) => str.ToUpper();
	GD.Print(myUpper("aBc"));


여러개의 함수를 저장후 호출

	Func<string, string> myFunc = (param) => { GD.Print("param = " + param); return "function 1 return value"; };
	myFunc += (param) => { GD.Print("param = " + param); return "function 2 return value"; };
	myFunc += (param) => { GD.Print("param = " + param); return "function 3 return value"; };
	GD.Print(myFunc("Test Param"));


	결과

		param = Test Param
		param = Test Param
		param = Test Param
		function 3 return value
/* }}} */
/* {{{ */
Action

- Action 은 Geneic 으로 정의한  delegate 이다. Function과 동일하나 반환값이 void 이다.

    delegate void Action ();
    delegate void Action <in T1>        (T1 arg1);
    delegate void Action <in T1, in T2> (T1 arg1, T2 arg2);

    ex. 첫번째 파라미터가 string, 두번째 파라미터가 double 이라면
        Action<string, double> func = null;

- ex.

    namespace Test {

        class Person {
            string name;
            int    age;
            public Person(string name, int age) {
                this.name = name; 
                this.age  = age;
            }

            public string render(string punctuation) {
                string s = "Person Object : "+ punctuation + "name = " + name + " " + "age = " + age.ToString() + punctuation;
                Console.WriteLine(s);
                return s;
            }
        }

        class Program {
            static string renderPerson(string punctuation) { 
                string s = "renderPerson() :" + punctuation + "name = Chulsoo age = 21" + punctuation;
                Console.WriteLine(s);
                return s;
            }

            delegate string RenderFunc(string m);
            static void Main(string[] args) {
                RenderFunc f = null;
                // Func<string, string> f = null; /* Func<first param, function return type> */
                // Action<string> f = null;  // void Person.render(string), void renderPersoin(string) 으로 변경한다

                Person p1 = new Person("KIM", 25);
                Person p2 = new Person("SON", 46);

                f += renderPerson;
                f += p1.render;
                f += p1.render;  // 두번 등록하면 두번 호출된다.
                f += p2.render;

                Console.WriteLine("---------- test 1 --------------");
                f("'");

                // 함수나 메소드를 delegate에서 제외 한다.
                f -= renderPerson;
                f -= p1.render;   // 두개중 하나가 삭제된다.

                Console.WriteLine("---------- test 2 --------------");
                f("\"");
                /*
                    ---------------------------------------------
                    run
                    ---------------------------------------------
                    ---------- test 1 --------------
                    renderPerson() :'name = Chulsoo age = 21'
                    Person Object : 'name = KIM age = 25'
                    Person Object : 'name = KIM age = 25'
                    Person Object : 'name = SON age = 46'
                    ---------- test 2 --------------
                    Person Object : "name = KIM age = 25"
                    Person Object : "name = SON age = 46"
                */
            }
        }
    }
	
/* }}} */
/* {{{ */
이벤트
	
	 delegate 타입의 배열이다.
	
		제약:
			event를 정의한 클래스내에서만 호출가능하다.
			
			함수를 등록/삭제 할때 +=, -= 연산자로만 등록/삭제가 가능한다 (할당연산자로 함수를 등록할수 없다)
			
	
	namespace ConsoleApp2
	{
	    class MyButton
	    {
	        public delegate void MyEvent();
	        public MyEvent click;
	    }
	
	    class Test
	    {
	        public MyButton button = new MyButton();
	        public Test()
	        {
	            button.click = OnClick;
	        }
	
	        void OnClick()
	        {
	            Console.WriteLine("Test.OnClick()");
	        }
	    }
	    internal class Program
	    {
	        static void Main(string[] args)
	        {
	            Test test = new Test();
	            test.button.click();
	        }
	    }
	}


/* }}} */
/* {{{ */
lambda expression 

파라미터가 한개일때

     파라미터가 1개일때 괄호 생략 가능하다

	(x) => x * x
	
	x => x * x                    
	
	expression 이 아닌 statement 를 기술할때는 중괄호({,}) 를 기술해야 한다.
	
     x => { return x * x ; }       
	
파라미터가 두개 이상일때

	 (a, b) => a + b
	 (a, b) => { if (a < b) return a + b; else return a - b; }
	
/* }}} */
/* {{{ */
interface

interface IWalk {
    void Walk();
}

interface IEat {
    void Eat();
}

class Animal { }

class Dog : Animal, IWalk, IEat {
    void IWalk.Walk()  {
        Debug.Log("Dog.IWalk.Walk()");
    }

    void IEat.Eat() {
        Debug.Log("Dog.IEat.Eat()");
    }
}


public class OnHotReload : MonoBehaviour {
        [InvokeOnHotReload]
        void Run() {
            Dog dog = new Dog();
            IWalk iWalk = dog;
            IEat  iEat  = dog;

            iWalk.Walk();
            iEat.Eat();

            print("t4");
        }
}

/* }}} */
/* {{{ */
GetHashCode(), Equals()


Dictionary 나 HashTable에서는 성능을 위해 키가 같은지 검사하기 위해  int로 표현되는 HashCode 를 
먼저 검사한후 이후 Equals를 호출한다.
HashCode는 중복이 되어도 되나 중복이 많이 발생하면 Add 성능 및 Contains 성능 모두 크게 하락한다.
	
따라서 키가  Key1, Key2, Key3 로 구분된다면 HashCode를 System.HashCode.Combine(Key1, Key2, Key3) 로 하면 된다.

/* }}} */
/* {{{ */
class

class definition basic example

    using System;

    namespace CSharpTest
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Person person = new Person ("person1", 15);
                Console.WriteLine(person.name + " " + person.age);
            }
        }

        class Person 
        {
            public Person(string name, int age)
            {
                this.name = name;
                this.age  = age;
            }

            public string name;
            public int    age;

            int internal_use_1;          // no access modifier specified. it is private(default)
        }

    }

static member

	class Global {
		public static int totalCount = 0;
		public static int GetTotalCount() { return totalCount; }
	}

this 생성자

	class Person {
		public string name;
		public int    age;

		public Person(string name, int age) {
			this.name = name;
			this.age  = age;
		}

		public Person(int age) : this("", age) {
		}

		public Person(string name) : this(name, 20) {
		}
	}

initializer

    public class Bunny { 
        public string Name; 
        public bool LikesCarrots; 
        public bool LikesHumans; 
        public Bunny () {} 
        public Bunny (string n) { Name = n; }
    }

    class Program {
        static void Main(string[] args) {
            Bunny b1 = new Bunny { Name =" Bo", LikesCarrots = true, LikesHumans = false }; 
            Bunny b2 = new Bunny (" Bo") { LikesCarrots = true, LikesHumans = false };
        }
    }

named parameter

	void PrintProfile(string name, string phone, int age) {
	}

	void Start() {
		PrintProfile(phone : "010-2343-2433", name : "Kim", age : 45); // ok
		PrintProfile(phone : "010-2343-2433", name : "Kim");           // compile error!, age가 빠졌음
	}

default parameter

	void f1(int a = 0){} 			// OK!
	void f2(int a, int b = 0) {}    // OK!
	void f3(int a = 0, int b) {}    // ERROR!

상속시 base 생성자 호출하기

	class JString : JValue {
		public JString(string s) : base(JValueType.JString) { ...}
	}

overloading

	이름 + 파라미터로 메소드를 식별함 (C++ 처럼 반환값은 포함되지 않음)

virtual

	class JValue {
		public virtual string render() {
		}
	}

	class JString : JValue {
		public override string render() {
		}
	
ICloneable 쓰지 말것

	Copy() 함수는 클래스에 특성에 따라 shallow 나 deep copy를 수행할것이다

	ICloneable 은 MS에서도 쓰지말라고 권하함으로 shallow copy를 위해서는 Objecdt.MemberwiseClone()을 사용하자.
/* }}} */
/* {{{ */
struct

ex.

	struct MyPoint {
		public int x;
		public int y;

		public MyPoint(int x, int y) { 
			this.x = x;
			this.y = y;
		}

		public string ToString() {
			return "{" + x.ToString() + ", " + y.ToString() + "}";
		}
	}

	void Start() {
		MyPoint pt1;
		pt1.x = 1;pt1.y = 2;

		Debug.Log(pt1.ToString()); // {1, 2}

		MyPoint pt2 = new MyPoint(3, 4);
		Debug.Log(pt2.ToString()); // {3, 4}
	}

디폴트 생성자를 정의할수 없다.

할당 연산자는 value semantic 하다

	struct MyPoint;

	MyPoint pt1 = new MyPoint(1, 2);
	MyPoint pt2 = pt1;

	pt2.x = 1000;

	Debug.Log(pt1.ToString()); // {1, 2}
	Debug.Log(pt2.ToString()); // {1000, 2}


/* }}} */
/* {{{ */
C# 에서 C++ 같은 class 순환 참조 문제가 있는가?


	https://stackoverflow.com/questions/3955465/circular-class-reference-problem

	No. It will compile fine. The C# compiler is smart enough to take all the types into account even if they are "not yet compiled". Like Java, the Definition/Declaration are one-and-the-same (this differs from, say, C/C++)

	아니요, 잘 컴파일됩니다. C# 컴파일러는 "아직 컴파일되지 않은" 유형이라도 모든 유형을 고려할 수 있을 만큼 똑똑합니다. Java와 마찬가지로 정의/선언은 하나의 동일한 형식입니다(이는 C/C++와 다릅니다).
/* }}} */
/* {{{ */
== 와 equals() 차이점은 무엇인가?

	string은 어떻게 == 로 value semantic한 비교 연산이 가능한가? 

		string은 immutable 이기때문에 reference로 비교(==) 해도 value 를 비교하는 것과 동일하다.
		레퍼런스가 동일하면 value 도 동일하다.
		(보통은 레퍼런스가 달라도 value가 동일할수 있지만 immutable 은 레퍼런스가 다르면 value가 다르다)
		
		string은 immutable  임으로 스트링 자체를  변경할수 없고 레퍼런스 자체가 변경된다.
		
		레퍼런스가 동일하다면 변경한 적이 없다는 뜻이다.
		
		따라서 string 처럼 immutable한 클래스는  == 로 비교해도 value semantic 한 비교가 가능하다.
		
		
		ex.
			
			string str1 = "abc";
			string str2 = "abc";
			string str3 = "efg";
			
			//여기까지는  str1과 str2는 "abc" 라는 같은 문자열 데이터를 참조하게 된다. 즉 레퍼런스가 동일하다.
			
			str2 = "efg"
			
			// 이후 str2는 "efg" 데이터를 가리키가 되어 str2 와 str3의 레퍼런스는 동일하게 된다. 
			// 즉, str2 == str3 는 true 이다.

/* }}} */
/* {{{ */
float 비교

Mathf.Approximately(1.0f, 10.0f / 10.0f)

/* }}} */
/* {{{ */
With Expression 

    Position = Position with { X = 100.0f };

/* }}} */
/* {{{ */
async/await

Winform 에서는 싱글쓰레드이다 (thread context)

	winform은 await 전후로 쓰레드가 안바뀌지만, console은 바뀐다.

example 1

        private void walkButton_Click(object sender, EventArgs e) {
            Run(walkLabel);

        }
        private async void Run(Label label) {
            for (int i = 0; i < 100; i++) {
                label.Text = i.ToString();
                await Task.Delay(100);
            }
        }

example 2

        private void walkButton_Click(object sender, EventArgs e) {
            Run(walkLabel);

        }

        private async void Run(Label label) {
            DebugLogger.Log("RunCount Start");
            await RunCount(label);
            DebugLogger.Log("RunCount End");
        }

        private async Task RunCount(Label label) {
            for (int i = 0; i < 100; i++) {
                label.Text = i.ToString();
                await Task.Delay(100);
            }
        }

/* }}} */

		
