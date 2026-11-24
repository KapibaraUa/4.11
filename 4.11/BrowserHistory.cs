using System;
using System.Collections.Generic;

namespace PracticeLinkedList;

internal class BrowserHistory
{
    private LinkedList<string> _history = new LinkedList<string>();
    private LinkedListNode<string>? _current;

    public BrowserHistory()
    {
        _current = null;
    }

    public BrowserHistory(string homepage)
    {
        Visits(homepage);
    }

    public void Visits(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("Invalid URL");
        }

        if (_current != null)
        {
            while (_current.Next != null)
            {
                _history.Remove(_current.Next);
            }
        }

        _current = _history.AddLast(url);
    }

    public string Back(int steps)
    {
        if (_current == null)
        {
            return "Історія порожня";
        }

        if (steps < 0)
        {
            throw new ArgumentOutOfRangeException("Steps cannot be negative");
        }

        while (steps > 0 && _current.Previous != null)
        {
            _current = _current.Previous;
            steps--;
        }

        return _current.Value;
    }

    public string Forward(int steps)
    {
        if (_current == null)
        {
            return "Історія порожня";
        }

        if (steps < 0)
        {
            throw new ArgumentOutOfRangeException("Steps cannot be negative");
        }

        while (steps > 0 && _current.Next != null)
        {
            _current = _current.Next;
            steps--;
        }

        return _current.Value;
    }

    public string GetCurrentPage()
    {
        if (_current == null)
        {
            return "Історія порожня";
        }

        return _current.Value;
    }

    public void ShowHistory()
    {
        if (_history.Count == 0)
        {
            Console.WriteLine("Історія порожня");
            return;
        }

        LinkedListNode<string>? node = _history.First;

        while (node != null)
        {
            if (node == _current)
            {
                Console.Write($"[ {node.Value} ]");
            }
            else
            {
                Console.Write(node.Value);
            }

            if (node.Next != null)
            {
                Console.Write(" -> ");
            }

            node = node.Next;
        }

        Console.WriteLine();
    }
}