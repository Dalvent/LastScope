using UnityEngine;

namespace LastScope.Extensions
{
    public static class GameObjectExtensions
    {
        public static GameObject FindInChildWithTag(this GameObject parent, string tag)
        {
            foreach(Transform child in parent.transform)
            {
                if (child.CompareTag(tag))
                {
                    return child.gameObject;
                }
                
            }
            return null;
        }
    }
}