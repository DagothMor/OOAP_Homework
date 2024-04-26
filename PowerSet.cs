using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public abstract class AbstractPowerSet<T> : AbstractHashTable<T>
    {

        public const int INTERSECTION_NILL = 0;
        public const int INTERSECTION_OK = 1;
        public const int INTERSECTION_ERR = 2;
        protected int _getIntersectionStatus;
        public abstract int GetIntersectionStatus();
        public abstract AbstractPowerSet<T> Intersection(AbstractPowerSet<T> set2);

        public const int UNION_NILL = 0;
        public const int UNION_OK = 1;
        public const int UNION_ERR = 2;
        protected int _getUnionStatus;
        public abstract int GetUnionStatus();
        public abstract AbstractPowerSet<T> Union(AbstractPowerSet<T> set2);

        public const int DIFFERENCE_NILL = 0;
        public const int DIFFERENCE_OK = 1;
        public const int DIFFERENCE_ERR = 2;
        protected int _getDifferenceStatus;
        public abstract int GetDifferenceStatus();

        public abstract AbstractPowerSet<T> Difference(AbstractPowerSet<T> set2);

        public const int IS_SUBSET_NILL = 0;
        public const int IS_SUBSET_OK = 1;
        public const int IS_SUBSET_ERR = 2;
        protected int _getIsSubsetStatus;
        public abstract int GetIsSubsetStatus();
        public abstract bool IsSubset(AbstractPowerSet<T> set2);
    }
    public class Powerset<T> : AbstractPowerSet<T>
    {
        public int size;
        public int step;
        public T[] slots;

        public Powerset(int sz)
        {
            size = sz;
            step = 1;
            slots = new T[size];
            for (int i = 0; i < size; i++) slots[i] = default;
        }

        // Команда
        // Предусловие: множество не заполнено
        // Постусловие: добавлено новое значение в таблицу
        public const int GET_PUT_NILL = 0;
        public const int GET_PUT_OK = 1;
        public const int GET_PUT_ERR = 2;
        protected int _getPutStatus;
        public override int GetPutStatus() => _getPutStatus;
        public override void Put(T value)
        {
            if (Find(value))
            {
                _getPutStatus = GET_PUT_ERR;
                return;
            }
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
        // Предусловие: множество не пусто.
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
                }
            }
            while (!bufferValue.Equals(firstValue));

            return false;
        }

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _getRemoveStatus;

        public override int GetRemoveStatus() => _getRemoveStatus;

        // Команда
        // Предусловие: множество не пустое и содержит удаляемый элемент.
        // Постусловие: удалено значение из множества.
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

        public override int GetIntersectionStatus() => _getIntersectionStatus;

        // Запрос
        // Предусловие: множество не пусто.
        public override AbstractPowerSet<T> Intersection(AbstractPowerSet<T> set2)
        {
            var list = new List<T>();

            foreach (var slot in slots)
            {
                if (set2.Find(slot))
                {
                    list.Add(slot);
                }
            }
            var newPowerSet = new Powerset<T>(list.Count);
            foreach (var item in list)
            {
                newPowerSet.Put(item);
            }
            return newPowerSet;
        }

        public override int GetUnionStatus() => _getUnionStatus;

        // Запрос
        // Предусловие: множество не пусто.
        public override AbstractPowerSet<T> Union(AbstractPowerSet<T> set2)
        {

            var setFrom = (Powerset<T>)set2;

            foreach (var slot in slots)
            {
                setFrom.Put(slot);
            }

            return setFrom;
        }

        public override int GetDifferenceStatus() => _getDifferenceStatus;

        // Запрос
        // Предусловие: множество не пусто.
        public override AbstractPowerSet<T> Difference(AbstractPowerSet<T> set2)
        {
            var list = new List<T>();

            foreach (var slot in slots)
            {
                if (!set2.Find(slot))
                {
                    list.Add(slot);
                }
            }
            var newPowerSet = new Powerset<T>(list.Count);
            foreach (var item in list)
            {
                newPowerSet.Put(item);
            }
            return newPowerSet;
        }

        public override int GetIsSubsetStatus() => _getIsSubsetStatus;

        // Запрос
        // Предусловие: множество не пусто.
        public override bool IsSubset(AbstractPowerSet<T> set2)
        {
            foreach (var item in slots)
            {
                if (!set2.Find(item))
                {
                    _getIsSubsetStatus = IS_SUBSET_ERR;
                    return false;
                }
            }
            _getIsSubsetStatus = IS_SUBSET_OK;
            return true;
        }

        // Запрос
        public override int Count()=>slots.Length;
    }
}
