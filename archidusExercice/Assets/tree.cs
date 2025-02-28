using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;

[Serializable]
public class tree

{
    [MinValue(0),MaxValue(10f)]
    public float _lengtoFbranch;

    [MinValue(0), MaxValue(10f)]
    public int _numberoFbranch;

    public float _raduis;
    public float _height;

    public bool _hasleaf;
    [AllowNesting]
    [ShowIf("_hasleaf")]
    public float _sizeOfLeaf;
    [AllowNesting]
    [ShowIf("_hasleaf")]
    public float _NumberOfLeaf;
    [AllowNesting]
    [ShowIf("_hasleaf")]

    public Color _LeafColor;
    internal float _radius;
}
