using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassQueue //Вариант 14 
{//№ 4 Перегрузка операций, методы расширения и вложенные типы

    /*Задание
    1) Создать заданный в варианте класс. 
    Определить в классе необходимые методы, конструкторы, 
    индексаторы и заданные перегруженные операции.
    Написать программу тестирования, в которой проверяется использование перегруженных операций. 
    2) Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. 
    Проинициализируйте его 
    3) Добавьте в свой класс вложенный класс Date (дата создания). Проинициализируйте
    4) Создайте статический класс (например, MathObject), 
    содержащий 3 метода математического преобразования над объектом вашего класса (задания№1) 
    или расчета определенных параметров 
    (например: обнуление элементов, поиск максимального, минимального, размер объекта и т.п). 
    Позже добавьте к нему метод расширения для типы string и вашего типа из задания№1.*/

    /*Класс - очередь Queue. Дополнительно перегрузить 
     * следующие операции: + - добавить элемент; -- - извлечь 
     * элемент; true - проверка, пустая ли очередь; < - копирование 
     * одной очереди в другую с сортировкой в убывающем порядке; 
     * неявный int() мощность.
   Методы расширения:
   1) Индекс первой точки
   2) Последний элемент очереди*/
    class Program
    {
        static void Main(string[] args)
        {
            /*Перегрузка операторов в программировании — один из способов реализации полиморфизма, 
             * заключающийся в возможности одновременного существования в одной области видимости нескольких различных вариантов применения оператора, 
             * имеющих одно и то же имя, но различающихся типами параметров, к которым они применяются.
             «перегрузка» — переопределение*/

            // Создание двух очередей типа double   
            Console.WriteLine("Создание двух очередей типа double...");
            Queue<double> Q1 = new Queue<double> { doubleValue = 4.6 };
            Queue<double> Q2 = new Queue<double> { doubleValue = 6.9 };
            Console.WriteLine($"Q1 = {Q1.doubleValue} \nQ2 = {Q2.doubleValue}");

            // Создание третьей очереди и присовение им результата сложения двух предыдущих
            Console.WriteLine("\nСоздание третьей очереди и присовение им результата сложения двух предыдущих...");
            Queue<double> Q3 = Q1 + Q2;
            Console.WriteLine($"Q3 = {Q3.doubleValue}");
           
            // Если треться очередь больше чем вторая, то создаётся четвёртая пустая очередь, которой присваивается результат сложения двух предыдущих
            Console.WriteLine("\nЕсли треться очередь больше чем вторая, то создаётся четвёртая пустая очередь, которой присваивается результат сложения двух предыдущих...");
            if (Q3 > Q2)
            {
                Queue<double> Q4 = Q3 + Q2;
                Console.WriteLine($"Q4 = {Q4.doubleValue}\n");
            }
            else Console.WriteLine("выражение Q3 > Q2 не верно!\n");

            // Тестирование явного и неявного преобразования типов double и очереди(Queue)
            Console.WriteLine("Тестирование явного и неявного преобразования типов double и очереди(Queue)...");                        
            double x = (double)Q1;//explicit --- int x = (int)queue1; implicit -- int x = queue1;
            Console.WriteLine($"\ndouble x = (double)Q1... \nx = {x}");

            Console.WriteLine("\ndouble y = 12... \nQ2 = y...");
            double y = 12;
            Q2 = y;
            Console.WriteLine($"Q2 = {(double)Q2}");
            Console.WriteLine();

            // Создание очереди
            Console.WriteLine("Создание очереди...");
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Kate");
            queue.Enqueue("Sam");
            queue.Enqueue("Alice");
            queue.Enqueue("Tom");
            queue.Enqueue("Michael");

            // Вывод очереди
            foreach (string item in queue)
                Console.Write($" {item}");
            Console.WriteLine("\n" + new string('-', 42));

            // Извлечение элемента из очереди
            Console.WriteLine("Извлечение элемента из очереди...");
            string firstItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: {firstItem}");          
            Console.WriteLine("\n" + new string('-', 42));

            // Вывод очереди
            foreach (string item in queue)
                Console.Write($" {item}");
            Console.WriteLine("\n" + new string('-', 42));

            // Извлечение элемента из очереди
            Console.WriteLine("Извлечение элемента из очереди...");           
            string firstItem2 = queue.Dequeue();
            Console.WriteLine($"Извлеченный элемент: {firstItem2}");

            char c = 'a';
            int f = firstItem2.CharCount(c);
            if (f == 1)
                Console.WriteLine(new string('-', 42)+$"\nБуква '{c}' присутствовала в '{firstItem2.ToString()}' \n"+ new string('-', 42));
            else Console.WriteLine(new string('-', 42)+$"\nБуква '{c}' не присутствовала в '{firstItem2}' \n"+ new string('-', 42));

            // Вывод очереди
            foreach (string item in queue)
                Console.Write($" {item}");

            // Извлечение элемента из очереди
            Console.WriteLine("\nИзвлечение элемента из очереди...");
            string text = queue.Dequeue();
            int result = text.Search_sum();
            Console.WriteLine(new string('-', 42)+$"\nСумма букв элемента очереди {text} = {result} \n"+ new string('-', 42));

            // Вывод очереди
            foreach (string item in queue)
                Console.Write($" {item}");

            // Извлечение элемента из очереди
            Console.WriteLine("\nИзвлечение элемента из очереди...");
            string text2 = queue.Dequeue();
            int result2 = text2.SumOfLetters();
            if (result2 == 0)
                Console.WriteLine(new string('-', 42)+$"\nСумма букв элемента очереди '{text2}' — это нечётное число \n"+ new string('-', 42));
            else
                Console.WriteLine(new string('-', 42)+$"\n \nСумма букв элемента очереди '{text2}' — это чётное число \n"+ new string('-', 42));

            Queue<int> queue2 = new Queue<int>(10);
            for (int item = 0; item <= 10; item++)
            {
                queue2.Enqueue(item);
            }

            // Вывод очереди
            foreach (int item in queue2)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine();

            // Извлечение элемента из очереди
            Console.WriteLine("Извлечение элемента из очереди...");
            int firstItem3 = queue2.Dequeue();
            Console.WriteLine($"Извлеченный элемент: {firstItem3}");
            Console.WriteLine();

            // Вывод очереди
            foreach (int item in queue2)
                Console.Write($" {item}");

            Console.WriteLine("\n" + new string('-', 20));
            Console.WriteLine("Создание двух новых очередей...");

            // создание первой очереди
            Queue<int> firstQueue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                firstQueue.Enqueue(i);
            }

            // создание второй очереди
            Queue<int> secondtQueue = new Queue<int>();
            for (int i = 20; i < 30; i++)
            {
                secondtQueue.Enqueue(i);
            }

            // вывод первой очереди
            foreach (var item in firstQueue)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            // вывод второй очереди
            foreach (var item in secondtQueue)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            // копирование одной очереди в другую (и вывод на консоль с сортировкой в убывающем порядке)
            Console.WriteLine("\nКопирование одной очереди в другую и вывод на консоль с сортировкой в убывающем порядке...");
            firstQueue = firstQueue.Copy(secondtQueue);           
            foreach (var item in firstQueue.OrderByDescending(s => s))
            {
                Console.Write($" {item}");
            }
           

            Console.ReadKey();
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public string Name { get; set; }     
    }
    public class Queue<T> : IEnumerable<T>
    {     
        Owner person;
        Date datecreation;    
        public static int Id { get; set; }

        Node<T>[] data;
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;

        public Queue()
        {
            data = new Node<T>[5];

            Id = Id + 1;         
            person = new Owner(Id, "Egor Pavlovich", "MITSO");
            datecreation = new Date();
        }

        public Queue(T First)
        {
            data = new Node<T>[5];
            if (head != null)
            {
                head.Data = First;
            }

            Id = Id + 1;
            person = new Owner(Id, "Egor Pavlovich", "MITSO");
            datecreation = new Date();
        }

        public Queue(T First, T Last)
        {
            data = new Node<T>[5];
            head.Data = First;
            tail.Data = Last;

            Id = Id + 1;
            person = new Owner(Id, "Egor Pavlovich", "MITSO");
            datecreation = new Date();
        }

        // индексатор 1
        public Node<T> this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        // индексатор 2
        public Node<T> this[string name]
        {
            get
            {
                Node<T> node = null;
                foreach (var n in data)
                {
                    if (n?.Name == name)
                    {
                        node = n;
                        break;
                    }
                }
                return node;
            }
        }
        #region Перегруженные операторы
        //public static bool operator ==(Queue<T> Q1, Queue<T> Q2)
        //{
        //    return Q1.Equals(Q2);
        //}
        //public static bool operator !=(Queue<T> Q1, Queue<T> Q2)
        //{
        //    return !Q1.Equals(Q2);
        //}
        public int CompareTo(Object obj)
        {
            Queue<T> temp = (Queue<T>)obj;
            if (this.Count > temp.Count) return 1;
            if (this.Count < temp.Count) return -1;
            return 0;
        }
        public static bool operator ==(Queue<T> Q1, Queue<T> Q2)
        {
            return (Q1.CompareTo(Q2) == 0);
        }
        public static bool operator !=(Queue<T> Q1, Queue<T> Q2)
        {
            return (Q1.CompareTo(Q2) != 0);
        }
        //public static bool operator <(Queue<T> Q1, Queue<T> Q2)
        //{
        //    return (Q1.CompareTo(Q2) < 0);
        //}
        //public static bool operator >(Queue<T> Q1, Queue<T> Q2)
        //{
        //    return (Q1.CompareTo(Q2) > 0);
        //}
        public static bool operator <=(Queue<T> Q1, Queue<T> Q2)
        {
            return (Q1.CompareTo(Q2) <= 0);
        }
        public static bool operator >=(Queue<T> Q1, Queue<T> Q2)
        {
            return (Q1.CompareTo(Q2) >= 0);
        }
        //===================================================================================================               
        public static double operator +(Queue<T> first, Queue<T> second)
        {
            return first.doubleValue + second.doubleValue;
        }
        public static double operator +(Queue<T> first, double d)
        {
            return first.doubleValue + d;
        }
        public static double operator +(double d, Queue<T> second)
        {
            return d + second.doubleValue;
        }

        public static bool operator >(Queue<T> first, Queue<T> second)
        {
            if (first.doubleValue > second.doubleValue)
                return true;
            else
                return false;
        }
        public static bool operator <(Queue<T> first, Queue<T> second)
        {
            if (first.doubleValue < second.doubleValue)
                return true;
            else
                return false;
        }

        public static Queue<T> operator ++(Queue<T> d)
        {
            return new Queue<T> { doubleValue = d.doubleValue++, intValue = d.intValue++ };
        }

        public static implicit operator Queue<T>(double d)//
        {
            return new Queue<T> { doubleValue = d };
        }
        public static explicit operator double(Queue<T> Q) //explicit --- int x = (int)queue1; implicit -- int x = queue1;
        {
            return Q.doubleValue;
        }
        #endregion

        public double doubleValue { get; set; }
        public int intValue { get; set; }
        public string stringValue { get; set; }

        // добавление в очередь
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }
        // удаление из очереди
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        // получаем первый элемент
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // получаем последний элемент
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }      
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public Queue<T> Copy(Queue<T> Queue)
        {
            if (count == 0)
                throw new InvalidOperationException("Очередь пустая!");
            else
            {
                Queue<T> tempqueue = new Queue<T>();               
                while (Queue.Count > 0)
                {
                    tempqueue.Enqueue(Queue.Dequeue());                   
                }               
                return tempqueue;
            }
        }
    }
    public class Owner /*Владелец*/
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organisation { get; set; }

        public Owner(int Id, string Name, string Organisation)
        {
            this.Id = Id;
            this.Name = Name;
            this.Organisation = Organisation;
        }
        public Owner(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;           
        }
    }
    public class Date /*(Дата создания)*/
    {      
        public DateTime dateTimeNow { get; set; }

        public string name;
        public DateTime birth;
        public DateTime? death;                
        public Date()
        {           
            dateTimeNow = DateTime.Now;        
        }
        public void Age(string name, DateTime birth, DateTime? death)/*вычисление возраста*/
        {
            this.birth = birth;
            this.death = death;
            this.name = name;
        }
    }
}

public static class MathObject 
{
    private static int minAge = 18;
    public static int GetAge
    {
        get { return minAge; }
        set { if (value > 0) minAge = value; }
    }

    public static bool IsEmpty { get; private set; }

    public static int CharCount(this string data, char c)
    {
        int counter = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == c)
                counter++;
        }
        return counter;
    }

    //сумма букв первого элемента очереди 
    public static int Search_sum(this string data)
    {
        int sum = 0;
        foreach (int item in data)     
            sum += 1;
        return sum;
    }

    //проверка на чётность суммы букв первого элемента очереди
    public static int SumOfLetters(this string data)
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        foreach (int item in data)
            if (item % 2 == 0)
            {
                return 0;
            }
        return Convert.ToInt32(data);
    }

    public static string ToString(this string data)
    {
        string s = null;
        foreach (int key in data)
            s += data[key] + " ";
        return s;
    }
}
