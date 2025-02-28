using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class ForestGEnerator : MonoBehaviour
{
    public enum forest
    {
        Square,
        Circle
    }
    [Tooltip("list of all tree to instantiates")]
    [SerializeField] private List<tree> _treeList;
    [SerializeField] GameObject _treePrehab;

    [Foldout("Parametres")]
    [AllowNesting]
    [SerializeField] private forest _shape;

    [Foldout("Parametres")]
    [AllowNesting]
    [SerializeField] private Vector3 _offset;


    [Foldout("Parametres")]
    [AllowNesting]
    [Range(0f,100f)]
    [SerializeField] private float _ForestRange;

    private List<GameObject> _allTree=new List<GameObject>();

    [Button]

    public void Addtree()
    {
        if (_shape == forest.Square)

        {
            foreach (tree tree in _treeList)
            {
                Vector3 RandomsPos = Random.insideUnitSphere * _ForestRange;
                Vector3 randoms = _offset + new Vector3(Random.Range(-_ForestRange, _ForestRange), 0, Random.Range(-_ForestRange, _ForestRange));
                Quaternion RandomRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                GameObject newTree = Instantiate(_treePrehab, randoms, RandomRotation);
                _allTree.Add(newTree);
                newTree.transform.localScale = new Vector3(tree._raduis, tree._raduis, tree._height);

            }
        }


        if (_shape == forest.Circle)

        {
            foreach (tree tree in _treeList)
            {

                Vector3 randomPos = Random.insideUnitSphere * _ForestRange;
                randomPos = _offset + new Vector3(randomPos.x, 0, randomPos.z);
                Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                GameObject newTree = Instantiate(_treePrehab, randomPos, randomRotation);
                _allTree.Add(newTree);
                newTree.transform.localScale = new Vector3(tree._raduis, tree._height, tree._radius);
            }
        }
    }
        [Button]

    public void RemoveAllTree()
    {
        for (int i = _allTree.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(_allTree[i]);
            _allTree.RemoveAt(i);
        }
    }



}
