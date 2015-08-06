using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;

namespace MedicalManagement.Models
{
    static class Extensiones
    {
        private class TargetProperty
        {
            public object Target { get; set; }
            public PropertyInfo Property { get; set; }

            public bool IsValid { get { return Target != null && Property != null; } }
        }

        private static TargetProperty GetTargetProperty(object source, string propertyName)
        {
            if (!propertyName.Contains("."))
                return new TargetProperty { Target = source, Property = source.GetType().GetProperty(propertyName) };

            string[] propertyPath = propertyName.Split('.');

            var targetProperty = new TargetProperty();

            targetProperty.Target = source;
            targetProperty.Property = source.GetType().GetProperty(propertyPath[0]);

            for (int propertyIndex = 1; propertyIndex < propertyPath.Length; propertyIndex++)
            {
                propertyName = propertyPath[propertyIndex];
                if (!string.IsNullOrEmpty(propertyName))
                {
                    targetProperty.Target = targetProperty.Property.GetValue(targetProperty.Target, null);
                    targetProperty.Property = targetProperty.Target.GetType().GetProperty(propertyName);
                }
            }

            return targetProperty;
        }


        public static bool HasProperty(object source, string propertyName)
        {
            return GetTargetProperty(source, propertyName).Property != null;
        }

        public static object GetPropertyValue(this object source, string propertyName)
        {
            var targetProperty = GetTargetProperty(source, propertyName);
            if (targetProperty.IsValid)
            {
                return targetProperty.Property.GetValue(targetProperty.Target, null);
            }
            return null;
        }

        public static void SetPropertyValue(this object source, string propertyName, object value)
        {
            var targetProperty = GetTargetProperty(source, propertyName);
            if (targetProperty.IsValid)
            {
                targetProperty.Property.SetValue(targetProperty.Target, value, null);
            }
        }
    }
    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}