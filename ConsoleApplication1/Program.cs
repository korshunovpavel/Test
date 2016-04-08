using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ConsoleApplication1.Specification;
using FactorFalcon.Common.Context;

namespace ConsoleApplication1
{
    internal sealed partial class BasePartial
    {
        private String m_name;

            // Это объявление с определением частичного метода вызывается
        // перед изменением поля m_name
        partial void OnNameChanging(String value);
        public String Name
        {
            get { return m_name; }
            set
            {
                // Информирование класса о потенциальном изменении
                OnNameChanging(value.ToUpper());
                m_name = value; // Изменение поля
            }
        }
    }

    internal sealed partial class BasePartial
    {
        partial void OnNameChanging(string value)
        {
            Console.WriteLine("Partial method called");
        }
    }

    public class TestItem
    {
        private readonly int[] _massive;

        public TestItem(int num)
        {
            _massive = new int[num];
        }

        public int Item;

        [IndexerName("testItem")]
        public int this[int position]
        {
            get
            {
                return _massive[position];
            }
            set
            {
                _massive[position] = value;
            }
        }
    }

    public interface ITestInt
    {
        void Tes();
    }

    public class ClassA : ITestInt
    {
        void ITestInt.Tes()
        {
            Console.Write("ITestInt. Interfeace method Tes has been called");
        }
    }

    public class Program
    {
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int T3 { get; set; }
        public int T4{ get; set; }

        private int _t5;

        public int T5
        {
            get
            {
                return _t5;
            }
            set
            {
                _t5 = value;
            }
        }

        public class Rational
        {
            public int X { get; private set; }

            public Rational(int xx)
            {
                X = xx;
            }

            public int TestM(int i)
            {
                return 1;
            }

            public static implicit operator Rational(int i)
            {
                return new Rational(i);
            }

            public static explicit operator int(Rational r)
            {
                return r.X;
            }

            public void Method(int x, int y = 5)
            {
                
            }
        }

        //[StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Test
        {
            public byte t;
            public short q4;
            public short q2;
            public int i;
            public byte j;
        }

        public static void GetValue(ref int x)
        {
            var t = new ClassA();
            ((ITestInt)t).Tes();
            x = 7;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("size is {0}", Marshal.SizeOf(typeof(Test)));
            TetsSpecification();
            var ti = new TestItem(10);
            ti[0] = 10;
            ti[2] = 20;
            ti.Item = 3;

            Console.WriteLine(ti[0]);
            int x = 5;
            GetValue(ref x);
            Console.WriteLine(x);

            //var rat = new Rational(5);
            //int y = (int)rat;
            //int cc = 89;
            //Rational r = cc;
            //r.Method(y:4, x:7);
            //var rr = 10.ToRational();


            //var part = new BasePartial();
            //var c = part.Name;
            //part.Name = "dddd";
            //c = part.Name;
            //Base derived = new Derived();
            
            //derived.Foo(42);

            //string c = "a" + "b" + "c" + "d" + "e" + "f" + "g" + "h" + "i" + "j"; //52 b
            //string c = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j"); //147b
            //string c = string.Concat("a", "b", "c", "d", "e", "f", "g", "h", "i", "j");
            //Console.WriteLine(c);

            Console.Read();
        }

        private static void TetsSpecification()
        {
            var list = new List<TestSpecItem>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new TestSpecItem{Age = i, Count = 20 - i, Name = "Name_"+i});
            }

            var specifications = new List<ISpecification<TestSpecItem>>();

            //if (cbName is selected)
            {
                var spec = new ExpressionSpecification<TestSpecItem>(x => x.Name.EndsWith("5"));
                specifications.Add(spec);
            }
            //if (cbAge is selected)
            {
                var spec = new ExpressionSpecification<TestSpecItem>(x => x.Age == 3);
                specifications.Add(spec);
            }

            var newSpecs = specifications.Aggregate((curr, next) => curr.Or(next));
            var selectedList = list.Where(newSpecs.IsSatisfiedBy).ToList();
        }
    }

    public class TestSpecItem
    {
        public int Age { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }

    class Base
    {
        public void Foo(int i)
        {
            Console.WriteLine("Base.Foo(int)");
        }
    }


    class Derived : Base
    {
        public void Foo(object o)
        {
            Console.WriteLine("Derived.Foo(object)");
        }
    }

    public abstract class A
    {
        public abstract void Test();
    //{
    //    Console.WriteLine("A");
    //}
    }

    public class B : A
    {
        public override void Test()
        {
            Console.WriteLine("B");
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as B);
        }

        public override int GetHashCode()
        {
            return 1;
        }

    }

    public class C : B
    {
        public new void Test()
        {
            Console.WriteLine("C");
        }
    }
}