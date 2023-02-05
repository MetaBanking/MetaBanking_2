using System;
using System.Collections.Generic;
using UnityEngine;

namespace Character_2
{
    [Serializable]
    public class Props_2
    {
        [field: NonSerialized] public static GameObject LastPropAttached { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitializeOnLoad()
        {
            LastPropAttached = null;
        }
        
        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private Dictionary<int, List<IProp_2>> m_Props;
        [NonSerialized] private Character_2 m_Character;

        // EVENTS: --------------------------------------------------------------------------------

        public event Action<Transform, GameObject> EventAdd;
        public event Action<Transform> EventRemove;
        
        // CONSTRUCTOR: ---------------------------------------------------------------------------

        public Props_2()
        {
            this.m_Props = new Dictionary<int, List<IProp_2>>();
        }
        
        // INITIALIZE METHODS: --------------------------------------------------------------------
        
        internal void OnStartup(Character_2 character)
        {
            this.m_Character = character;
            this.m_Character.EventAfterChangeModel += this.OnChangeModel;
        }
        
        internal void AfterStartup(Character_2 character)
        { }

        internal void OnDispose(Character_2 character)
        {
            this.m_Character = character;
            this.m_Character.EventAfterChangeModel -= this.OnChangeModel;
        }

        internal void OnEnable()
        { }

        internal void OnDisable()
        { }
        
        ///////////////////////////////////////////////////////////////////////////////////////////
        // DEPRECATED METHODS: --------------------------------------------------------------------
        
        // TODO: Remove deprecated method in next update
        [Obsolete("Deprecated method and will be removed in the future. Use AttachPrefab(...)")]
        public GameObject Attach(IBone_2 bone, GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return this.AttachPrefab(bone, prefab, position, rotation);
        }
        
        // TODO: Remove deprecated method in next update
        [Obsolete("Deprecated method and will be removed in the future. Use RemovePrefab(...)")]
        public void Remove(GameObject prefab)
        {
            this.RemovePrefab(prefab);
        }
        
        // ----------------------------------------------------------------------------------------
        ///////////////////////////////////////////////////////////////////////////////////////////
        
        // PUBLIC METHODS: ------------------------------------------------------------------------

        /// <summary>
        /// Creates a new instance of the prefab at the specified bone location with the right
        /// coordinates.
        /// </summary>
        /// <param name="bone"></param>
        /// <param name="prefab"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public GameObject AttachPrefab(IBone_2 bone, GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (prefab == null) return null;
            
            int instanceID = prefab.GetInstanceID();
            if (!this.m_Props.TryGetValue(instanceID, out List<IProp_2> props))
            {
                props = new List<IProp_2>();
                this.m_Props.Add(instanceID, props);
            }
            
            PropPrefab_2 prop = new PropPrefab_2(bone, prefab, position, rotation);
            prop.Create(this.m_Character.Animim.Animator);
            
            props.Add(prop);
            
            LastPropAttached = prop.Instance;
            this.EventAdd?.Invoke(prop.Bone, prop.Instance);

            return prop.Instance;
        }
        
        /// <summary>
        /// Attaches an existing game object instance at the specified bone location with the right
        /// coordinates.
        /// </summary>
        /// <param name="bone"></param>
        /// <param name="instance"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public GameObject AttachInstance(IBone_2 bone, GameObject instance, Vector3 position, Quaternion rotation)
        {
            if (instance == null) return null;
            
            int instanceID = instance.GetInstanceID();
            if (!this.m_Props.TryGetValue(instanceID, out List<IProp_2> props))
            {
                props = new List<IProp_2>();
                this.m_Props.Add(instanceID, props);
            }
            
            PropInstance_2 prop = new PropInstance_2(bone, instance, position, rotation);
            prop.Create(this.m_Character.Animim.Animator);
            
            props.Add(prop);
            
            LastPropAttached = prop.Instance;
            this.EventAdd?.Invoke(prop.Bone, prop.Instance);

            return prop.Instance;
        }

