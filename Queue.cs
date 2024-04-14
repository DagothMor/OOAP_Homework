using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public abstract class Queue<T>
    {
        // конструктор
        // постусловие: создана пустая очередь
        protected Queue()
        {

        }

        // команды
        // вставка в хвост
        // предусловие: нет; 
        // постусловие: Добавлен новый элемент в очередь
        public abstract void Enqueue(T item);

        // Удалить элемент из головы
        // предусловие: очередь не пуста; 
        // постусловие: Удален элемент из очереди
        public abstract void RemoveElement();

        // запросы
        // Получение первого элемента.
        // предусловие: очередь не пуста; 
        public abstract T GetFirstElementInQueue();

        // запросы статусов
        public abstract int GetEnqueueStatus(); // успешно; Добавлен новый элемент в очередь
        public abstract int GetFirstElementInQueueStatus(); // успешно; Получен первый элемент в очереди
        public abstract int GetRemoveStatus(); // успешно; Удален элемент из очереди

    }

    public class MyQueue<T> : Queue<T>
    {
        private System.Collections.Generic.LinkedList<T> list { get; set; }

        // конструктор
        // постусловие: создана пустая очередь
        public MyQueue(System.Collections.Generic.LinkedList<T> list)
        {
            this.list = list;
        }

        public const int GET_ENQUEUE_NILL = 0;
        public const int GET_ENQUEUE_OK = 1;
        public const int GET_ENQUEUE_ERR = 2;
        protected int _getEnqueueStatus;
        public override int GetEnqueueStatus() => _getEnqueueStatus;
        public override void Enqueue(T item)
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
        public override int GetFirstElementInQueueStatus() => _getFirstElementInQueueStatus;

        public override T GetFirstElementInQueue()
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
        public override int GetRemoveStatus() => _getRemoveStatus;
        public override void RemoveElement()
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
}
