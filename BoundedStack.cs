using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public class BoundedStack<T>
    {
        private List<T> stack;
        private int peek_status;
        private int pop_status;
        private int push_status;
        private int maxCount;
        private const int DEFAULT_MAX_COUNT_OF_ELEMENT = 32;

        public const int POP_NIL = 0;
        public const int POP_OK = 1;
        public const int POP_ERR = 2;

        public const int PEEK_NIL = 0;
        public const int PEEK_OK = 1;
        public const int PEEK_ERR = 2;

        public const int PUSH_NIL = 0;
        public const int PUSH_OK = 1;
        public const int PUSH_ERR = 2;

        public BoundedStack()
        {
            stack = new List<T>();
            Clear();
            this.maxCount = DEFAULT_MAX_COUNT_OF_ELEMENT;
        }
        public BoundedStack(int maxCount)
        {
            stack = new List<T>();
            Clear();
            this.maxCount = maxCount;
        }
        public void Push(T value)
        {
            if (maxCount == Size())
            {
                push_status = PUSH_ERR;
                return;
            }
            stack.Add(value);
            push_status = PUSH_OK;
        }

        public void Pop()
        {
            if (Size() == 0)
            {
                pop_status = POP_ERR;
                return;
            }
            stack.RemoveAt(stack.Count - 1);
            pop_status = POP_OK;
        }

        public void Clear()
        {
            stack.Clear();
            peek_status = PEEK_NIL;
            pop_status = POP_NIL;
            push_status = POP_NIL;
        }

        public T Peek()
        {
            T result;
            if (Size() > 0)
            {
                result = stack[stack.Count() - 1];
                peek_status = PEEK_OK;
            }
            else
            {
                result = default; // дефолтное значение или все же null?
                peek_status = PEEK_ERR;
            }
            return result;
        }

        public int Size()
        {
            return stack.Count();
        }

        // запросы статусов
        public int Get_pop_status() => pop_status;
        public int Get_peek_status() => peek_status; 
        public int Get_push_status() => push_status; 

    }
}