        /// <summary>
        /// Removes an instance of the prefab. If there are multiple instances, it removes the
        /// oldest one.
        /// </summary>
        /// <param name="prefab"></param>
        public void RemovePrefab(GameObject prefab)
        {
            if (prefab == null) return;
            int instanceID = prefab.GetInstanceID();
            
            if (!this.m_Props.TryGetValue(instanceID, out List<IProp_2> props)) return;
            if (props.Count <= 0) return;

            int removeIndex = props.Count - 1;
            Transform bone = props[removeIndex].Bone;
            
            props[removeIndex].Destroy();
            props.RemoveAt(removeIndex);
            
            this.EventRemove?.Invoke(bone);
        }

        /// <summary>
        /// Removes the specific instance of an instance of a prefab
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="instanceID"></param>
        public void RemovePrefab(GameObject prefab, int instanceID)
        {
            if (prefab == null) return;
            int prefabInstanceID = prefab.GetInstanceID();

            if (!this.m_Props.TryGetValue(prefabInstanceID, out List<IProp_2> props)) return;
            if (props.Count <= 0) return;

            for (int i = 0; i < props.Count; i++)
            {
                IProp_2 prop = props[i];
                
                if (prop.Instance == null) continue;
                if (prop.Instance.GetInstanceID() != instanceID) continue;

                Transform bone = prop.Bone;

                prop.Destroy();
                props.RemoveAt(i);

                this.EventRemove?.Invoke(bone);
                return;
            }
        }
        
        /// <summary>
        /// Removes a specific instance.
        /// </summary>
        /// <param name="instance"></param>
        public void RemoveInstance(GameObject instance)
        {
            if (instance == null) return;
            int instanceID = instance.GetInstanceID();
            
            if (!this.m_Props.TryGetValue(instanceID, out List<IProp_2> props)) return;
            if (props.Count <= 0) return;

            int removeIndex = props.Count - 1;
            Transform bone = props[removeIndex].Bone;
            
            props[removeIndex].Destroy();
            props.RemoveAt(removeIndex);
            
            this.EventRemove?.Invoke(bone);
        }
        
        /// <summary>
        /// Detaches an instance of the prefab from the Character. If there are multiple
        /// instances, it removes the oldest one.
        /// </summary>
        /// <param name="prefab"></param>
        /// <returns></returns>
        public GameObject DropPrefab(GameObject prefab)
        {
            if (prefab == null) return null;
            int instanceID = prefab.GetInstanceID();

            if (!this.m_Props.TryGetValue(instanceID, out List<IProp_2> props)) return null;
            if (props.Count <= 0) return null;

            int removeIndex = props.Count - 1;
            Transform bone = props[removeIndex].Bone;

            GameObject instance = props[removeIndex].Instance;
            
            props[removeIndex].Drop();
            props.RemoveAt(removeIndex);
            
            this.EventRemove?.Invoke(bone);
            return instance;
        }

        /// <summary>
        /// Detaches a specific instance of the prefab from the Character
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="instanceID"></param>
        /// <returns></returns>
        public GameObject DropPrefab(GameObject prefab, int instanceID)
        {
            if (prefab == null) return null;
            int prefabInstanceID = prefab.GetInstanceID();

            if (!this.m_Props.TryGetValue(prefabInstanceID, out List<IProp_2> props)) return null;
            if (props.Count <= 0) return null;

            for (int i = 0; i < props.Count; i++)
            {
                IProp_2 prop = props[i];
                
                if (prop.Instance == null) continue;
                if (prop.Instance.GetInstanceID() != instanceID) continue;

                Transform bone = prop.Bone;
                GameObject instance = prop.Instance;

                prop.Drop();
                props.RemoveAt(i);

                this.EventRemove?.Invoke(bone);
                return instance;
            }

            return null;
        }
        
