using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public abstract class AbstractBloomFilter<T>
    {
        protected bool[] _filter;

        // конструктор
        // постусловие: создан пустой битовый массив с определенным объемом.
        public AbstractBloomFilter(int size)
        {
            _filter = new bool[size];
        }

        public const int GET_PUT_NILL = 0;
        public const int GET_PUT_OK = 1;
        public const int GET_PUT_ERR = 2;
        protected int _getPutStatus;
        public abstract int GetPutStatus();

        // Команда
        // Предусловие:
        // Постусловие: внутренний массив по полученным от хэш сумм индексам помечен.
        public abstract void Put(T Value);

        public const int GET_IS_VALUE_NILL = 0;
        public const int GET_IS_VALUE_OK = 1;
        public const int GET_IS_VALUE_ERR = 2;
        protected int _getIsValueStatus;
        public abstract int GetIsValueStatus();

        // Запрос
        // Предусловие: индексы всех хэш сумм положительны в массиве байтов.
        public abstract bool IsValue(T Value);
        protected abstract int hashFunc(T Value);

    }

    public class BloomFilter<T> : AbstractBloomFilter<T>
    {
        public BloomFilter(int size) : base(size)
        {

        }

        public override int GetIsValueStatus() => _getIsValueStatus;

        public override int GetPutStatus() => _getPutStatus;

        public override bool IsValue(T Value)
        {
            int hashValue = hashFunc(Value);

            if(_filter[hashValue] == true)
            {
                _getIsValueStatus = GET_IS_VALUE_OK;
                return true;
            }
            _getIsValueStatus = GET_IS_VALUE_ERR;
            return false;

        }

        public override void Put(T Value)
        {
            int hashValue = hashFunc(Value);

            if (_filter[hashValue] == true)
            {
                _getPutStatus = GET_PUT_ERR;
                return;
            }
            _getPutStatus = GET_PUT_OK;
            _filter[hashValue] = true;
            return;
        }

        protected override int hashFunc(T Value)
        {
            return Value.GetHashCode() % _filter.Length;
        }
    }
}
