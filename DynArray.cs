using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private int coursor;

        public DynArray()
        {
            count = 0;
            array = new T[START_CAPACITY];
        }

        public const int HEAD_NILL = 0;
        public const int HEAD_OK = 1;
        public const int HEAD_ERR = 2;
        protected int _headStatus;
        public int GetHeadStatus() => _headStatus;

        // +
        // Команда
        // Предусловие: массив не пуст; 
        // Постусловие: курсор установлен на первый элемент в массиве
        public void Head()
        {
            if (count == 0)
            {
                _headStatus = HEAD_ERR;
                return;
            }
            coursor = 0;
            _headStatus = HEAD_OK;
        }

        public const int TAIL_NILL = 0;
        public const int TAIL_OK = 1;
        public const int TAIL_ERR = 2;
        protected int _tailStatus;
        public int GetTailStatus() => _tailStatus;

        // +
        // Команда
        // Предусловие: массив не пуст; 
        // Постусловие: курсор установлен на последний элемент в массиве
        public void Tail()
        {
            if (count == 0)
            {
                _tailStatus = TAIL_ERR;
                return;
            }
            coursor = count-1;
            _tailStatus = TAIL_OK;
        }

        public const int RIGHT_NILL = 0;
        public const int RIGHT_OK = 1;
        public const int RIGHT_ERR = 2;
        protected int _rightStatus;
        public int GetRightStatus() => _rightStatus;

        // +
        // Команда
        // Предусловие: курсор не указывает на последний элемент 
        // Постусловие: курсор инкрементирован
        public void Right()
        {
            if (coursor == count -1)
            {
                _rightStatus = RIGHT_ERR;
                return;
            }
            coursor++;
            _rightStatus = RIGHT_OK;
        }

        public const int INSERT_BEFORE_NILL = 0;
        public const int INSERT_BEFORE_OK = 1;
        public const int INSERT_BEFORE_ERR = 2;
        protected int _insertBeforeStatus;
        public int GetInsertBeforeStatus() => _insertBeforeStatus;

        // +
        // Команда
        // предусловие: массив не пуст; 
        // постусловие: следом за текущим индексом курсора, добавлено новое значение.
        public void InsertBefore(T value)
        {
            if (coursor > count || coursor < 0 || count == capacity)
            {
                _insertStatus = INSERT_ERR;
                return;
            }
            T[] temp = new T[capacity];

            for (int i = 0; i < coursor; i++)
            {
                temp[i] = array[i];
            }
            temp[coursor] = value;

            for (int i = coursor + 1; i <= count; i++)
            {
                temp[i-1] = array[i - 1];
            }

            array = temp;

            count++;
            _insertStatus = INSERT_OK;
        }


        public const int INSERT_AFTER_NILL = 0;
        public const int INSERT_AFTER_OK = 1;
        public const int INSERT_AFTER_ERR = 2;
        protected int _insertAfterStatus;

        public int GetInsertAfterStatus() => _insertAfterStatus;

        // +
        // Команда.
        // предусловие: массив не пуст; 
        // постусловие: следом за текущим узлом добавлен 
        // новый массив с заданным значением после курсора
        public void InsertAfter(T value)
        {
            if (coursor > count || coursor < 0 || count == capacity)
            {
                _insertStatus = INSERT_ERR;
                return;
            }
            T[] temp = new T[capacity];

            for (int i = 0; i < coursor; i++)
            {
                temp[i] = array[i];
            }
            temp[coursor] = value;

            for (int i = coursor + 1; i <= count; i++)
            {
                temp[i] = array[i - 1];
            }

            array = temp;

            count++;
            _insertStatus = INSERT_OK;
        }


        public const int MAKE_ARRAY_NILL = 0;
        public const int MAKE_ARRAY_OK = 1;
        public const int MAKE_ARRAY_ERR = 2;
        protected int _makeArrayStatus;
        public int GetMakeArrayStatus() => _makeArrayStatus;
        // +
        // Команда
        // Пересоздать массив с указанной емкостью
        // Предусловие емкость должна быть больше емкости по умолчанию
        // Предусловие емкость должна быть больше количества элементов
        public void MakeArray(int new_capacity)
        {
            if(new_capacity < 0)
            {
                _makeArrayStatus = MAKE_ARRAY_ERR;
                return;
            }
            if(count > new_capacity)
            {
                _makeArrayStatus = MAKE_ARRAY_ERR;
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
            _makeArrayStatus = MAKE_ARRAY_OK;
        }

        public const int GET_ITEM_BY_INDEX_NILL = 0;
        public const int GET_ITEM_BY_INDEX_OK = 1;
        public const int GET_ITEM_BY_INDEX_ERR = 2;
        protected int _getItemByIndexStatus;
        public int GetItemByIndexStatus() => _getItemByIndexStatus;

        // +
        // Запрос
        // Получить элемент по индексу.
        // Предусловие: индекс не должен быть ниже нуля
        // Предусловие: индекс не должен быть больше количества элементов
        public T GetItemByIndex(int index)
        {
            if(index >= capacity || index >= count || index < 0)
            {
                _getItemByIndexStatus = GET_ITEM_BY_INDEX_ERR;
                return default;
            }
            _getItemByIndexStatus = GET_ITEM_BY_INDEX_OK;
            return array[coursor];
        }

        public const int GET_ITEM_NILL = 0;
        public const int GET_ITEM_OK = 1;
        public const int GET_ITEM_ERR = 2;
        protected int _getItemStatus;
        public int GetGetItemStatus() => _getItemStatus;

        // +
        // Запрос
        // Получить элемент от курсора.
        // Предусловие: курсор должен находится в границах массива.
        public T GetItem()
        {
            if (coursor >= capacity || coursor >= count || coursor < 0)
            {
                _getItemStatus = GET_ITEM_ERR;
                return default;
            }
            _getItemStatus = GET_ITEM_OK;
            return array[coursor];
        }

        public const int APPEND_NILL = 0;
        public const int APPEND_OK = 1;
        public const int APPEND_ERR = 2;
        protected int _getAppendStatus;
        public int GetAppendStatus() => _getAppendStatus;
        // +
        // Команда
        // Добавление элемента в конец массива
        // Предусловие: массив не должен быть переполнен
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

        // +
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

        // +
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

        //// Команда
        //// Предусловие: индекс находится в границах от 0 до количества элементов.
        //// Предусловие: массив не заполнен полностью.
        //public void Insert(T itm, int index)
        //{
        //    if (index > count || index < 0 || count == capacity)
        //    {
        //        _insertStatus = INSERT_ERR;
        //        return;
        //    }
        //    T[] temp = new T[capacity];

        //    for (int i = 0; i < index; i++)
        //    {
        //        temp[i] = array[i];
        //    }

        //    temp[index] = itm;

        //    for (int i = index + 1; i <= count; i++)
        //    {
        //        temp[i] = array[i - 1];
        //    }

        //    array = temp;

        //    count++;
        //    _insertStatus = INSERT_OK;
        //}

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _removeStatus;
        public int GetRemoveStatus() => _removeStatus;

        // +
        // Команда
        // Предусловие: индекс находится в границах от 0 до количества элементов.
        // Предусловие: массив не заполнен полностью.
        // Постусловие: создается новый массив без указанного элемента.
        public void Remove()
        {
            if (coursor > count - 1 || coursor < 0)
            {
                _removeStatus = REMOVE_ERR;
                return;
            }

            T[] temp = new T[capacity];

            for (int i = 0; i < coursor; i++)
            {
                temp[i] = array[i];
            }
            for (int i = coursor + 1; i < count; i++)
            {
                temp[i - 1] = array[i];
            }

            array = temp;
            count--;
            _removeStatus = REMOVE_OK; 
        }

        public const int FIND_NILL = 0;
        public const int FIND_OK = 1;
        public const int FIND_ERR = 2;
        protected int _findStatus;
        public int GetFindStatus() => _findStatus;

        // +
        // Команда.
        // постусловие: курсор установлен на индекс с найденным значением, если такое найдено.
        public void Find(T value)
        {
            for (int i = coursor; i < count; i++)
            {
                if (array[i].Equals(value))
                {
                    _findStatus = FIND_OK;
                    coursor = i;
                    return;
                }
            }
            _findStatus = FIND_ERR;
        }

        public const int REPLACE_NILL = 0;
        public const int REPLACE_OK = 1;
        public const int REPLACE_ERR = 2;
        protected int _replaceStatus;
        public int GetReplaceStatus() => _replaceStatus;

        // +
        // Команда
        // предусловие: массив не пуст;
        // предусловие: курсор в границах массива;
        // постусловие: значение текущего индекса заменено на новое
        public void Replace(T value)
        {
            if (coursor > count - 1 || coursor < 0)
            {
                _replaceStatus = REPLACE_ERR;
                return;
            }
            array[coursor] = value;
            _replaceStatus = REPLACE_OK;
        }


        public const int REMOVE_ALL_NILL = 0;
        public const int REMOVE_ALL_OK = 1;
        public const int REMOVE_ALL_ERR = 2;
        protected int _removeAllStatus;
        public int GetRemoveAllStatus() => _removeAllStatus;

        // +
        // Команда
        // Предусловие: массив не пуст
        // Постусловие: в массиве удалены все узлы с заданным значением
        // нет смысла вызывать атомарную функцию Remove постоянно, сложность будет O(N*N)
        public void RemoveAll(T value)
        {
            var list = new List<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].Equals(value))
                {
                    list.Add(array[i]);
                }
            }
            var newArray = new T[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                newArray[i] = list[i];
            }
            _removeAllStatus = array.Length >= newArray.Length ? REMOVE_ALL_OK : REMOVE_ALL_ERR;
            array = newArray;
        }


        // Команда.
        // постусловие: массив очищен от всех элементов
        public void Clear()
        {
            count = 0;
            array = new T[capacity];
            coursor = 0;

            _getAppendStatus = APPEND_NILL;
            //...
        }
    }
}
