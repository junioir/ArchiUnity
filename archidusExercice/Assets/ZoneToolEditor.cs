using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(zonetool2))]
public class ZoneToolEditor : Editor
{
    private zonetool2 _zonetool;

    private void OnEnable()
    {
        _zonetool = (zonetool2)target;
        SceneView view = SceneView.lastActiveSceneView;
        if (view != null)
        {
            view.orthographic = true;
        }
        SceneView.lastActiveSceneView.size = 45;
    }


    private void OnDisable()
    {

        SceneView view = SceneView.lastActiveSceneView;
        view.in2DMode = false;
        if (view != null)
        {
            view.orthographic = false;
        }
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Keyboard));

    }

    private void OnSceneGUI()
    {
        List<List<Vector3>> _list = _zonetool.GetAtzone();
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

        Vector3 pos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
        Vector3 MouseworldPos = new Vector3(pos.x, pos.y, 0f);

        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            _zonetool.AddPointZone(MouseworldPos);
            _zonetool.SetDirty();

        }
        DrawAllZONE(_list);
    }


    private void DrawAllZONE(List<List<Vector3>> _list)
    {
        for (int j = 0; j < _list.Count; j++)
        {
            List<Vector3> _zone = _list[j];

            for (int i = 0; i < _zone.Count - 1; i++)
            {
                DrawLine(_zone[i], _zone[i + 1], _zonetool.GetCurrentZone() == j);
            }

        }
    }

    private void DrawLine(Vector3 pos1, Vector3 pos2, bool isCurrentZone)
    {
        if (isCurrentZone)

        {
            Handles.DrawBezier(pos1, pos2, pos1, pos2, Color.blue, null, 20);

        }

        else
        {
            Handles.DrawBezier(pos1, pos2, pos1, pos2, Color.blue, null, 5);
        }
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Color basicolor = GUI.color;
        GUI.color = Color.red;
        GUILayout.BeginVertical();

        if (_zonetool.GetAtzone().Count > 0)

        {

            if(GUILayout.Button("clear current zone"))

            {
                _zonetool.clearCurrentZone();
            }

        }
        GUI.color = Color.green;


        if (GUILayout.Button("create a new zone"))

        {
            _zonetool.Createzone();
        }
        GUI.color = basicolor;


        if (GUILayout.Button("Next zone"))

        {
            _zonetool.NextZone();
        }
        GUI.color = basicolor;

        if (GUILayout.Button("prevZone"))

        {
            _zonetool.PrevtZone();
        }


        GUILayout.BeginHorizontal();
        GUILayout.TextField("left mouse click",GUILayout.Width(150));
        GUILayout.TextField("Add point ", GUILayout.Width(150));
        GUILayout.EndHorizontal();




        GUILayout.BeginHorizontal();
        GUILayout.TextField("arrow key", GUILayout.Width(150));
        GUILayout.TextField("Movz around Camera ", GUILayout.Width(150));
        GUILayout.EndHorizontal();


        int newvalue = EditorGUILayout.IntField(_zonetool._ZoneIndex, GUILayout.Width(150));
        _zonetool._ZoneIndex = newvalue;

        GUILayout.EndVertical();

        DrawDefaultInspector();


    }



}
