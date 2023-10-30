using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    class Program
    {
        static void Main(string[] args)
        {

            MyStack<Student> stack = new MyStack<Student>();
            MyStack<Student> myStack = new MyStack<Student>();
            Student student1 = new Student { FirstName = "Паша" };
            Student student2 = new Student { FirstName = "Лёха" };
            Student student3 = new Student { FirstName = "Колян" };
            Student student4 = new Student { FirstName = "Даня" };
            Student student5 = new Student { FirstName = "Лёнчик" };
            stack.Push(student1);
            stack.Push(student2);
            stack.Push(student3);
            stack.Push(student4);
            stack.Push(student5);

            Student student = stack.Pop();
            while (student != null)
            {
                Console.WriteLine("Введите оценку за практику...");
                student.Mark = Console.ReadLine();
                myStack.Push(student);
                student = stack.Pop();
            }
        }

    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mark { get; set; }


        public class StackItem<T>
        {
            public StackItem<T> Previous { get; set; }
            public T Value { get; set; }

            public StackItem(T value, StackItem<T> previous)
            {
                Value = value;
                Previous = previous;
            }
        }

        public class MyStack<T>
        {
            public StackItem<T> stackItem;
            int count = 0;
            public T Pop()
            {
                if (stackItem == null)
                    return default(T);
                T value = stackItem.Value;
                stackItem = stackItem.Previous;
                count--;
                return value;

            }

            public void Push(T value)
            {
                stackItem = new StackItem<T>(value, stackItem);
                count++;
            }

            public T Peek()
            {
                if (stackItem == null)
                    return default(T);
                return stackItem.Value;
            }

            public int Count()
            {
                return count;
            }

            public void Clear()
            {
                stackItem = null;
            }

        }
    }
}
