using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pointer
{
    public class PointingManager : MonoBehaviour
    {
        private static PointingManager mInstance;
        public static PointingManager Instance => mInstance;

        [SerializeField] private float reachDistance = 5;

        private PlayerMovement _playerMovement;
        private Camera _mainCamera;

        public event Action<Collider2D, bool> OnClicked;

        private void Awake()
        {
            mInstance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(1))
            {
                return;
            }

            if (!_mainCamera || !_playerMovement)
            {
                return;
            }

            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, 2);
            if (!hit.collider)
            {
                return;
            }
            OnClicked?.Invoke(hit.collider, IsInReach(hit.collider));
            print($"Clicked {hit.collider.name}, {IsInReach(hit.collider)}");
        }

        private bool IsInReach(Collider2D coll)
        {
            return Vector3.Distance(_playerMovement.transform.position, coll.transform.position) <= reachDistance;
        }
    }
}