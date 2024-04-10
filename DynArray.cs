using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public class DynArray<T>
    {
        private readonly int START_CAPACITY = 16;
        private readonly int MULTIPLY_CAPACITY = 2;
        private readonly double DIVIDE_CAPACITY = 1.5;

        public T[] array;
        public int count;
        private int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(START_CAPACITY);
        }

        public const int MAKE_ARRAY_NILL = 0;
        public const int MAKE_ARRAY_OK = 1;
        public const int MAKE_ARRAY_ERR = 2;
        protected int _getMakeArray;
        public int GetMakeArrayStatus() => _getMakeArray;
        // Сделано
        // Команда
        // Пересоздать массив с указанной емкостью
        // Предусловие
        public void MakeArray(int new_capacity)
        {
            if(new_capacity < 0)
            {
                _getMakeArray= MAKE_ARRAY_ERR;
                return;
            }
            if (new_capacity < START_CAPACITY) new_capacity = START_CAPACITY;

            T[] temp = new T[new_capacity];
            for (int i = 0; i < count; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
            capacity = new_capacity;
            _getMakeArray = MAKE_ARRAY_OK;
        }

        public const int GET_ITEM_NILL = 0;
        public const int GET_ITEM_OK = 1;
        public const int GET_ITEM_ERR = 2;
        protected int _getItemStatus;
        public int GetGetItemStatus() => _getItemStatus;

        // Сделано
        // Запрос
        // Получить элемент по индексу.
        // Предусловие: индекс не должен быть ниже нуля
        // Предусловие: индекс не должен быть больше количества элементов
        public T GetItem(int index)
        {
            // Добавлены булевы для удобочитаемости
            bool indexIsLast = index > count - 1;
            bool indexIsOutOfZero = index > 0;
            if (indexIsLast || indexIsOutOfZero) { 
                _getItemStatus = GET_ITEM_ERR;
                return default;
            }
            _getItemStatus = GET_ITEM_OK;
            return array[index];
        }

        public const int APPEND_NILL = 0;
        public const int APPEND_OK = 1;
        public const int APPEND_ERR = 2;
        protected int _getAppendStatus;
        public int GetAppendStatus() => _getAppendStatus;
        // Сделано
        // Команда
        // Предусловие: список не должен быть переполнен
        public void Append(T item)
        {
            if (count >= capacity)
            {
                _getAppendStatus = APPEND_ERR;
                return;
            }
            array[count] = item;
            count++;
            _getAppendStatus = APPEND_OK;
        }

        public const int EXTEND_ARRAY_NILL = 0;
        public const int EXTEND_ARRAY_OK = 1;
        public const int EXTEND_ARRAY_ERR = 2;
        protected int _extendArrayStatus;
        public int GetExtendArrayStatus() => _extendArrayStatus;

        // Команда
        // Предусловие: память для нового массива должна быть выделена.
        // Постусловие: массив увеличен
        public void ExtendArray()
        {
            try
            {
                var new_capacity = capacity * MULTIPLY_CAPACITY;

                // Может закончиться память в куче.
                T[] temp = new T[new_capacity];
                for (int i = 0; i < count; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
                capacity = new_capacity;
                _extendArrayStatus = EXTEND_ARRAY_OK;
                return;
            }
            catch (Exception)
            {
                _extendArrayStatus = EXTEND_ARRAY_ERR;
                return;
            }
        }


        public const int REDUCE_ARRAY_NILL = 0;
        public const int REDUCE_ARRAY_OK = 1;
        public const int REDUCE_ARRAY_ERR = 2;
        protected int _reduceArrayStatus;
        public int GetReduceArrayStatus() => _reduceArrayStatus;

        // Команда
        // Постусловие: массив уменьшен
        public void ReduceArray()
        {
            if(capacity <= START_CAPACITY)
            {
                _reduceArrayStatus = REDUCE_ARRAY_ERR;
                return;
            }
            var new_capacity = (int)Math.Ceiling((decimal)(capacity / DIVIDE_CAPACITY));

            if ( count - 2 > new_capacity)
            {
                _reduceArrayStatus = REDUCE_ARRAY_ERR;
                return;
            }
            T[] temp = new T[new_capacity];
            for (int i = 0; i < count; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
            capacity = new_capacity;
            _reduceArrayStatus = REDUCE_ARRAY_OK;
            return;
        }


        public const int INSERT_NILL = 0;
        public const int INSERT_OK = 1;
        public const int INSERT_ERR = 2;
        protected int _insertStatus;
        public int GetInsertStatus() => _insertStatus;
        public void Insert(T itm, int index)
        {
            if (index > count || index < 0 || count == capacity)
            {
                _insertStatus = INSERT_ERR;
                return;
            }
            T[] temp = new T[capacity];

            for (int i = 0; i < index; i++)
            {
                temp[i] = array[i];
            }

            temp[index] = itm;

            for (int i = index + 1; i <= count; i++)
            {
                temp[i] = array[i - 1];
            }

            array = temp;

            count++;
            _insertStatus = INSERT_OK;
        }

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _removeStatus;
        public int GetRemoveStatus() => _removeStatus;
        public void Remove(int index)
        {
            if (index > count - 1 || index < 0)
            {
                _removeStatus = REMOVE_ERR;
                return;
            }

            T[] temp = new T[capacity];

            for (int i = 0; i < index; i++)
            {
                temp[i] = array[i];
            }
            for (int i = index + 1; i < count; i++)
            {
                temp[i - 1] = array[i];
            }

            array = temp;
            count--;
            _removeStatus = REMOVE_OK; 
        }

    }
}
