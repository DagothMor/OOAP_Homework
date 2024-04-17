using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public abstract class AbstractParentQueue<T>
    {
        private System.Collections.Generic.LinkedList<T> list { get; set; }

        // конструктор
        // постусловие: создана пустая очередь
        public AbstractParentQueue(System.Collections.Generic.LinkedList<T> list)
        {
            this.list = list;
        }

        public const int GET_ENQUEUE_NILL = 0;
        public const int GET_ENQUEUE_OK = 1;
        public const int GET_ENQUEUE_ERR = 2;
        protected int _getEnqueueStatus;
        public int GetAddTailStatus() => _getEnqueueStatus;
        public void AddTail(T item)
        {
            if (list == null)
            {
                _getEnqueueStatus = GET_ENQUEUE_ERR;
                return;
            }
            _getEnqueueStatus = GET_ENQUEUE_OK;
            list.AddLast(item);
        }

        public const int GET_FIRST_ELEMENT_IN_QUEUE_NILL = 0;
        public const int GET_FIRST_ELEMENT_IN_QUEUE_OK = 1;
        public const int GET_FIRST_ELEMENT_IN_QUEUE_ERR = 2;
        protected int _getFirstElementInQueueStatus;
        public int GetGetHeadStatus() => _getFirstElementInQueueStatus;

        public T GetHead()
        {
            if (list.Count == 0)
            {
                _getFirstElementInQueueStatus = GET_FIRST_ELEMENT_IN_QUEUE_ERR;
                return default;
            }
            _getFirstElementInQueueStatus = GET_FIRST_ELEMENT_IN_QUEUE_OK;
            return list.First();
        }

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _getRemoveStatus;
        public int GetRemoveHeadStatus() => _getRemoveStatus;
        public void RemoveHead()
        {
            if (list.Count == 0)
            {
                _getRemoveStatus = REMOVE_ERR;
                return;
            }
            _getRemoveStatus = REMOVE_OK;
            list.RemoveFirst();
        }

    }

    public abstract class AbstractDequeue<T> : AbstractParentQueue<T>
    {
        protected AbstractDequeue(System.Collections.Generic.LinkedList<T> list) : base(list)
        {
        }

        // команды
        // вставка в голову
        // предусловие: нет; 
        // постусловие: Добавлен новый элемент в очередь
        public abstract void AddHead(T item);

        // Удалить элемент из хвоста
        // предусловие: очередь не пуста; 
        // постусловие: Удален элемент из очереди
        public abstract void RemoveTail();

        // запросы
        // Получение элемента из хвоста.
        // предусловие: очередь не пуста; 
        public abstract T GetTail();

        // запросы статусов
        public abstract int GetAddHeadStatus(); // успешно; Добавлен новый элемент в начало
        public abstract int GetGetTailStatus(); // успешно; Получен первый элемент из хвоста
        public abstract int GetRemoveTailStatus(); // успешно; Удален элемент из хвоста
    }
    public class MyDequeue<T> : AbstractDequeue<T>
    {
        private System.Collections.Generic.LinkedList<T> list { get; set; }

        // конструктор
        // постусловие: создана пустая очередь
        public MyDequeue(System.Collections.Generic.LinkedList<T> list) : base(list) { }

        public const int GET_ADD_HEAD_NILL = 0;
        public const int GET_ADD_HEAD_OK = 1;
        public const int GET_ADD_HEAD_ERR = 2;
        protected int _getAddHeadStatus;
        public override int GetAddHeadStatus() => _getAddHeadStatus;
        public override void AddHead(T item)
        {
            if (list == null)
            {
                _getAddHeadStatus = GET_ADD_HEAD_ERR;
                return;
            }
            _getAddHeadStatus = GET_ADD_HEAD_OK;
            list.AddFirst(item);
        }

        public const int GET_GET_TAIL_NILL = 0;
        public const int GET_GET_TAIL_OK = 1;
        public const int GET_GET_TAIL_ERR = 2;
        protected int _getGetTailStatus;
        public override int GetGetTailStatus() => _getGetTailStatus;

        public override T GetTail()
        {
            if (list.Count == 0)
            {
                _getGetTailStatus = GET_GET_TAIL_ERR;
                return default;
            }
            _getGetTailStatus = GET_GET_TAIL_OK;
            return list.Last();
        }


        public const int REMOVE_TAIL_NILL = 0;
        public const int REMOVE_TAIL_OK = 1;
        public const int REMOVE_TAIL_ERR = 2;
        protected int _getRemoveTailStatus;
        public override int GetRemoveTailStatus() => _getRemoveTailStatus;
        public override void RemoveTail()
        {
            if (list.Count == 0)
            {
                _getRemoveStatus = REMOVE_ERR;
                return;
            }
            _getRemoveStatus = REMOVE_OK;
            list.RemoveLast();
        }
    }
    public class MyQueue<T> : AbstractParentQueue<T>
    {
        public MyQueue(System.Collections.Generic.LinkedList<T> list) : base(list)
        {
        }
    }
}
