using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unique.Collections;
using System;
using System.Diagnostics;

public class MBTestArraySnapshotSpeed : MonoBehaviour
{
	private void Start ()
    {
        var size = 8192;
        _InitContainers(size);

        for (int i= 0; i< 10; ++i)
        {
            _OneTest(100);
        }
	}

    private void _InitContainers (int size)
    {
        _rawArray = new object[size];
        _list = new List<object>(size);
        _snapshotArray = new object[size];
        _dict = new Dictionary<int, object>(size);
		_sorted = new ClientTable<int, object>(size);

        for (int i= 0; i< size; ++i)
        {
            var item = new object();
            _rawArray[i] = item;
            _list.Add(item);
            _dict.Add(i, item);
			_sorted.Add(i, item);
        }
    }
	
    private void Update ()
    {
//        _TestDictBuiltinCopyToSnapshot();
    }

    private void _OneTest (int repeat)
    {
        var rawArrayTime = _RunByWatch(repeat, ()=>_TestRawArray());
        var listTime = _RunByWatch(repeat, ()=> _TestList());
        var builtinCopyToTime = _RunByWatch(repeat, ()=> _TestBuiltinCopyToSnapshot());
        var oneByOneCopyToTime = _RunByWatch(repeat, ()=> _TestOneByOneCopyToSnapshot());

        var dictTime = _RunByWatch(repeat, ()=> _TestIterateDict());
        var dictBuiltinCopyToTime = _RunByWatch(repeat, ()=> _TestDictBuiltinCopyToSnapshot());

        var sortedSnapshotTime = _RunByWatch(repeat, ()=> _TestSortedTableSnapshot());

        UnityEngine.Debug.LogFormat("listRatio={0}, builtinCopyToRatio={1}, oneByOneCopyToRatio={2}", 
            listTime/rawArrayTime, builtinCopyToTime/rawArrayTime, oneByOneCopyToTime/rawArrayTime);

        UnityEngine.Debug.LogFormat("dictRatio={0}, dictBuiltinCopyToRatio={1}, sortedSnapshotRatio={2}"
            , dictTime/rawArrayTime, dictBuiltinCopyToTime/rawArrayTime, sortedSnapshotTime/rawArrayTime);
	}

    private void _TestRawArray ()
    {
        var count = _rawArray.Length;
        for (int i= 0; i< count; ++i)
        {
            var item = _rawArray[i];
        }
    }

    private void _TestList ()
    {
        var count = _list.Count;
        for (int i= 0; i< count; ++i)
        {
            var item = _list[i];
        }
    }

    private void _TestBuiltinCopyToSnapshot ()
    {
        var count = _rawArray.Length;
        Array.Copy(_rawArray, _snapshotArray, count);

        for (int i= 0; i< count; ++i)
        {
            var item = _snapshotArray[i];
        }
    }

    private void _TestOneByOneCopyToSnapshot ()
    {
        var count = _rawArray.Length;
        for (int i= 0; i< count; ++i)
        {
            _snapshotArray[i] = _rawArray[i];
        }

        for (int i= 0; i< count; ++i)
        {
            var item = _snapshotArray[i];
        }
    }

    private void _TestDictBuiltinCopyToSnapshot ()
    {
        var count = _dict.Count;
        _dict.Values.CopyTo(_snapshotArray, 0);

        for (int i= 0; i< count; ++i)
        {
            var item = _snapshotArray[i];
        }
    }

    private void _TestIterateDict ()
    {
        var iter = _dict.GetEnumerator();
        while (iter.MoveNext())
        {
            var v = iter.Current.Value;
        }
    }

	private void _TestSortedTableSnapshot ()
	{
		_sorted.GetSnapshot(ref _sortedSnapshot);

		var count = _sortedSnapshot.Count;
		for (int i= 0; i< count; ++i)
		{
			var item = _sortedSnapshot[i];
		}
	}

    private float _RunByWatch (int repeat, Action action)
    {
        var watch = new Stopwatch();
        watch.Start();
        for (int i= 0; i< repeat; ++i)
        {
            action();
        }
        watch.Stop();

        var seconds = watch.ElapsedMilliseconds * 0.001f;
        return seconds;
    }

    private object[] _rawArray;
    private List<object> _list;
    private object[] _snapshotArray;
    private Dictionary<int, object> _dict;
	private ClientTable<int, object> _sorted;
    private ClientTable<int, object>.Snapshot _sortedSnapshot;


//    /// <summary>
//    /// /////////////////////////////
//    /// </summary>
//    private void _Tick_SortedTable_Pair ()
//    {
//        // _table = new SortedTable<int, string>();
//        foreach (var pair in _table)
//        {
//            var v = pair.Value;
//        }
//    }
//
//    private void _Tick_SortedTable_Values ()
//    {
//        // _table = new SortedTable<int, string>();
//        foreach (var v in _table.Values)
//        {
//
//        }
//    }
//
//    private void _Tick_SortedTable_Values_Index ()
//    {
//        // _table = new SortedTable<int, string>();
//        var values = _table.Values;
//        var count = values.Count;
//        for (int i= 0; i< count; ++i)
//        {
//            var v = values[i];
//        }
//    }
//
//    private void _Tick_Dictionay_Pair ()
//    {
//        // _dict = new Dictionary<int, string>();
//        var iter = _dict.GetEnumerator();
//        while (iter.MoveNext())
//        {
//            var pair = iter.Current;
//            var v = pair.Value;
//        }
//    }
//
//    private void _Tick_Dictionary_Values ()
//    {
//        // _dict = new Dictionary<int, string>();
//        var values = _dict.Values;
//        var iter = values.GetEnumerator();
//        while (iter.MoveNext())
//        {
//            var v = iter.Current;
//        }
//    }
//
//    private void _Tick_Hashable_Pair ()
//    {
//        // _hash = new Hashtable();
//        var iter = _hash.GetEnumerator();
//        while (iter.MoveNext())
//        {
//            string v = iter.Value as string;
//        }
//    }
//
//    private void _Tick_Hashtable_Values ()
//    {
//        // _hash = new Hashtable();
//        var values = _hash.Values;
//        var iter = values.GetEnumerator();
//        while (iter.MoveNext())
//        {
//            string v = iter.Current as string;
//        }
//    }
//
//    private void _Tick_SortedDictionary_Pair ()
//    {
//        // _map = new SortedDictionary<int, string>();
//        var iter = _map.GetEnumerator();
//        while (iter.MoveNext())
//        {
//            var pair = iter.Current;
//            var v = pair.Value;
//        }
//    }
//
//    private void _Tick_SortedDictionary_Values ()
//    {
//        // _map = new SortedDictionary<int, string>();
//        var values = _map.Values;
//        var iter = values.GetEnumerator();
//        while (iter.MoveNext())
//        {
//            var v = iter.Current;
//        }
//    }
//
//    private SortedTable<int, string> _table = new SortedTable<int, string>();
//    private Dictionary<int, string> _dict = new Dictionary<int, string>();
//    private SortedDictionary<int, string> _map = new SortedDictionary<int, string>();
//    private Hashtable _hash = new Hashtable();
}
