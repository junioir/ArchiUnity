using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class zonetool2 : MonoBehaviour
{
    [SerializeField] private List<List<Vector3>> _listOfpoints = new List<List<Vector3>>();
    private List<Vector3> _currentlist;
    [SerializeField] private float _collapsePointRange = 1f;

    public int _ZoneIndex;

    public void Createzone()
    {
        _currentlist = new List<Vector3>();
        _listOfpoints.Add(_currentlist);
        _ZoneIndex = _listOfpoints.Count - 1;

    }

    public void SetDirty()
    {
      EditorUtility.SetDirty(this);
    }

    public void NextZone()
    {
        _ZoneIndex++;
        if (_ZoneIndex >= _listOfpoints.Count)
        {
            _ZoneIndex = 0;
        }

        _currentlist = _listOfpoints[_ZoneIndex];
    }

    public void PrevtZone()
    {
        _ZoneIndex--;
        if (_ZoneIndex < 0)
        {
            _ZoneIndex = _listOfpoints.Count - 1;
        }

        _currentlist = _listOfpoints[_ZoneIndex];
    }

    public void AddPointZone(Vector3 point)

    {
        Vector3 PositionToAdd = point;

        foreach (Vector3 PointTocheck in _currentlist)
        {
            if ((point - PointTocheck).magnitude <= _collapsePointRange)
            {
                PositionToAdd = PointTocheck;
                break;
            }
        }
        _currentlist.Add(PositionToAdd);
    }

    public void clearCurrentZone()
    {
        _listOfpoints.Remove(_currentlist);
        _currentlist.Clear();
    }

    public List<List<Vector3>> GetAtzone()
    {
        return _listOfpoints;
    }
    public int GetCurrentZone()
    {
        return _ZoneIndex;
    }
}