        /// <summary>
        /// Drops a specific instance.
        /// </summary>
        /// <param name="instance"></param>
        public void DropInstance(GameObject instance)
        {
            if (instance == null) return;
            int instanceID = instance.GetInstanceID();
            
            if (!this.m_Props.TryGetValue(instanceID, out List<IProp_2> props)) return;
            if (props.Count <= 0) return;

            int removeIndex = props.Count - 1;
            Transform bone = props[removeIndex].Bone;
            
            props[removeIndex].Drop();
            props.RemoveAt(removeIndex);
            
            this.EventRemove?.Invoke(bone);
        }

        /// <summary>
        /// Removes all props associated with a bone
        /// </summary>
        /// <param name="bone"></param>
        public void RemoveAtBone(IBone_2 bone)
        {
            Transform boneTransform = bone.GetTransform(this.m_Character.Animim.Animator);
            if (boneTransform == null) return;
            
            foreach (KeyValuePair<int, List<IProp_2>> entry in this.m_Props)
            {
                for (int i = entry.Value.Count - 1; i >= 0; --i)
                {
                    IProp_2 prop = entry.Value[i];
                    if (prop.Bone != boneTransform) continue;

                    prop.Destroy();
                    entry.Value.RemoveAt(i);
                    
                    this.EventRemove?.Invoke(boneTransform);
                }
            }
        }
        
        /// <summary>
        /// Drops all props associated with a bone
        /// </summary>
        /// <param name="bone"></param>
        public void DropAtBone(IBone_2 bone)
        {
            Transform boneTransform = bone.GetTransform(this.m_Character.Animim.Animator);
            if (boneTransform == null) return;
            
            foreach (KeyValuePair<int, List<IProp_2>> entry in this.m_Props)
            {
                for (int i = entry.Value.Count - 1; i >= 0; --i)
                {
                    IProp_2 prop = entry.Value[i];
                    if (prop.Bone != boneTransform) continue;

                    prop.Drop();
                    entry.Value.RemoveAt(i);
                    
                    this.EventRemove?.Invoke(boneTransform);
                }
            }
        }

        /// <summary>
        /// Removes all props
        /// </summary>
        public void RemoveAll()
        {
            foreach (KeyValuePair<int, List<IProp_2>> entry in this.m_Props)
            {
                foreach (IProp_2 prop in entry.Value)
                {
                    prop.Destroy();
                    this.EventRemove?.Invoke(prop.Bone);
                }
            }
            
            this.m_Props.Clear();
        }
        
        /// <summary>
        /// Drops all props
        /// </summary>
        public void DropAll()
        {
            foreach (KeyValuePair<int, List<IProp_2>> entry in this.m_Props)
            {
                foreach (IProp_2 prop in entry.Value)
                {
                    prop.Drop();
                    this.EventRemove?.Invoke(prop.Bone);
                }
            }
            
            this.m_Props.Clear();
        }

        /// <summary>
        /// Returns true if the specified bone contains at least one prop
        /// </summary>
        /// <param name="bone"></param>
        /// <returns></returns>
        public bool HasAtBone(IBone_2 bone)
        {
            Transform boneTransform = bone.GetTransform(this.m_Character.Animim.Animator);
            if (boneTransform == null) return false;
            
            foreach (KeyValuePair<int, List<IProp_2>> entry in this.m_Props)
            {
                for (int i = entry.Value.Count - 1; i >= 0; --i)
                {
                    IProp_2 prop = entry.Value[i];
                    if (prop?.Bone != boneTransform) continue;

                    return true;
                }
            }

            return false;
        }
        
        // CALLBACKS: -----------------------------------------------------------------------------

        private void OnChangeModel()
        {
            foreach (KeyValuePair<int, List<IProp_2>> entry in this.m_Props)
            {
                foreach (IProp_2 prop in entry.Value)
                {
                    prop.Destroy();
                    this.EventRemove?.Invoke(prop.Bone);
                    
                    prop.Create(this.m_Character.Animim.Animator);
                    this.EventAdd?.Invoke(prop.Bone, prop.Instance);
                }
            }
        }
    }
}