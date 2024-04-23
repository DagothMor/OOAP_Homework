using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    public abstract class AbstractNativeDictionary<T>
    {
        // конструктор
        // постусловие: создан пустой словарь.
        public AbstractNativeDictionary()
        {

        }

        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public const int GET_PUT_NILL = 0;
        public const int GET_PUT_OK = 1;
        public const int GET_PUT_ERR = 2;
        protected int _getPutStatus;
        public abstract int GetPutStatus();
        public abstract void Put(string Key,T Value);

        public const int GET_BY_KEY_NILL = 0;
        public const int GET_BY_KEY_OK = 1;
        public const int GET_BY_KEY_ERR = 2;
        protected int _getGetByKeyStatus;
        public abstract int GetGetByKeyStatus();

        // Запрос
        // Предусловие: таблица не пуста.
        public abstract T GetByKey(string Key);

        public const int REMOVE_NILL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int _getRemoveStatus;
        public abstract int GetRemoveStatus();

        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public abstract void Remove(string Key);


        public const int UPDATE_NILL = 0;
        public const int UPDATE_OK = 1;
        public const int UPDATE_ERR = 2;
        protected int _getUpdateStatus;
        public abstract int GetUpdateStatus();

        // Команда
        // Предусловие: таблица не заполнена
        // Постусловие: добавлено новое значение в таблицу
        public abstract void Update(string Key, T value);

    }
    public class KVP<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }

        public KVP(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
    public class NativeDictionary<T> : AbstractNativeDictionary<T>
    {
        private List<KVP<T>>[] table;

        public NativeDictionary(int size)
        {
            table = new List<KVP<T>>[size];
            for (int i = 0; i < size; i++)
            {
                table[i] = new List<KVP<T>>();
            }
        }

        public override int GetGetByKeyStatus()=> _getGetByKeyStatus;
        // Запрос.
        // Предусловие: ключ существует в словаре.
        public override T GetByKey(string Key)
        {
            int index = HashFunc(Key);
            var item = table[index].Find(p => p.Key == Key);
            if (item != null)
            {
                _getGetByKeyStatus = GET_BY_KEY_OK;
                return item.Value;
            }
            _getGetByKeyStatus = GET_BY_KEY_ERR;
            return default;
        }

        public override int GetPutStatus() => _getPutStatus;

        // Команда
        // Предусловие: ключ не был ранее добавлен
        // Постусловие: добавлена пара в словарь.
        public override void Put(string Key, T Value)
        {
            int index = HashFunc(Key);

            var item = table[index].Find(p => p.Key == Key);
            if (item != null)
            {
                _getPutStatus = GET_PUT_ERR;
                return;
            }
            table[index].Add(new KVP<T>(Key, Value));
            _getPutStatus = GET_PUT_OK;
            return;
        }
        public override int GetRemoveStatus() => _getRemoveStatus;

        // Команда
        // Предусловие: ключ существует в словаре.
        // Постусловие: удалена пара из словаря.
        public override void Remove(string Key)
        {
            int index = HashFunc(Key);
            var item = table[index].Find(p => p.Key == Key);
            if (item != null)
            {
                _getUpdateStatus = UPDATE_OK;
                table[index].Remove(item);
                return;
            }
            _getUpdateStatus = UPDATE_ERR;
            return;
        }

        public override int GetUpdateStatus() => _getUpdateStatus;

        // Команда
        // Предусловие: ключ существует в словаре.
        // Постусловие: изменено значение по ключу в словаре.
        public override void Update(string Key,T value)
        {
            int index = HashFunc(Key);
            var item = table[index].Find(p => p.Key == Key);
            if (item != null)
            {
                _getUpdateStatus = UPDATE_OK;
                item.Value = value;
                return;
            }
            _getUpdateStatus = UPDATE_ERR;
            return;
        }

        private int HashFunc(string Key)
        {
            return Key.GetHashCode() % table.Length;
        }
    }
}
