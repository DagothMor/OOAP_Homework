namespace OOAP_Homework
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
    
    public abstract class ParentList<T>
    {
        protected Node<T> _head;
        protected Node<T> _tail;
        protected Node<T> _cursor;

        // конструктор
        // постусловие: создан новый пустой список
        public ParentList()
        {
            _head = null;
            _tail = null;
            _cursor = null;
        }

        public const int HEAD_NIL = 0;
        public const int HEAD_OK = 1;
        public const int HEAD_ERR = 2;
        protected int head_status;
        public int GetHeadStatus() => head_status;
        // Команда.
        // Установить курсор на первый узел в списке;
        // Предусловие: лист не должен быть пустым.
        // Постусловие: Курсор указывает на первую ноду.
        public void Head()
        {
            if (Size() == 0)
            {
                head_status = HEAD_ERR;
                return;
            }
            _cursor = _head;
            head_status = HEAD_OK;
        }

        public const int TAIL_NIL = 0;
        public const int TAIL_OK = 1;
        public const int TAIL_ERR = 2;
        protected int tail_status;
        public int GetTailStatus() => tail_status;
        // Команда.
        // Установить курсор на последний узел в списке;
        // Предусловие: список не должен быть пустым.
        // Постусловие: Курсор указывает на конечную ноду.
        public void Tail()
        {
            if (Size() == 0)
            {
                tail_status = TAIL_ERR;
                return;
            }
            _cursor = _tail;
            tail_status = TAIL_OK;
        }

        public const int RIGHT_NIL = 0;
        public const int RIGHT_OK = 1;
        public const int RIGHT_ERR = 2;
        protected int right_status;
        public int GetRightStatus() => right_status;
        // Команда.
        // Установить курсор на последний узел в списке;
        // Предусловие: список не должен быть пустым.
        // Предусловие: курсор не должен быть пустым.
        // Предусловие: следующая нода должна существовать.
        // Постусловие: Курсор указывает на следующую ноду.
        public void Right()
        {
            if (Size() == 0)
            {
                right_status = RIGHT_ERR;
                return;
            }
            if (_cursor == null)
            {
                right_status = RIGHT_ERR;
                return;
            }
            if (_cursor == _tail)
            {
                right_status = RIGHT_ERR;
                return;
            }
            _cursor = _cursor.Next;
            right_status = RIGHT_OK;
        }
        public const int PUTRIGHT_NIL = 0;
        public const int PUTRIGHT_OK = 1;
        public const int PUTRIGHT_ERR = 2;
        protected int put_right_status;
        public int GetPutRightStatus() => put_right_status;
        // Команда.
        // предусловие: список не пустой
        // предусловие: курсор не пустой
        // постусловие: в список добавлено новое значение справа от курсора
        public void PutRight(T value)
        {
        }

        public const int PUTLEFT_NIL = 0;
        public const int PUTLEFT_OK = 1;
        public const int PUTLEFT_ERR = 2;
        protected int put_left_status;
        public int GetPutLeftStatus() => put_left_status;
        // команда
        // предусловие: список не пустой
        // предусловие: курсор не пустой
        // постусловие: в список добавлено новое значение слева от курсора
        public void PutLeft(T value)
        {
        }

        public const int REMOVE_NIL = 0;
        public const int REMOVE_OK = 1;
        public const int REMOVE_ERR = 2;
        protected int remove_status;
        public int GetRemoveStatus() => remove_status;
        // команда
        // предусловие: список не пустой
        // предусловие: курсор не пустой
        // постусловие: из списка удалено значение курсора, на что теперь должен ссылаться курсор? он должен теперь ссылаться на следующую ноду?
        public void Remove()
        {
        }

        public const int CLEAR_NIL = 0;
        public const int CLEAR_OK = 1;
        public const int CLEAR_ERR = 2;
        protected int clear_status;
        public int GetClearStatus() => clear_status;
        // команда
        // Предусловие: Список не пуст.
        // постусловие: из списка удалятся все значения
        public void Clear()
        {
        }
        public const int ADD_TO_EMPTY_NIL = 0;
        public const int ADD_TO_EMPTY_OK = 1;
        public const int ADD_TO_EMPTY_ERR = 2;
        protected int add_to_empty_status;
        public int GetAddToEmptyStatus() => add_to_empty_status;
        // Команда.
        // Добавить новый узел в пустой список.
        // предусловие: список пустой
        // постусловие: курсор,хвост,голова, ссылаются на новую ноду.
        public void AddToEmpty(T value)
        {
        }

        public const int ADD_TAIL_NIL = 0;
        public const int ADD_TAIL_OK = 1;
        public const int ADD_TAIL_ERR = 2;
        protected int add_tail_status;
        public int GetAddTailStatus() => add_tail_status;
        // Команда.
        // Добавить новый узел в хвост списка;
        // предусловие: список не пустой.
        // постусловие: хвост ссылается на новую ноду.
        public void AddTail(T value)
        {
        }

        public const int REPLACE_NIL = 0;
        public const int REPLACE_OK = 1;
        public const int REPLACE_ERR = 2;
        protected int replace_status;
        public int GetReplaceStatus() => replace_status;
        // Команда
        // Заменить значение текущего узла на заданное;
        // предусловие: список не пустой.
        // предусловие: курсор не пустой.
        // постусловие: значение курсора изменено.
        public void Replace(T value)
        {
        }

        public const int REMOVE_ALL_NIL = 0;
        public const int REMOVE_ALL_OK = 1;
        public const int REMOVE_ALL_ERR = 2;
        protected int remove_all_status;
        public int GetRemoveAllStatus() => remove_all_status;
        // Команда.
        // Удалить в списке все узлы с заданным значением;
        // предусловие: список не пустой.
        // постусловие: все ноды с определенным значением удалены.
        public void RemoveAll(T value)
        {
        }

        public const int FIND_NILL = 0;
        public const int FIND_OK = 1;
        public const int FIND_ERR = 2;
        protected int find_status;
        public int GetFindStatus() => find_status;
        // Запрос.
        // предусловие: стек не пустой
        public void Find(T value)
        {
        }

        public const int SIZE_NIL = 0;
        public const int SIZE_OK = 1;
        public const int SIZE_ERR = 2;
        protected int size_status;
        public int GetSizeStatus() => size_status;
        // Запрос
        // предусловие: список не пустой
        public int Size()
        {
            return 0;
        }

        public const int GET_NIL = 0;
        public const int GET_OK = 1;
        public const int GET_ERR = 2;
        protected int get_status;
        public int GetStatus() => get_status;
        // Запрос.
        // предусловие: список не пустой
        // предусловие: курсор не пустой
        public T Get()
        {
            return default;
        }
        // Запрос.
        // Находится ли курсор в начале списка?
        // Предусловие: Список не пустой.
        public bool IsHead()
        {
            return _cursor == _head;
        }

        // Запрос.
        // Находится ли курсор в конце списка?
        // Предусловие: Список не пустой.
        public bool IsTail()
        {
            return _cursor == _tail;
        }

        // Запрос.
        // Установлен ли курсор на какой-либо узел в списке.
        // Предусловие: Список не пустой.
        public bool IsValue()
        {
            return _cursor != null;
        }
    }

    public class LinkedList<T> : ParentList<T>
    {

    }

    public class TwoWayList<T> : ParentList<T>
    {
        public const int LEFT_NIL = 0;
        public const int LEFT_OK = 1;
        public const int LEFT_ERR = 2;
        protected int left_status;
        public int GetLeftStatus() => left_status;
        // Команда.
        // Установить курсор левее текущего узла.
        // Предусловие: список не должен быть пустым.
        // Предусловие: курсор не должен быть пустым.
        // Предусловие: курсор не должен быть равен голове.
        // Постусловие: Курсор указывает на предыдущую ноду.
        public void Left()
        {
            if (Size() == 0)
            {
                left_status = LEFT_ERR;
                return;
            }
            if (_cursor == null)
            {
                left_status = LEFT_ERR;
                return;
            }
            if (_cursor == _tail)
            {
                left_status = LEFT_ERR;
                return;
            }
            _cursor = _cursor.Next;
            left_status = LEFT_OK;
        }
    }

}