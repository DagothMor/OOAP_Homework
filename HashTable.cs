using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public abstract class AbstractHashTable<T>
    {

        // конструктор
        // постусловие: создана пустая хэштаблица.
        public AbstractHashTable()
        {

        }

        public abstract int Count();

        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public const int GET_PUT_NILL = 0;
        public const int GET_PUT_OK = 1;
        public const int GET_PUT_ERR = 2;
        protected int _getPutStatus;
        public abstract int GetPutStatus();
        public abstract void Put(T Value);

        public const int GET_FIND_NILL = 0;
        public const int GET_FIND_OK = 1;
        public const int GET_FIND_ERR = 2;
        protected int _getFindStatus;
        public abstract int GetFindStatus();

        // Запрос
        // Предусловие: таблица не пуста.
        public abstract bool Find(T Value);

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _getRemoveStatus;
        public abstract int GetRemoveStatus();

        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public abstract void Remove(T Value);

    }
    public class HashTable<T> : AbstractHashTable<T>
    {
        public int size;
        public int step;
        public T[] slots;

        public HashTable(int sz)
        {
            size = sz;
            step = 1;
            slots = new T[size];
            for (int i = 0; i < size; i++) slots[i] = default;
        }



        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public const int GET_PUT_NILL = 0;
        public const int GET_PUT_OK = 1;
        public const int GET_PUT_ERR = 2;
        protected int _getPutStatus;
        public override int GetPutStatus() => _getPutStatus;
        public override void Put(T value)
        {
            var index = SeekSlot(value);
            if (index != -1)
            {
                slots[index] = value;
                _getPutStatus = GET_PUT_OK;
                return;
            }
            _getPutStatus = GET_PUT_ERR;
        }

        public const int GET_FIND_NILL = 0;
        public const int GET_FIND_OK = 1;
        public const int GET_FIND_ERR = 2;
        protected int _getFindStatus;
        public override int GetFindStatus() => _getFindStatus;

        // Запрос
        // Предусловие: таблица не пуста.
        public override bool Find(T value)
        {
            int index = HashFun(value);
            var firstValue = slots[index];
            var bufferValue = firstValue;

            if (bufferValue.Equals(value)) 
            {
                _getFindStatus = GET_FIND_OK;
                return true;
            }
            
            do
            {
                index += step;
                while (index >= slots.Length)
                {
                    index -= slots.Length;
                }
                bufferValue = slots[index];
                if (bufferValue.Equals(default))
                {
                    _getFindStatus = GET_FIND_ERR;
                    return false;
                }

                if (bufferValue.Equals(value))
                {
                    _getFindStatus = GET_FIND_OK;
                    return true;
                }            }
            while (!bufferValue.Equals(firstValue));

            return false;
        }

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _getRemoveStatus;
        public override int GetRemoveStatus() => _getRemoveStatus;

        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public override void Remove(T value)
        {
            var index = SeekSlot(value);
            if (index != -1)
            {
                slots[index] = default;
                _getRemoveStatus = REMOVE_OK;
                return;
            }
            _getRemoveStatus = REMOVE_ERR;
        }

        private int HashFun(T value)
        {
            return value.GetHashCode() % size;
        }

        private int SeekSlot(T value)
        {
            int index = HashFun(value);
            var firstValue = slots[index];
            var bufferValue = firstValue;
            if (slots[index].Equals(default)) return index;
            do
            {
                index += step;
                while (index >= slots.Length)
                {
                    index -= slots.Length;
                }
                bufferValue = slots[index];
                if (bufferValue.Equals(default)) return index;
            }
            while (bufferValue.Equals(firstValue));
            return -1;
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }
    }
}
