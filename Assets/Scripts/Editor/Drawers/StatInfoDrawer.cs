//using System;
//using System.Linq;
//using System.Reflection;
//using UnityEditor;
//using UnityEngine;

//namespace Assets.Scripts.Editor.Drawers
//{
//    [CustomPropertyDrawer(typeof(ScriptableStatModifier.StatInfo))]
//    public class StatInfoDrawer : PropertyDrawer
//    {
//        private static string[] fieldNames;

//        static StatInfoDrawer()
//        {
//            fieldNames = typeof(ScriptableStatModifier.StatInfo)
//                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
//                .Select(field => field.Name)
//                .ToArray();
//        }

//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);
//            //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//            var indent = EditorGUI.indentLevel;
//            EditorGUI.indentLevel = 0;

//            const float offsetX = 10f;
//            var statPropertyRect = new Rect(position.x, position.y, 100, position.height);
//            var valuePropertyRect = new Rect(position.x + statPropertyRect.width + offsetX, position.y, 60, position.height);

//            foreach (var (name, rect) in fieldNames.Zip(new Rect[] { statPropertyRect, valuePropertyRect}, Tuple.Create))
//                CreatePropertyField(property.FindPropertyRelative(name), rect);

//            EditorGUI.indentLevel = indent;
//            EditorGUI.EndProperty();
//        }

//        private static void CreatePropertyField(SerializedProperty property, Rect propertyRect)
//        {
//            EditorGUI.PropertyField(propertyRect, property, GUIContent.none);
//        }
//    }
//}
