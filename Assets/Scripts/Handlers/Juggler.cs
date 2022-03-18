using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Handlers
{
    public class Juggler : Singleton<Juggler>
    {
        private static HashSet<IUpdatable> _updatables;
        private static HashSet<IFixedUpdatable> _fixedUpdatables;

        private bool _fixedUpdateIsActive;

        protected override void OnAwake()
        {
            base.OnAwake();
            _updatables = new HashSet<IUpdatable>();
            _fixedUpdatables = new HashSet<IFixedUpdatable>();
        }

        private void Update()
        {
            var updatablesTemp = _updatables.ToArray();
            foreach (var updatable in updatablesTemp)
                updatable.OnUpdate();

            _fixedUpdateIsActive = false;
        }

        private void FixedUpdate()
        {
            if (_fixedUpdateIsActive)
                return;

            _fixedUpdateIsActive = true;

            var updatablesTemp = _fixedUpdatables.ToArray();
            foreach (var updatable in updatablesTemp)
                updatable.OnFixedUpdate();
        }

        public static void AddUpdateHandler(IUpdatable handler)
        {
            _updatables.Add(handler);
        }

        public static void RemoveUpdateHandler(IUpdatable handler)
        {
            _updatables.Remove(handler);
        }

        public static void AddFixedUpdateHandler(IFixedUpdatable handler)
        {
            _fixedUpdatables.Add(handler);
        }

        public static void RemoveFixedUpdateHandler(IFixedUpdatable handler)
        {
            _fixedUpdatables.Remove(handler);
        }

        public Coroutine GetStartCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void SetStopCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
